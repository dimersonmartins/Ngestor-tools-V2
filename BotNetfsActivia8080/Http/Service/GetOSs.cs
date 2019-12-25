using BotNetfsActivia8080.App;
using BotNetfsActivia8080.Http.XmlToObject;
using BotNetfsActivia8080.Http.XmlToObject.XMLRoot.Service;
using BotNetfsActivia8080.Repository;
using Helpers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BotNetfsActivia8080.Http.Service
{
    public class GetOSs
    {
        private List<OrdensServicos> servicos = new List<OrdensServicos>();
        public async Task<List<OrdensServicos>> execute()
        {
            try
            {
                string XML = await GetOrdersFromNetfs();
                Root Matirz_orders = ReadXmlParseObj.Deserialize<Root>(XML);

                NetfsActivia8080Manager.totalServicos = int.Parse(Matirz_orders.Listaos.Count);

                foreach (var os in Matirz_orders.Listaos.Os)
                {
                    OrdensServicos ordensServicos = new OrdensServicos();
                    ordensServicos.nomeCliente          = os.Contrato.Titular;
                    ordensServicos.numeroOs             = os.Codigo;
                    ordensServicos.numeroContrato       = os.Contrato.Numero;
                    ordensServicos.credenciada          = os.Credenciada;
                    ordensServicos.tipoOS               = os.Resumoos;
                    ordensServicos.dataSolicitacao      = os.Solicitacao;
                    ordensServicos.dataAgendamento      = os.Agendamento;
                    ordensServicos.periodoAgendamento   = os.Periodo;

                    ordensServicos.node         = os.Node;
                    ordensServicos.obsOS        = os.Obs;
                    ordensServicos.nomeEquipe   = os.Tecnico;
                    ordensServicos.segmentacao  = os.Contrato.Segmentacao;

                    ordensServicos.endereco     = os.Contrato.Endereco;
                    ordensServicos.bairro       = os.Contrato.Bairro;
                    ordensServicos.cep          = os.Contrato.Cep;
                    ordensServicos.cidade       = os.Contrato.Cidade;
                    ordensServicos.edificacao   = os.Edificacao;

                    string[] telefones = os.Contrato.Telefone.Split(',');
                    try
                    {
                        ordensServicos.telCel    = telefones[0];
                        ordensServicos.telCom    = telefones[1];
                        ordensServicos.telRes    = telefones[2];
                        ordensServicos.telOutros = telefones[3];
                        ordensServicos.tefFax    = telefones[4];
                    }
                    catch { }

                    string dados_httml = await GetDadosContrato(os.Id, 300325);
                    ordensServicos = listPrincipal(dados_httml, ordensServicos);
                    servicos.Add(ordensServicos);

                    NetfsActivia8080Manager.countPercent++;
                }

                return servicos;
            }
            catch { }
         
            return null;
        }

        private async Task<string> GetDadosContrato(string num_os, int tipoform)
        {
            HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            client.Timeout = TimeSpan.FromHours(2);

            client.DefaultRequestHeaders.Clear();

            string[] AcceptGetOrdersActivia = new string[] { "text/html", "application/xhtml+xml", "image/jxr", "*/*" };
            string[] AcceptEncodingGetOrdersActivia = new string[] { "gzip", "deflate", "br" };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", AcceptGetOrdersActivia);
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncodingGetOrdersActivia);
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            client.DefaultRequestHeaders.Add("Cookie", Config.JSESSIONID);

            HttpResponseMessage response = await client.GetAsync("http://netfs.activia.com.br:8080/activiafs/Gerente?hid_Acao=Abreformulario&hid_IdForm="+tipoform+"&hid_MeuId="+num_os);
            var contents = await response.Content.ReadAsStringAsync();
            
            if (response.IsSuccessStatusCode)
            {
                return contents;
            }

            return null;
        }

        private OrdensServicos listPrincipal(string dados_html, OrdensServicos ordemServicos)
        {
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(dados_html);
            try
            {
                var produtoNovo_node            = htmlDoc.DocumentNode.SelectSingleNode("//input[@name='ref_T_actprodutonovo']");
                var produtoAtual_node           = htmlDoc.DocumentNode.SelectSingleNode("//input[@name='ref_T_actprodutoatual']");
                var obsOS_node                  = htmlDoc.DocumentNode.SelectSingleNode("//textarea[@name='ref_T_actobs']");
                var data_solicitacao            = htmlDoc.DocumentNode.SelectSingleNode("//input[@name='ref_D_actdatasolicitacao']");

                ordemServicos.produtoNovo       = produtoNovo_node.Attributes["value"].Value;
                ordemServicos.produtoAtual      = produtoAtual_node.Attributes["value"].Value;
                ordemServicos.obsOS             = obsOS_node.InnerText;
                ordemServicos.dataSolicitacao   = data_solicitacao.Attributes["value"].Value;
            }
            catch
            {
                return ordemServicos;
            }

            return ordemServicos;
        }
        public async Task<string> GetOrdersFromNetfs()
        {       
            try
            {
                GenerateKey generateKey = new GenerateKey();
                string url = @"http://netfs.activia.com.br:8080/activiafs/roteirizadornetv2.do?mostrarDespachadaPleno=false&mostrarDespachadaEquipe=true&mostrarRoteadaEquipe=true&mostrarDespachadaCredenciada=true&mostrarRoteadaCredenciada=true&mostrarNaoRoteada=true&mostrarImediata=true&mostrarConveniencia=true&mostrarSlaRoxo=true&mostrarSlaVermelho=true&mostrarSlaAmarelo=true&mostrarSlaVerde=true&contratoTodos=true&codOSTodos=true&nodeTodos=true&regiaoTodas=true&tipoOSTodos=true&areaTodas=true&segmentacaoTodas=true&grupoTodas=true&equipeTodas=true&credenciadaTodas=true&filtrarDataProgExecucao=false&filtrarDataAgendamento=true&dataProgExecucaoFiltro=" + DateTime.Now.ToShortDateString() + "&dataTodas=false&data=" + DateTime.Now.ToShortDateString() + "&curPage=NaN&operadoraId=696&method=listaOSSemEquipe&%5F%5Flzbc%5F%5F=" + generateKey.NumberKey(13);
                HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
                client.Timeout = TimeSpan.FromHours(2);

                string[] AcceptEncoding = new string[] { "gzip", "deflate" };

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "*/*");
                client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
                client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
                client.DefaultRequestHeaders.Add("Host", "netfs.activia.com.br:8080");
                client.DefaultRequestHeaders.Add("x-flash-version", " 32,0,0,114");
                client.DefaultRequestHeaders.Add("Referer", "http://netfs.activia.com.br:8080/activiafs/swf/roteirizadornetv2.lzx.swf?lzproxied=false");
                client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
                client.DefaultRequestHeaders.Add("Cookie", Config.JSESSIONID);
                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");

                HttpResponseMessage response = await client.GetAsync(url);
                var contents = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return contents;
                }
            }
            catch
            {
                return null;
            }
           
            return null;
        }
    }
}
