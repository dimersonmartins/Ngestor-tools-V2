using BotASCWebBrowser.Http.Auth;
using BotNetHome.App;
using BotNetHome.Http;
using BotNetHome.Http.AllTerminaisEmpreiteira;
using BotNetHome.Http.Auth;
using BotNetHome.Http.PesquisaEmLote;
using BotNetHome.Http.RequestDWR;
using BotNgestor.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BotNetHome.Repository
{
    public class NetHomeManager
    {
        public static string statusNetHome  = "Conectando...";
        public static string statusNgestor  = "Aguardando...";
        public static string statusFila     = null;
        public static string last_import    = null;
        public static int totalSeriais      = 0;
        public static bool hasProcess       = false;


        public async Task<string[]> connect()
        {
            try
            {
                //SIMULA O NAVEGADOR ASCWEBBROWSER
                AuthAscWebBrowser ASCBrowser = new AuthAscWebBrowser();
                var ASCWebBrowserCokkies = await ASCBrowser.execute();
                if (ASCWebBrowserCokkies == null)
                {
                    return null;
                }

                Config.ASC_KEY_REMOTE = ASCWebBrowserCokkies[0];
                AuthNetHome authNethome = new AuthNetHome();
                if (await authNethome.getConteudo())
                {
                    string[] cookies = await authNethome.login();
                    if (cookies == null)
                    {
                        return null;
                    }
                    await authNethome.indexNetHome();
                    statusNetHome = "Extraindo Seriais...";
                    return cookies;
                }
            }
            catch
            {
                return null;
            }
           
            return null;
        }
        public async Task<string> montedDWR()
        {
            try
            {
                DWRParameters dWRParameters = new DWRParameters();
                DWR dwr = new DWR(dWRParameters);
                bool isSucess = await dwr.GetSessionDWR();
                if (!isSucess)
                {
                    return null;
                }
                return dWRParameters.baseDWR();
            }
            catch
            {
                return null;
            }
           
        }
        public async Task<string> generateRelatorio(string dwrContent)
        {
            try
            {
                statusNetHome = "Gerando Relatório...";
                GerarRelatorio downRelatorio = new GerarRelatorio();
                string TASK_RELATORIO_CONTENT = await downRelatorio.gerarRelatorio(dwrContent);
                statusNetHome = "Concluido";
                return GetBetween.Between(TASK_RELATORIO_CONTENT, "s1={idTask:", "}");
            }
            catch
            {
                return null;
            }
           
        }

        public async void checkTASK()
        {
            if (hasProcess)
            {
                await hasRelatorio();
            }

            Thread thread = new Thread(() =>
            {
                Thread.Sleep(5000);
                checkTASK();
            })
            { IsBackground = true };
            thread.Start();

        }


        private async Task<bool> hasRelatorio()
        {
            try
            {
                GetResultRelatorio getResultRelatorio = new GetResultRelatorio();
                string[] isSucess = await getResultRelatorio.filas();

                if (isSucess[0] == "false")
                {
                    return false;
                }

                if (!isFinishReportSeriais(isSucess[1]))
                {
                    return false;
                }

                string[] _param = await getResultRelatorio.hasResult();
                string url = getURLToDownload(_param[1]);
                if (url == null)
                {
                    return false;
                }

                string content = await download(url);
                if (content == null)
                {
                    hasProcess = false;
                    return false;
                }

               

                using (CreateJsonFile create = new CreateJsonFile())
                {
                    await create.execute(content);
                    create.Dispose();
                }
                content = string.Empty;

                using (Importacao importacao = new Importacao())
                {
                    await importacao.seriais(Config.TOKEN_NGESTOR, Config.NGESTOR_URL_SERVER, AppDomain.CurrentDomain.BaseDirectory + "zip\\fileAtlas.zip");
                    importacao.Dispose();
                }

                hasProcess = false;
                last_import = DateTime.Now.ToString();
                statusNgestor = "Concluido";

                return true;
            }
            catch
            {
                return false;
            }
      
        }

        private string createTenancyPath()
        {
            try
            {
                string folder = Config.NGESTOR_URL_SERVER.Replace("https:/", "")
                 .Replace("http:/", "")
                 .Replace("/", "")
                 .Replace(".", "_");

                string pathFolder = AppDomain.CurrentDomain.BaseDirectory + folder;

                if (!Directory.Exists(pathFolder))
                {
                    Directory.CreateDirectory(pathFolder);
                }

                if (!Directory.Exists(pathFolder + "\\zip"))
                {
                    Directory.CreateDirectory(pathFolder + "\\zip");
                }

                return pathFolder;
            }
            catch
            {
                return null;
            }
         
        }

        private bool isFinishReportSeriais(string CONTENT)
        {
            try
            {
                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(CONTENT);

                if (CONTENT.Contains("Nenhum Registro Encontrado!"))
                {
                    hasProcess = false;
                    return true;
                }

                var node_td = htmlDoc.DocumentNode.SelectNodes("//table/tr [contains(@class, \"bg-branca\")]/td");
                var list = criarArray(node_td);
                foreach (var TD in list)
                {
                    statusFila = list[2].Value.Trim();
                    if (list[2].Value.Trim() == "COMPLETO")
                    {
                        htmlDoc = null;
                        node_td = null;
                        list = null;
                        return true;
                    }
                    if (list[2].Value.Trim() == "FALHOU")
                    {
                        hasProcess = false;
                        return true;
                    }
                }

            }
            catch
            {
                return false;
            }
            return false;
        }
        private string getURLToDownload(string html)
        {
            try
            {
                int count_url = 0;

                var htmlDoc = new HtmlAgilityPack.HtmlDocument();

                htmlDoc.LoadHtml(html);

                var node_tr = htmlDoc.DocumentNode.SelectNodes("//a");

                string url = null;
                foreach (var item in node_tr)
                {
                    if (item.Attributes["href"].Value.Contains(".xls"))
                    {
                        count_url++;
                        if (count_url > 1)
                        {
                            hasProcess = false;
                            return null;
                        }
                        url = item.Attributes["href"].Value;
                    }
                }
                node_tr = null;
                htmlDoc = null;
                return url;
            }
            catch
            {
                hasProcess = false;
                return null;
            }
           
        }
        public async Task<string> download(string url)
        {
            try
            {
                //await DownloadExcel.force(url, _response[1]);
                DownloadContentRelatorio downRelatorio = new DownloadContentRelatorio();
                return await downRelatorio.download(url);
            }
            catch
            {
                return null;
            }
        }
        private List<KeyValuePair<int, string>> criarArray(HtmlAgilityPack.HtmlNodeCollection htmlNode)
        {
            try
            {
                List<KeyValuePair<int, string>> lista = new List<KeyValuePair<int, string>>();
                int key = 0;

                foreach (var item in htmlNode)
                {
                    lista.Add(new KeyValuePair<int, string>(key, item.InnerText));
                    key++;
                }
                return lista;
            }
            catch
            {
                return null;
            }
          
        }

        #region AGUARDANDO

        public async Task<string> pageSerial(string cookies)
        {
            IndexPageSerial indexPageSerial = new IndexPageSerial();
            return await indexPageSerial.index(cookies);
        }

        public async Task<string> consultaSerialEquipe(string cookies)
        {
            PesquisaSerial downRelatorio = new PesquisaSerial();
            return await downRelatorio.consultaTerminal(cookies, equipamentos());
        }

        public string equipamentos()
        {
            return File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\request.txt");
        }

        public async Task<List<Dictionary<string, string>>> SetFiltros(string COOKIES)
        {
            IndexPageSerial indexPageSerial = new IndexPageSerial();
            string HTML = await indexPageSerial.index(COOKIES);

            if (string.IsNullOrWhiteSpace(HTML))
            {
                return null;
            }

            List<Dictionary<string, string>> listObject = new List<Dictionary<string, string>>();
            listObject.Add(SelectTipoOperacao(HTML));
            listObject.Add(SelectLocalizacao(HTML));
            return listObject;
        }

        public Dictionary<string, string> SelectTipoOperacao(string HTML)
        {
            Dictionary<string, string> combobox = new Dictionary<string, string>();

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(HTML);

            var options = htmlDoc.DocumentNode.SelectNodes("//table/tbody/tr/td/select [contains(@id, \"idOperacao\")] /option");
            foreach (var option in options)
            {
                combobox.Add(option.Attributes["value"].Value, option.InnerText);
            }
            return combobox;
        }

        public Dictionary<string, string> SelectLocalizacao(string HTML)
        {
            Dictionary<string, string> combobox = new Dictionary<string, string>();

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(HTML);

            var options = htmlDoc.DocumentNode.SelectNodes("//table/tbody/tr/td/div/select [contains(@id, \"idTipoLocalizacao\")] /option");
            foreach (var option in options)
            {
                combobox.Add(option.Attributes["value"].Value, option.InnerText);
            }
            return combobox;
        }
        #endregion
    }
}
