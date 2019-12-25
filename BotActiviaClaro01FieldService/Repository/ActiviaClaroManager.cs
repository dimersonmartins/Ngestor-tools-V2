using BotActiviaClaroFieldService.App;
using BotActiviaClaroFieldService.Http;
using BotActiviaClaroFieldService.Http.Auth;
using BotActiviaClaroFieldService.Http.QueryForStatus;
using BotNgestor.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotActiviaClaroFieldService.Repository
{
    public class ActiviaClaroManager
    {
        public static int count_os = 0;
        public static int percent = 0;
        private List<OrdensServicos> servicos = new List<OrdensServicos>();
        public static string statusActivia        = "Conectando..";
        public async Task<bool> connect()
        {
            try
            {
                AuthActiviaClaro auth = new AuthActiviaClaro();
                if (await auth.execute())
                {
                    statusActivia = "Conectado";
                    return true;
                }
            }
            catch
            {
                return false;
            }
           
            return false;
        }
        public async Task<bool> isConnected()
        {
            try
            {
                AuthActiviaClaro auth = new AuthActiviaClaro();
                return await auth.CheckConnection();
            }
            catch
            {
                return false;
            }
        }
        public async Task<string> PainelRoterizador(string data_incial, string data_final)
        {
            servicos.Clear();
            try
            {
                GetOrdersFromStatus getOrdersStatus = new GetOrdersFromStatus(null);
                statusActivia = "Extraindo Serviços";
                Roterizador roterizador = new Roterizador(data_incial, data_final);
                string activia_josn = await roterizador.GetOrders();
                if (!string.IsNullOrWhiteSpace(activia_josn))
                {
                    string data_result = activia_josn.Replace("[{", "{\"os_itens\": [{") + "}";
                    var obJsonFromRoterizador = JObject.Parse(data_result);
                    if (obJsonFromRoterizador != null)
                    {
                        foreach (var itemOs in obJsonFromRoterizador["os_itens"])
                        {
                            getOrdersStatus.osToNgestor.Add(itemOs["codigo"].ToString());
                        }

                        CheckOs ngestor = new CheckOs();
                        string data = string.Join(",", getOrdersStatus.osToNgestor);
                        string json = await ngestor.ordensServicos(Config.token_ngestor, Config.ngestor_url_server, data, "activia");

                        string osJsonFromNgestor = "{\"lista\": " + json + "}";
                        var obj = JObject.Parse(osJsonFromNgestor);
                        if (obj != null)
                        {
                            foreach (var contrato in obj["lista"])
                            {
                                getOrdersStatus.osFromNgestor.Add(contrato["num_os"].ToString());
                            }
                        }

                        foreach (var itemOs in obJsonFromRoterizador["os_itens"])
                        {
                            if (!getOrdersStatus.osFromNgestor.Contains(itemOs["codigo"].ToString()))
                            {
                                try
                                {
                                    count_os++;
                                    var ordemServicos = generateObjJson(itemOs);
                                    ordemServicos = await getOrdersStatus.executeFromRoterizador(ordemServicos, itemOs["codigo"].ToString());
                                    servicos.Add(ordemServicos);
                                    percent++;
                                }
                                catch
                                {
                                    continue;
                                }

                            }
                        }

                        string allOrders = JsonConvert.SerializeObject(servicos);
                        if (!string.IsNullOrWhiteSpace(allOrders))
                        {
                            string _json = "{\"os_itens\": " + allOrders + "}";
                            statusActivia = "Processo Finalizado";
                            return _json;
                        }
                    }
                }
            }
            catch
            {
                statusActivia = "Processo Finalizado";
                return "{\"os_itens\": " + "[{}]" + "}";
            }

            statusActivia = "Processo Finalizado";
            return "{\"os_itens\": " + "[{}]" + "}";
        }
        private OrdensServicos generateObjJson(JToken itemOs)
        {
            OrdensServicos ordemServicos = new OrdensServicos();
            try
            {
                ordemServicos.numeroOs = itemOs["codigo"].ToString();
                ordemServicos.dataAgendamento = itemOs["agendamento"].ToString();
                ordemServicos.periodoAgendamento = itemOs["periodo"].ToString();
                ordemServicos.credenciada = itemOs["credenciada"].ToString();
                ordemServicos.nomeEquipe = itemOs["tecnico"].ToString();
                ordemServicos.obsOS = itemOs["msgInformativa"].ToString();
                ordemServicos.node = itemOs["node"].ToString();
                ordemServicos.tipoOS = itemOs["resumoSolicitacao"].ToString();
                ordemServicos.status = "DESP CRED";
                ordemServicos.statusContrato = itemOs["contrato"]["status"].ToString();

                ordemServicos.numeroContrato = itemOs["contrato"]["codigo"].ToString();
                ordemServicos.nomeCliente = itemOs["contrato"]["nomeTitular"].ToString();
                ordemServicos.telRes = itemOs["contrato"]["telefones"]["residencia"].ToString();
                ordemServicos.telCom = itemOs["contrato"]["telefones"]["comercial"].ToString();
                ordemServicos.telOutros = itemOs["contrato"]["telefones"]["outros"].ToString();
                ordemServicos.telCel = itemOs["contrato"]["telefones"]["celular"].ToString();
                ordemServicos.tefFax = itemOs["contrato"]["telefones"]["fax"].ToString();

                ordemServicos.endereco = itemOs["endereco"]["logradouro"].ToString();
                ordemServicos.bairro = itemOs["endereco"]["bairro"].ToString();
                ordemServicos.cidade = itemOs["endereco"]["cidade"].ToString();
                ordemServicos.estado = itemOs["endereco"]["estado"].ToString();
                ordemServicos.cep = itemOs["endereco"]["cep"].ToString();
                ordemServicos.tipoEnd = itemOs["endereco"]["tipoEdificacao"].ToString();
            }
            catch { }

            return ordemServicos;
        }
        public async Task<string> OrdersForStatus(string data_inicial, string status, int tipo_acao)
        {
            try
            {
                string osJson = "{\"os_itens\": ";
                string json = "";
                if (tipo_acao == 1)
                {
                    GetOrdersFromStatus.total_r_processadas = 0;
                    GetOrdersFromStatus.total_requisicoes = 0;
                    ConsultarOSParamenters oSParamenters = new ConsultarOSParamenters();
                    oSParamenters.curPage = "1";
                    oSParamenters.dataAgendamento = data_inicial;
                    oSParamenters.statusOS = status;
                    GetOrdersFromStatus getOrdersStatus = new GetOrdersFromStatus(oSParamenters);
                    json = await getOrdersStatus.executeImporteNgestor();
                }
                if (tipo_acao == 2)
                {
                    GetOrdersFromStatus.total_r_processadasExcel = 0;
                    GetOrdersFromStatus.total_requisicoesExcel = 0;
                    ConsultarOSParamenters oSParamenters = new ConsultarOSParamenters();
                    oSParamenters.curPage = "1";
                    oSParamenters.dataAgendamento = data_inicial;
                    oSParamenters.statusOS = status;
                    GetOrdersFromStatus getOrdersStatus = new GetOrdersFromStatus(oSParamenters);
                    json = await getOrdersStatus.extracaoToExcelSimples();
                }
                if (tipo_acao == 3)
                {
                    GetOrdersFromStatus.total_r_processadasExcel = 0;
                    GetOrdersFromStatus.total_requisicoesExcel = 0;
                    ConsultarOSParamenters oSParamenters = new ConsultarOSParamenters();
                    oSParamenters.curPage = "1";
                    oSParamenters.dataAgendamento = data_inicial;
                    oSParamenters.statusOS = status;
                    GetOrdersFromStatus getOrdersStatus = new GetOrdersFromStatus(oSParamenters);
                    json = await getOrdersStatus.extracaoToExcelCompleta();

                }
                osJson += json + "}";
                return osJson;
            }
            catch
            {
                return "{\"os_itens\": " + "[{}]" + "}";
            }

        }

        public static int[] processOrdersForRoterizador()
        {
            return new int[]
            {
                count_os,
                percent
            };
        }

        public static int[] processOrdersForStatus()
        {
            return new int[]
            {
                GetOrdersFromStatus.total_requisicoes,
                GetOrdersFromStatus.total_r_processadas
            };
        }
        public static int[] processOrdersForStatusExcel()
        {
            return new int[]
            {
                GetOrdersFromStatus.total_requisicoesExcel,
                GetOrdersFromStatus.total_r_processadasExcel
            };
        }
    }
}
