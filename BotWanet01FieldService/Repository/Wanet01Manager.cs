using BotWanet01FieldService.CSV;
using BotWanet01FieldService.Http;
using BotWanet01FieldService.Http.Auth;
using BotWanet01FieldService.XmlToObject;
using CsvHelper;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Threading.Tasks;
using static BotWanet01FieldService.XmlToObject.RootXML;

namespace BotWanet01FieldService.Repository
{
    public class Wanet01Manager
    {

        public static int totalServicos = 0;
        public static int countPercent  = 0;
        public static string status     = "Conectando..";

        public async Task<bool> connect()
        {
            try
            {
                AuthWanet01 auth = new AuthWanet01();
                if (await auth.execute())
                {
                    status = "Conectado";
                       
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
                status = "Configurando...";
               
                status = "Extraindo serviços";

                ExtrairOrdensServicos extrairOrdensServicos = new ExtrairOrdensServicos();
                string XML = await extrairOrdensServicos.GetOrders();
                return await GetOs(XML);
            }
            catch
            {
                return null;
            }

        } 

        public async Task<List<ExpandoObject>> getEquipes()
        {
            RequestEquipe requestEquipe = new RequestEquipe();
            string XML = await requestEquipe.getDataEquipe();
            WebTable csvHR = ReadXmlParseObj.Deserialize<WebTable>(XML);
            var cvsConverte = new CSVConvertByServicos();
            cvsConverte.headersRow = cvsConverte.loadHeader(csvHR.Head);
            foreach (var row in csvHR.Rows.Row)
            {
                try
                {
                    TextReader sr = new StringReader(row);
                    var csv = new CsvReader(sr);
                    csv.Read();
                    cvsConverte.execute(row);
                }
                catch
                {
                    continue;
                }
            }
            return cvsConverte.objRows;
        }

        public async Task<List<ExpandoObject>> GetOs(string XML)
        {
            WebTable csvHR = ReadXmlParseObj.Deserialize<WebTable>(XML);
            var cvsConverte = new CSVConvertByServicos();
            cvsConverte.headersRow = cvsConverte.loadHeader(csvHR.Head);

            totalServicos = csvHR.Rows.Row.Count;

            foreach (var row in csvHR.Rows.Row)
            {
                try
                {
                    TextReader sr = new StringReader(row);
                    var csv = new CsvReader(sr);
                    csv.Read();
                    var WorkOrderUID = csv[0];
                    countPercent++;
                    ExtrairOrdensServicos extrairOrdensServicos = new ExtrairOrdensServicos();
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

            countPercent = totalServicos;
            status = "Processo Finalizado";
            return data;
        }

    }
}
