using DataBase;
using Newtonsoft.Json.Linq;
using NgestorFieldServiceTools.App;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NgestorFieldServiceTools.View.Componentes.Relatorio.Controllers
{
    class FieldService
    {
        public FieldService(string tipoSistema)
        {
            _tipoSistema = tipoSistema;
        }

        private string _tipoSistema = null;

        private string pathFile = Path.GetTempPath();
        private string fileNameExcel = "\\" +
           DateTime.Now.ToString()
          .Replace("-", "")
          .Replace(":", "")
          .Replace("/", "")
          .Replace(" ", "") + ".csv";

        public bool status = false;
        public string lastFileName = null;
#pragma warning disable CS1998 // Este método assíncrono não possui operadores 'await' e será executado de modo síncrono. É recomendável o uso do operador 'await' para aguardar chamadas à API desbloqueadas ou do operador 'await Task.Run(...)' para realizar um trabalho associado à CPU em um thread em segundo plano.
        public async void execute()
#pragma warning restore CS1998 // Este método assíncrono não possui operadores 'await' e será executado de modo síncrono. É recomendável o uso do operador 'await' para aguardar chamadas à API desbloqueadas ou do operador 'await Task.Run(...)' para realizar um trabalho associado à CPU em um thread em segundo plano.
        {
            create();
        }
#pragma warning disable CS1998 // Este método assíncrono não possui operadores 'await' e será executado de modo síncrono. É recomendável o uso do operador 'await' para aguardar chamadas à API desbloqueadas ou do operador 'await Task.Run(...)' para realizar um trabalho associado à CPU em um thread em segundo plano.
        private async void create()
#pragma warning restore CS1998 // Este método assíncrono não possui operadores 'await' e será executado de modo síncrono. É recomendável o uso do operador 'await' para aguardar chamadas à API desbloqueadas ou do operador 'await Task.Run(...)' para realizar um trabalho associado à CPU em um thread em segundo plano.
        {

            if (_tipoSistema == "field")
            {
                field();
            }

            if (_tipoSistema == "activia")
            {
                activia();
            }
          
        }
        private void activia()
        {

            try
            {
                DbMain db = new DbMain("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "Manager");
                var datatable = db.Query($"SELECT * FROM ordens_de_servicos WHERE id_dominio_ngestor = '{Config.id_dominio_ngestor}' AND id_sistemas_tipo = {Config.id_operadora_servidor}");

                string osJson = "{\"os_itens\": [";
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    var obj = JObject.Parse(datatable.Rows[i][6].ToString());
                    osJson += obj["os"][0].ToString() + ",";
                }
                osJson += "]}";
                var obJson = JObject.Parse(osJson);

                    StringBuilder csv = new StringBuilder();
                    //CSV HEADER
                    csv.AppendLine("OS; " +
                        "CONTRATO; " +
                        "STATUS; " +
                        "CLIENTE; " +
                        "ENDERECO; " +
                        "BAIRRO; " +
                        "CIDADE; " +
                        "TELEFONES; " +
                        "TIPO OS; " +
                        "PRODUTO ATUAL; " +
                        "PRODUTO NOVO; " +
                        "DATA SOLICITACAO; " +
                        "PERIODO; " +
                        "STATUS CONTRATO; ");
                    Thread thread = new Thread(() =>
                    {
                            foreach (var itemOs in obJson["os_itens"])
                            {
                                string telefones = montedTelefones(itemOs["telCel"].ToString(), itemOs["telRes"].ToString());

                                csv.AppendLine($"{itemOs["numeroOs"].ToString()};" +
                                    $"{itemOs["numeroContrato"].ToString()};" +
                                    $"{itemOs["status"].ToString()};" +
                                    $"{itemOs["nomeCliente"].ToString()};" +
                                    $"{itemOs["endereco"].ToString()};" +
                                    $"{itemOs["bairro"].ToString()};" +
                                    $"{itemOs["cidade"].ToString()};" +
                                    $"{telefones};" +
                                    $"{itemOs["tipoOS"].ToString()};" +
                                    $"{itemOs["produtoAtual"].ToString()};" +
                                    $"{itemOs["produtoNovo"].ToString()};" +
                                    $"{itemOs["dataSolicitacao"].ToString()};" +
                                    $"{itemOs["periodoAgendamento"].ToString()};" +
                                    $"{itemOs["statusContrato"].ToString()};");
                            }

                        lastFileName = pathFile + fileNameExcel;
                        File.WriteAllText(lastFileName, csv.ToString());
                        status = true;
                    })
                    { IsBackground = true }; thread.Start(); 

            }
            catch
            {
                status = false;
            }
            

         
        }

        private string montedTelefones(string celular, string residencial)
        {
            if (!string.IsNullOrWhiteSpace(celular) && !string.IsNullOrWhiteSpace(residencial))
            {
                return $"{celular} / {residencial}";
            }
            if (!string.IsNullOrWhiteSpace(celular))
            {
                return celular;
            }
            if (!string.IsNullOrWhiteSpace(residencial))
            {
                return residencial;
            }
            return null;
        }
        private void field()
        {
            try
            {
                DbMain db = new DbMain("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "Manager");
                var datatable = db.Query($"SELECT * FROM ordens_de_servicos WHERE id_dominio_ngestor = '{Config.id_dominio_ngestor}' AND id_sistemas_tipo = {Config.id_operadora_servidor}");

                string osJson = "{\"os_itens\": [";
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    var obj = JObject.Parse(datatable.Rows[i][6].ToString());
                    osJson += obj["os"][0].ToString() + ",";
                }
                osJson += "]}";
                var obJson = JObject.Parse(osJson);
                StringBuilder csv = new StringBuilder();
                csv.AppendLine("CONTRATO; CLIENTE; ENDERECO; BAIRRO; TELEFONE; TIPO_OS; PRODUTO; PERIODO; STATUS;");
                Thread thread = new Thread(() =>
                {
                    foreach (var itemOs in obJson["os_itens"])
                    {
                        csv.AppendLine($"{itemOs["AccountID"].ToString()};" +
                            $"{itemOs["CustFirstName"].ToString()};" +
                            $"{itemOs["StreetAddress"].ToString()};" +
                            $"{itemOs["LocInfo1"].ToString()};" +
                            $"{itemOs["CustomerPhone1"].ToString()};" +
                            $"{itemOs["JobTypeDesc"].ToString()};" +
                            $"{itemOs["DetailExt1"].ToString()};" +
                            $"{itemOs["TimeSlotDesc"].ToString()};" +
                            $"{itemOs["StatusDesc"].ToString()};");
                    }
                    lastFileName = pathFile + fileNameExcel;
                    File.WriteAllText(lastFileName, csv.ToString());
                    status = true;

                })
                { IsBackground = true }; thread.Start();
            }
            catch { }
        }

    }
}
