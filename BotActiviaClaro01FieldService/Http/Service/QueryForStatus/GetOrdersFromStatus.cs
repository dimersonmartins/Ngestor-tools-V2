using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BotActiviaClaroFieldService.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BotNgestor.Http;

namespace BotActiviaClaroFieldService.Http.QueryForStatus
{
    class GetOrdersFromStatus
    {
        public GetOrdersFromStatus(ConsultarOSParamenters oSParamenters)
        {
           this._oSParamenters = oSParamenters;
        }
        private ConsultarOSParamenters _oSParamenters = null;
        public string total_paginas;
        public int current_page = 1;
      
        private string html;
        public static int total_r_processadas   = 0;
        public static int total_requisicoes     = 0;
        public static int total_r_processadasExcel = 0;
        public static int total_requisicoesExcel = 0;

        private List<OrdensServicos> servicos = new List<OrdensServicos>();
        public List<string> osFromNgestor     = new List<string>();
        public List<string> osToNgestor       = new List<string>();

        public async Task<OrdensServicos> executeFromRoterizador(OrdensServicos ordemServicos, string num_os)
        {
            ConsultarOSParamenters oSParamenters = new ConsultarOSParamenters();
            if (!osFromNgestor.Contains(num_os))
            {
                oSParamenters.curPage           = "";
                oSParamenters.codOS             = num_os;
                oSParamenters.dataAgendamento   = "";
                oSParamenters.opDataAgendamento = "=";
                oSParamenters.method            = "resultadoBuscaOs";
                _oSParamenters                  = oSParamenters;

                try
                {
                    string dados_httml = await GetDadosContrato(num_os, 299);
                    ordemServicos = listPrincipal(dados_httml, ordemServicos);
                    servicos.Add(ordemServicos);
                }
                catch { }           
            }                

            return ordemServicos;
        }

        public async Task<string> executeImporteNgestor()
        {
           
            string html = await GetOrdersFormStatus();

            for (int i = 0; i < int.Parse(total_paginas); i++)
            {
                current_page++;

                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(html);

                var node_tr = htmlDoc.DocumentNode.SelectNodes("//table/tr");

                if (node_tr == null)
                {
                    return null;
                }

                await readHtmlPrincipal(html);
                foreach (var tr in node_tr)
                {

                    var node_td = tr.SelectNodes("td");

                    //remove a primeira tr
                    if (tr.SelectNodes(".//img [contains(@src, \"img/act/1by1.gif\")]") != null)
                    {
                        continue;
                    }

                    if (node_td == null)
                    {
                        continue;
                    }

                    var tdArray = node_td.ToArray();
                    // remove as ultimas trs
                    if (tdArray.Length < 5)
                    {
                        tr.RemoveAll();
                    }

                    var lista = criarArray(node_td);

                    try
                    {
                        if (!osFromNgestor.Contains(lista[11].Value))
                        {
                            OrdensServicos ordemServicos = new OrdensServicos();
                            ordemServicos.numeroOs = lista[11].Value;
                            ordemServicos.numeroContrato = lista[12].Value;
                            ordemServicos.tipoOS = lista[14].Value;
                            ordemServicos.nomeCliente = lista[6].Value;
                            ordemServicos.node = lista[7].Value;
                            ordemServicos.status = lista[4].Value;
                           // ordemServicos.dataSolicitacao = lista[15].Value;
                            ordemServicos.dataAgendamento = lista[16].Value;
                            ordemServicos.periodoAgendamento = lista[34].Value;
                            ordemServicos.credenciada = lista[36].Value;
                            ordemServicos.nomeEquipe = lista[37].Value;

                            string dados_httml = await GetDadosContrato(lista[11].Value, 3530001);
                            Request activiaRequestContratoEndereco = new Request(3530001);

                            ordemServicos = listPrincipal(dados_httml, ordemServicos);

                            MontedUrl montedUrl = new MontedUrl();

                            string endereco_url = montedUrl.create(dados_httml, "endereco");
                            string endereco_html = await activiaRequestContratoEndereco.contatro_Endereco(endereco_url, ordemServicos.numeroOs);
                            ordemServicos = listEndereco(endereco_html, ordemServicos);

                            string contrato_url = montedUrl.create(dados_httml, "contrato");
                            string contrato_html = await activiaRequestContratoEndereco.contatro_Endereco(contrato_url, ordemServicos.numeroOs);
                            ordemServicos = listContrato(contrato_html, ordemServicos);

                            servicos.Add(ordemServicos);
                        }
                    }
                    catch
                    {
                        continue;
                    }

                }

                html = await GetOrdersFormStatus();

                total_r_processadas++;
            }

            string os_json = JsonConvert.SerializeObject(servicos);
          
            return os_json;
        }

        public async Task<string> extracaoToExcelCompleta()
        {
           
            string html = await GetOrdersFormStatus();

            for (int i = 0; i < int.Parse(total_paginas); i++)
            {
                current_page++;

                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(html);

                var node_tr = htmlDoc.DocumentNode.SelectNodes("//table/tr");

                if (node_tr == null)
                {
                    return null;
                }

                foreach (var tr in node_tr)
                {

                    var node_td = tr.SelectNodes("td");

                    //remove a primeira tr
                    if (tr.SelectNodes(".//img [contains(@src, \"img/act/1by1.gif\")]") != null)
                    {
                        continue;
                    }

                    if (node_td == null)
                    {
                        continue;
                    }

                    var tdArray = node_td.ToArray();
                    // remove as ultimas trs
                    if (tdArray.Length < 5)
                    {
                        tr.RemoveAll();
                    }

                    var lista = criarArray(node_td);

                    try
                    {
                        OrdensServicos ordemServicos = new OrdensServicos();
                        ordemServicos.numeroOs = lista[11].Value;
                        ordemServicos.numeroContrato = lista[12].Value;
                        ordemServicos.tipoOS = lista[14].Value;
                        ordemServicos.nomeCliente = lista[6].Value;
                        ordemServicos.node = lista[7].Value;
                        ordemServicos.status = lista[4].Value;
                        // ordemServicos.dataSolicitacao = lista[15].Value;
                        ordemServicos.dataAgendamento = lista[16].Value;
                        ordemServicos.periodoAgendamento = lista[34].Value;
                        ordemServicos.credenciada = lista[36].Value;
                        ordemServicos.nomeEquipe = lista[37].Value;

                        string dados_httml = await GetDadosContrato(lista[11].Value, 3530001);
                        Request activiaRequestContratoEndereco = new Request(3530001);

                        ordemServicos = listPrincipal(dados_httml, ordemServicos);

                        MontedUrl montedUrl = new MontedUrl();

                        string endereco_url = montedUrl.create(dados_httml, "endereco");
                        string endereco_html = await activiaRequestContratoEndereco.contatro_Endereco(endereco_url, ordemServicos.numeroOs);
                        ordemServicos = listEndereco(endereco_html, ordemServicos);

                        string contrato_url = montedUrl.create(dados_httml, "contrato");
                        string contrato_html = await activiaRequestContratoEndereco.contatro_Endereco(contrato_url, ordemServicos.numeroOs);
                        ordemServicos = listContrato(contrato_html, ordemServicos);

                        servicos.Add(ordemServicos);

                    }
                    catch
                    {
                        continue;
                    }

                }

                html = await GetOrdersFormStatus();

                total_r_processadasExcel++;
            }

            string os_json = JsonConvert.SerializeObject(servicos);
           
            return os_json;

        }

        public async Task<string> extracaoToExcelSimples()
        {
            string html = await GetOrdersFormStatus();

            for (int i = 0; i < int.Parse(total_paginas); i++)
            {
                current_page++;

                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(html);

                var node_tr = htmlDoc.DocumentNode.SelectNodes("//table/tr");

                if (node_tr == null)
                {
                    return null;
                }

                foreach (var tr in node_tr)
                {

                    var node_td = tr.SelectNodes("td");

                    //remove a primeira tr
                    if (tr.SelectNodes(".//img [contains(@src, \"img/act/1by1.gif\")]") != null)
                    {
                        continue;
                    }

                    if (node_td == null)
                    {
                        continue;
                    }

                    var tdArray = node_td.ToArray();
                    // remove as ultimas trs
                    if (tdArray.Length < 5)
                    {
                        tr.RemoveAll();
                    }

                    var lista = criarArray(node_td);

                    try
                    {
                        OrdensServicos ordemServicos = new OrdensServicos();
                        ordemServicos.numeroOs = lista[11].Value;
                        ordemServicos.numeroContrato = lista[12].Value;
                        ordemServicos.tipoOS = lista[14].Value;
                        ordemServicos.nomeCliente = lista[6].Value;
                        ordemServicos.node = lista[7].Value;
                        ordemServicos.status = lista[4].Value;
                        // ordemServicos.dataSolicitacao = lista[15].Value;
                        ordemServicos.dataAgendamento = lista[16].Value;
                        ordemServicos.periodoAgendamento = lista[34].Value;
                        ordemServicos.credenciada = lista[36].Value;
                        ordemServicos.nomeEquipe = lista[37].Value;

                        servicos.Add(ordemServicos);
                    }
                    catch
                    {
                        continue;
                    }

                }

                html = await GetOrdersFormStatus();

                total_r_processadasExcel++;
            }

            string os_json = JsonConvert.SerializeObject(servicos);
            return os_json;
        }

        private async Task<bool> readHtmlPrincipal(string html)
        {

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);
            var node_tr = htmlDoc.DocumentNode.SelectNodes("//table/tr");

            foreach (var tr in node_tr)
            {

                var node_td = tr.SelectNodes("td");

                //remove a primeira tr
                if (tr.SelectNodes(".//img [contains(@src, \"img/act/1by1.gif\")]") != null)
                {
                    continue;
                }

                if (node_td == null)
                {
                    continue;
                }

                var tdArray = node_td.ToArray();
                // remove as ultimas trs
                if (tdArray.Length < 5)
                {
                    tr.RemoveAll();
                }

                var lista = criarArray(node_td);
            }
            CheckOs ngestorCheckOs = new CheckOs();

            string data = string.Join(",", osToNgestor);
            string json = await ngestorCheckOs.ordensServicos(Config.token_ngestor, Config.ngestor_url_server, data, "activia");

            string osJson = "{\"lista\": ";
            osJson += json;
            osJson += "}";
            var obj = JObject.Parse(osJson);
            foreach (var contrato in obj["lista"])
            {
                osFromNgestor.Add(contrato["num_os"].ToString());
            }

            return true;
        }
        private OrdensServicos listPrincipal(string dados_html, OrdensServicos ordemServicos)
        {
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(dados_html);
            try
            {
                var produtoNovo_node  = htmlDoc.DocumentNode.SelectSingleNode("//input[@name='ref_T_actprodutonovo']");
                var produtoAtual_node = htmlDoc.DocumentNode.SelectSingleNode("//input[@name='ref_T_actprodutoatual']");
                var obsOS_node        = htmlDoc.DocumentNode.SelectSingleNode("//textarea[@name='ref_T_actobs']");
                var data_solicitacao  = htmlDoc.DocumentNode.SelectSingleNode("//input[@name='ref_D_actdatasolicitacao']");

                ordemServicos.produtoNovo       = produtoNovo_node.Attributes["value"].Value;
                ordemServicos.produtoAtual      = produtoAtual_node.Attributes["value"].Value;
                ordemServicos.obsOS             = obsOS_node.InnerText;
                ordemServicos.dataSolicitacao   = data_solicitacao.Attributes["value"].Value;

                var content                     = htmlDoc.DocumentNode.SelectNodes("//table/tr/td[contains(@class, \"celulaBG2\")]/input");
                ordemServicos.tipoTecnologia    = content[19].Attributes["value"].Value;

            }
            catch (Exception)
            {
                return ordemServicos;
            }


            return ordemServicos;
        }

        private OrdensServicos listContrato(string dados_html, OrdensServicos ordemServicos)
        {
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(dados_html);
            try
            {
                var content             = htmlDoc.DocumentNode.SelectNodes("//table/tr/td[contains(@class, \"celulaBG2\")]/input");
                ordemServicos.rg        = content[4].Attributes["value"].Value;
                ordemServicos.cpf       = content[5].Attributes["value"].Value;
                ordemServicos.telRes    = content[6].Attributes["value"].Value;
                ordemServicos.telCom    = content[8].Attributes["value"].Value;
                ordemServicos.telOutros = content[7].Attributes["value"].Value;
                ordemServicos.telCel    = content[9].Attributes["value"].Value;
                ordemServicos.tefFax    = content[10].Attributes["value"].Value;
            }
            catch
            {
                return ordemServicos;
            }
            return ordemServicos;
        }

        private OrdensServicos listEndereco(string dados_html, OrdensServicos ordemServicos)
        {
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(dados_html);
            try
            {
                var endereco = htmlDoc.DocumentNode.SelectNodes("//table/tr/td/table/tr/td")[12];
                var tipo     = htmlDoc.DocumentNode.SelectNodes("//table/tr/td/table/tr/td")[14];
                var cep      = htmlDoc.DocumentNode.SelectNodes("//table/tr/td/table/tr/td")[15];
                var bairro   = htmlDoc.DocumentNode.SelectNodes("//table/tr/td/table/tr/td")[16];
                var cidade   = htmlDoc.DocumentNode.SelectNodes("//table/tr/td/table/tr/td")[17];
                var estado   = htmlDoc.DocumentNode.SelectNodes("//table/tr/td/table/tr/td")[18];

                ordemServicos.endereco  = endereco.InnerText;
                ordemServicos.tipoEnd   = tipo.InnerText;
                ordemServicos.cep       = cep.InnerText;
                ordemServicos.bairro    = bairro.InnerText;
                ordemServicos.cidade    = cidade.InnerText;
                ordemServicos.estado    = estado.InnerText;

            }
            catch
            {
                return ordemServicos;
            }


            return ordemServicos;
        }

        private List<KeyValuePair<int, string>> criarArray(HtmlAgilityPack.HtmlNodeCollection htmlNode)
        {
            List<KeyValuePair<int, string>> lista = new List<KeyValuePair<int, string>>();
            int key = 0;

            foreach (var item in htmlNode)
            {
                lista.Add(new KeyValuePair<int, string>(key, item.InnerText));
                if (key == 11)
                {
                    if (!osToNgestor.Contains(item.InnerText))
                    {
                        osToNgestor.Add(item.InnerText);
                    }
                   
                }
                key++;
            }
            return lista;
        }
        public async Task<string> GetOrdersFormStatus()
        {
            string useragent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:52.0) Gecko/20100101 Firefox/52.0";
            HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            client.Timeout = TimeSpan.FromHours(2);

            client.DefaultRequestHeaders.Clear();

            Dictionary<string, string> form_data = new Dictionary<string, string>
            {
                {"cliente",             _oSParamenters.cliente},
                {"codOS",               _oSParamenters.codOS},
                {"contrato",            _oSParamenters.contrato},
                {"credenciada",         _oSParamenters.credenciada},
                {"curPage",             $"{current_page}"},
                {"dataAgendamento",     _oSParamenters.dataAgendamento},
                {"dataBaixa",           _oSParamenters.dataBaixa},
                {"dataDespacho",        _oSParamenters.dataDespacho},
                {"dataDespCred",        _oSParamenters.dataDespCred},
                {"dataProgExecucao",    _oSParamenters.dataProgExecucao},
                {"dataRotCred",         _oSParamenters.dataRotCred},
                {"dataRotEqp",          _oSParamenters.dataRotEqp},
                {"dataSolicitacao",     _oSParamenters.dataSolicitacao},
                {"emergencia",          _oSParamenters.emergencia},
                {"equipe",              _oSParamenters.equipe},
                {"equipeId",            _oSParamenters.equipeId},
                {"method",              _oSParamenters.method},
                {"mostrarMinhasOSs",    _oSParamenters.mostrarMinhasOSs},
                {"node",                _oSParamenters.node},
                {"opCliente",           _oSParamenters.opCliente},
                {"opCodOS",             _oSParamenters.opCodOS },
                {"opContrato",          _oSParamenters.opContrato },
                {"opCorporativo",       _oSParamenters.opCorporativo },
                {"opCredenciada",       _oSParamenters.opCredenciada },
                {"opDataAgendamento",   _oSParamenters.opDataAgendamento },
                {"opDataBaixa",         _oSParamenters.opDataBaixa },
                {"opDataDespacho",      _oSParamenters.opDataDespacho },
                {"opDataDespCred",      _oSParamenters.opDataDespCred },
                {"opDataProgExecucao",  _oSParamenters.opDataProgExecucao },
                {"opDataRotCred",       _oSParamenters.opDataRotCred },
                {"opDataRotEqp",        _oSParamenters.opDataRotEqp } ,
                {"opDataSolicitacao",   _oSParamenters.opDataSolicitacao },
                {"opEmergencia",        _oSParamenters.opEmergencia },
                {"opEquipe",            _oSParamenters.opEquipe},
                {"opEquipeId",          _oSParamenters.opEquipeId},
                {"operadora",           _oSParamenters.operadora } ,
                {"opNode",              _oSParamenters.opNode},
                {"opOperadora",         _oSParamenters.opOperadora},
                {"opStatusOS",          _oSParamenters.opStatusOS },
                {"opStatusSLA",         _oSParamenters.opStatusSLA },
                {"opTipoOS",            _oSParamenters.opTipoOS},
                {"osCorporativo",       _oSParamenters.osCorporativo},
                {"statusOS",            _oSParamenters.statusOS},
                {"statusSLA",           _oSParamenters.statusSLA},
                {"tipoOS",              _oSParamenters.tipoOS}
            };

            string[] AcceptGetOrdersActivia = new string[] { "application/xhtml+xml", "text/plain", "application/xml;q=0.9", "image/webp", "image/apng", "*/*" };
            string[] AcceptEncodingGetOrdersActivia = new string[] { "gzip", "deflate", "br" };
            string[] AcceptLanguageGetOrdersActivia = new string[] { "pt-BR", "pt;q=0.9", "en-US;q=0.8", "en;q=0.7" };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", AcceptGetOrdersActivia);
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncodingGetOrdersActivia);
            client.DefaultRequestHeaders.Add("Accept-Language", AcceptLanguageGetOrdersActivia);
            client.DefaultRequestHeaders.Add("Host", "clarofs.iclass.com.br");
            client.DefaultRequestHeaders.Add("Referer", "https://clarofs.iclass.com.br/activiafs/buscaosarq.do?method=frameBuscaOsArq");
            client.DefaultRequestHeaders.Add("User-Agent", useragent);

            string cookie = "";
            foreach (var coolies in Config.CookiesFromngestor_url_server)
            {
                client.DefaultRequestHeaders.Add("Cookie", $"{coolies.Key}={coolies.Value}");
                cookie = $"{coolies.Key}={coolies.Value}";
            }

            HttpContent content = new FormUrlEncodedContent(form_data);

            HttpResponseMessage response = await client.PostAsync("https://clarofs.iclass.com.br/activiafs/buscaosarq.do", content);
            var contents = await response.Content.ReadAsStringAsync();
            HttpContentHeaders headers = content.Headers;

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                    htmlDoc.LoadHtml(contents);

                    var node = htmlDoc.DocumentNode.SelectSingleNode("//input[@name='totalPaginas']");
                    total_paginas = node.Attributes["value"].Value;

                    html = contents;
                    total_requisicoes      = int.Parse(total_paginas);
                    total_requisicoesExcel = int.Parse(total_paginas);
                    return contents;
                }
                catch (Exception ex)
                {
                    return "Conexão indisponivel!" + ex.Message;
                }
            }
            else
            {
                return "Ocorreu um erro!";
            }
        }
        public async Task<string> GetDadosContrato(string num_os, int tipoForm)
        {
            string useragent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:52.0) Gecko/20100101 Firefox/52.0";
            HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            client.Timeout = TimeSpan.FromHours(2);

            client.DefaultRequestHeaders.Clear();

            string[] AcceptGetOrdersActivia = new string[] { "application/xhtml+xml", "text/plain", "application/xml;q=0.9", "image/webp", "image/apng", "*/*" };
            string[] AcceptEncodingGetOrdersActivia = new string[] { "gzip", "deflate", "br" };
            string[] AcceptLanguageGetOrdersActivia = new string[] { "pt-BR", "pt;q=0.9", "en-US;q=0.8", "en;q=0.7" };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", AcceptGetOrdersActivia);
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncodingGetOrdersActivia);
            client.DefaultRequestHeaders.Add("Accept-Language", AcceptLanguageGetOrdersActivia);
            client.DefaultRequestHeaders.Add("Host", "clarofs.iclass.com.br");
            client.DefaultRequestHeaders.Add("Referer", "https://clarofs.iclass.com.br/activiafs/buscaosarq.do");
            client.DefaultRequestHeaders.Add("User-Agent", useragent);

            string cookie = "";
            foreach (var coolies in Config.CookiesFromngestor_url_server)
            {
                client.DefaultRequestHeaders.Add("Cookie", $"{coolies.Key}={coolies.Value}");
                cookie = $"{coolies.Key}={coolies.Value}";
            }

            Dictionary<string, string> form_data = new Dictionary<string, string>();
            HttpContent content = new FormUrlEncodedContent(form_data);

            HttpResponseMessage response = await client.GetAsync("https://clarofs.iclass.com.br/activiafs/Gerente?hid_Acao=principalresultado&hid_IdObj="+ tipoForm + "&hid_MeuId=2121" + num_os);
            var contents = await response.Content.ReadAsStringAsync();
            HttpContentHeaders headers = content.Headers;

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    return contents;
                }
                catch (Exception ex)
                {
                    return "Conexão indisponivel!" + ex.Message;
                }
            }
            else
            {
                return "Ocorreu um erro!";
            }
        }
    }
}
