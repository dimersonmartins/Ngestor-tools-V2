using BotNetHome.App;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BotNetHome.Http.AllTerminaisEmpreiteira
{
    class GetResultRelatorio
    {

        public async Task<string[]> GetIndex()
        {
            string[] responseArray = null;
            try
            {
                HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
                client.Timeout = TimeSpan.FromHours(2);

                string[] Accept = new string[] { "image/gif", "image/jpeg", "image/pjpeg", "application/x-ms-application", "application/xaml+xml", "application/x-ms-xbap", "*/*" };
                string[] AcceptEncoding = new string[] { "gzip", "deflate" };

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", Accept);
                client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
                client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
                client.DefaultRequestHeaders.Add("Referer", "https://www.atlas.netservicos.com.br/nethome/index.do");
                client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
                client.DefaultRequestHeaders.Add("Host", "www.atlas.netservicos.com.br");
                client.DefaultRequestHeaders.Add("Cookie", Config.COOKIES[0] + "; " + Config.COOKIES[1] + "; " + Config.COOKIES[2]);
                client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                client.DefaultRequestHeaders.Add("X-Prototype-Version", "1.5.0");
                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                client.DefaultRequestHeaders.ExpectContinue = false;

                HttpResponseMessage response = await client.GetAsync("https://www.atlas.netservicos.com.br/nettask/singleSignOn.do?j_url=filas/filas.do?acao=prepareSearch&tipoConsulta=consultaId&menu=yes");
                var contents = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    client.Dispose();
                    return responseArray = new string[]
                        {
                        "true", contents
                        };
                }
                client.Dispose();
            }
            catch
            {
                return responseArray = new string[]
                    {
                        "false", "error"
                    };
            }
           
            return responseArray = new string[]
                    {
                        "false", "error"
                    }; 
        }

        public async Task<string[]> filas()
        {
            string[] responseArray = null;
            try
            {
                await GetIndex();

                HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
                client.Timeout = TimeSpan.FromHours(2);

                string[] Accept = new string[] { "text/javascript", "text/html", "application/xml", "text/xml", "*/*" };
                string[] AcceptEncoding = new string[] { "gzip", "deflate" };

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", Accept);
                client.DefaultRequestHeaders.Add("Accept-Language", "pt-br");
                client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
                client.DefaultRequestHeaders.Add("Referer", "https://www.atlas.netservicos.com.br/nettask/filas/filas.do?acao=prepareSearch&tipoConsulta=consultaId");
                client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
                client.DefaultRequestHeaders.Add("Host", "www.atlas.netservicos.com.br");
                client.DefaultRequestHeaders.Add("Cookie", Config.COOKIES[0] + "; " + Config.COOKIES[0] + "; " + Config.COOKIES[1] + "; " + Config.COOKIES[2]);
                client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                client.DefaultRequestHeaders.Add("X-Prototype-Version", "1.5.0");
                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                client.DefaultRequestHeaders.ExpectContinue = false;

                var content = new StringContent("acao=search&tipoConsulta=consultaId&opcao=id&idFilaDe=&idFilaAte=&filaId=&listIdFilas=" + Config.ID_TASK_RELATORIO + "&dbService=");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                content.Headers.ContentType.CharSet = "UTF-8";

                HttpResponseMessage response = await client.PostAsync("https://www.atlas.netservicos.com.br/nettask/filas/filas.do?acao=search&novaBusca=yes", content);
                var contents = await response.Content.ReadAsStringAsync();
                HttpContentHeaders headers = content.Headers;
                if (response.IsSuccessStatusCode)
                {
                    client.Dispose();
                    return responseArray = new string[]
                         {
                        "true", contents
                         };
                }
                client.Dispose();
            }
            catch
            {
                return responseArray = new string[]
                    {
                        "false", "error"
                    }; ;
            }
           
            return responseArray = new string[]
                    {
                        "false", "error"
                    }; ;
        }

        public async Task<string[]> filasDetalhes()
        {
            string[] responseArray = null;
            try
            {
                HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
                client.Timeout = TimeSpan.FromHours(2);

                string[] Accept = new string[] { "image/gif", "image/jpeg", "image/pjpeg", "application/x-ms-application", "application/xaml+xml", "application/x-ms-xbap", "*/*" };
                string[] AcceptEncoding = new string[] { "gzip", "deflate" };

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", Accept);
                client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
                client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
                client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
                client.DefaultRequestHeaders.Add("Host", "www.atlas.netservicos.com.br");
                client.DefaultRequestHeaders.Add("Cookie", Config.COOKIES[0] + "; " + Config.COOKIES[0] + "; " + Config.COOKIES[1] + "; " + Config.COOKIES[2]);
                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                client.DefaultRequestHeaders.ExpectContinue = false;

                HttpResponseMessage response = await client.GetAsync("https://www.atlas.netservicos.com.br/nettask/filas/detalhes.do?idFila=" + Config.ID_TASK_RELATORIO + "&status=3&tipoConsulta=consultaId&alterar=no&visualizado=false&carregar=yes");
                var contents = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    client.Dispose();
                    return responseArray = new string[]
                        {
                        "true", contents
                        };

                }
                client.Dispose();
            }
            catch
            {
                return responseArray = new string[]
                  {
                        "false", "error"
                  };
            }
            return responseArray = new string[]
                  {
                        "false", "error"
                  };
        }

        public async Task<string[]> buscarDadosFila()
        {

            string[] responseArray = null;
            try
            {
                await GetIndex();

                HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
                client.Timeout = TimeSpan.FromHours(2);

                string[] Accept = new string[] { "text/javascript", "text/html", "application/xml", "text/xml", "*/*" };
                string[] AcceptEncoding = new string[] { "gzip", "deflate" };

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", Accept);
                client.DefaultRequestHeaders.Add("Accept-Language", "pt-br");
                client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
                client.DefaultRequestHeaders.Add("Referer", "https://www.atlas.netservicos.com.br/nettask/filas/detalhes.do?idFila=" + Config.ID_TASK_RELATORIO + "&status=3&tipoConsulta=consultaId&alterar=no&visualizado=false&carregar=yes");
                client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
                client.DefaultRequestHeaders.Add("Host", "www.atlas.netservicos.com.br");
                client.DefaultRequestHeaders.Add("Cookie", Config.COOKIES[0] + "; " + Config.COOKIES[0] + "; " + Config.COOKIES[1] + "; " + Config.COOKIES[2]);
                client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                client.DefaultRequestHeaders.Add("X-Prototype-Version", "1.5.0");
                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                client.DefaultRequestHeaders.ExpectContinue = false;

                var content = new StringContent("acao=search&tipoConsulta=consultaId&opcao=id&idFilaDe=&idFilaAte=&filaId=&listIdFilas=" + Config.COOKIES[0] + "&dbService=");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                content.Headers.ContentType.CharSet = "UTF-8";

                HttpResponseMessage response = await client.PostAsync("https://www.atlas.netservicos.com.br/nettask/filas/dados.do?acao=buscarDadosFila&idFila=" + Config.ID_TASK_RELATORIO, content);
                var contents = await response.Content.ReadAsStringAsync();
                HttpContentHeaders headers = content.Headers;
                if (response.IsSuccessStatusCode)
                {
                    client.Dispose();
                    return responseArray = new string[]
                       {
                        "true", contents
                       };
                }
                client.Dispose();
            }
            catch
            {
                return responseArray = new string[]
                   {
                        "false", "error"
                   };
            }
           
            return responseArray = new string[]
                    {
                        "false", "error"
                    };
        }

        public async Task<string[]> hasResult()
        {
            string[] responseArray = null;

            try
            {
                await filasDetalhes();

                await buscarDadosFila();

                HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
                client.Timeout = TimeSpan.FromHours(2);

                string[] Accept = new string[] { "text/javascript", "text/html", "application/xml", "text/xml", "*/*" };
                string[] AcceptEncoding = new string[] { "gzip", "deflate" };

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", Accept);
                client.DefaultRequestHeaders.Add("Accept-Language", "pt-br");
                client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
                client.DefaultRequestHeaders.Add("Referer", "https://www.atlas.netservicos.com.br/nettask/filas/detalhes.do?idFila=" + Config.ID_TASK_RELATORIO + "&status=3&tipoConsulta=consultaId&alterar=no&visualizado=false&carregar=yes");
                client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
                client.DefaultRequestHeaders.Add("Host", "www.atlas.netservicos.com.br");
                client.DefaultRequestHeaders.Add("Cookie", Config.COOKIES[0] + "; " + Config.COOKIES[0] + "; " + Config.COOKIES[1] + "; " + Config.COOKIES[2]);
                client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                client.DefaultRequestHeaders.Add("X-Prototype-Version", "1.5.0");
                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");

                var content = new StringContent("idFila=" + Config.ID_TASK_RELATORIO + "&idAplicacao=&tipoConsulta=consultaId&dsOcorrenciaCancelar=&dsOcorrenciaVisualizar=&acao=&dbService=");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                content.Headers.ContentType.CharSet = "UTF-8";

                HttpResponseMessage response = await client.PostAsync("https://www.atlas.netservicos.com.br/nettask/filas/anexos.do?acao=buscarAnexos&idFila=" + Config.ID_TASK_RELATORIO, content);
                var contents = await response.Content.ReadAsStringAsync();
                HttpContentHeaders headers = content.Headers;
                if (response.IsSuccessStatusCode)
                {
                    client.Dispose();
                    return responseArray = new string[]
                        {
                        "true", contents
                        };
                }
                client.Dispose();
            }
            catch
            {
                return responseArray = new string[]
                   {
                        "false", "error"
                   };
            }
           
            return responseArray = new string[]
                    {
                        "false", "error"
                    };
        }
    }
}
