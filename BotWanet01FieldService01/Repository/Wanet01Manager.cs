using ApiWanet01FieldService01.App;
using ApiWanet01FieldService01.CSV;
using ApiWanet01FieldService01.Http;
using ApiWanet01FieldService01.Http.Auth;
using ApiWanet01FieldService01.XmlToObject;
using CsvHelper;
using DataBase;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ApiWanet01FieldService01.XmlToObject.RootXML;

namespace ApiWanet01FieldService01.Repository
{
    class Wanet01Manager
    {
        private int countPercent = 0;
        public string data_xml = "";
        public string jsonCache = "";
        public string[] statusArray = null;
        ExtrairOrdensServicos extrairOrdensServicos = new ExtrairOrdensServicos();
        public async Task<bool> connect()
        {
            try
            {
                AuthWanet01 auth = new AuthWanet01();
                if (await auth.execute())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        public async Task<List<ExpandoObject>> getOrders()
        {
            try
            {
                data_xml = "";
                SetarFiltros setarFiltros = new SetarFiltros();
                await setarFiltros.configurarFiltros();
                data_xml = await extrairOrdensServicos.GetOrders();
                MessageBox.Show(data_xml);
                return await GetContratos();
            }
            catch
            {
                return null;
            }

        }
        public void ProcessoConsulta(int totalOs, int porcentagem)
        {
            string[] status = new string[]
            {
                porcentagem.ToString(),
                totalOs.ToString()
            };
            statusArray = status;
        }
        public List<string> contratos = new List<string>();
        public List<string> ngestor_contratos = new List<string>();
        private void insertContratosNgestor(string json)
        {
            try
            {
                string osJson = "{\"contratos\": ";
                osJson += json;
                osJson += "}";
                var obj = JObject.Parse(osJson);
                foreach (var contrato in obj["contratos"])
                {
                    ngestor_contratos.Add(contrato["num_contrato"].ToString());
                }
            }
            catch { }
        }
        private async Task<List<ExpandoObject>> GetContratos()
        {
            WebTable csvHR = ReadXmlParseObj.Deserialize<WebTable>(data_xml);
            var cvsConverte = new CSVConvertByServicos();
            cvsConverte.headersRow = cvsConverte.loadHeader(csvHR.Head);

            foreach (var row in csvHR.Rows.Row)
            {
                try
                {
                    TextReader sr = new StringReader(row);
                    var csv = new CsvReader(sr);
                    csv.Read();               
                    string contrato = csv[82];
                    contratos.Add(contrato);
                }
                catch
                {
                    continue;
                }
            }           
            return await GetOs();

        }
        public async Task<List<ExpandoObject>> GetOs()
        {
            WebTable csvHR = ReadXmlParseObj.Deserialize<WebTable>(data_xml);
            var cvsConverte = new CSVConvertByServicos();
            cvsConverte.headersRow = cvsConverte.loadHeader(csvHR.Head);

            foreach (var row in csvHR.Rows.Row)
            {
                try
                {
                    TextReader sr = new StringReader(row);
                    var csv = new CsvReader(sr);
                    csv.Read();
                    string contrato = csv[82];
                    var WorkOrderUID = csv[0];
                    countPercent++;
                    ProcessoConsulta(csvHR.Rows.Row.Count, countPercent);
                    string xmldata = await extrairOrdensServicos.GetOrderByWo(WorkOrderUID);
                    cvsConverte.excuteos_s(xmldata);
                    cvsConverte.execute(row);
                }
                catch
                {
                    continue;
                }
            }

            List<ExpandoObject> data = cvsConverte.objRows;
            generateJson(data);

            ProcessoConsulta(csvHR.Rows.Row.Count, csvHR.Rows.Row.Count);

            return data;
        }
        private async void generateJson(List<ExpandoObject> data)
        {
            string os = "{\"lista_os\": [";
            foreach (var order in data)
            {
                try
                {
                    IDictionary<string, object> propertyValues = order;
                    IDictionary<string, object> propertyValuesOS = (ExpandoObject)propertyValues;
                    string json_order = JsonConvert.SerializeObject(order);
                    os += json_order + ",";
                }
                catch
                {
                    continue;
                }
            }
            os += "]}";
            string json = os.Replace("}]},]}", "}]}]}");
            jsonCache = json;
            insertDb(json);

        }
        private void insertDb(string json)
        {
            DbMain database = new DbMain();
            database.ExecuteSqlCommand($"DELETE FROM ordens_de_servicos WHERE id_sistemas_tipo = {Config.id_sistemas_tipo}");
            var obJson = JObject.Parse(json);
            foreach (var itemOs in obJson["lista_os"])
            {
                string os = "{\"os\": [" + itemOs + "]}";
                try
                {
                    if (itemOs["StatusDesc"].ToString() != "Erro Baixa")
                    {
                        database.ExecuteSqlCommand($"INSERT INTO ordens_de_servicos (id_dominio_ngestor, numero_contrato, numero_os, tipo_servico, os, id_sistemas_tipo) VALUES('{Config.id_dominio_ngestor}', '{itemOs["AccountID"]}', '', '{itemOs["JobTypeDesc"]}', '{os}', {Config.id_sistemas_tipo})");
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
