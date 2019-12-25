using BotWanet03FieldService.App;
using BotWanet03FieldService.CSV;
using BotWanet03FieldService.Http;
using BotWanet03FieldService.Http.Auth;
using BotWanet03FieldService.XmlToObject;
using CsvHelper;
using DataBase;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Threading.Tasks;
using static BotWanet03FieldService.XmlToObject.RootXML;

namespace BotWanet03FieldService.Repository
{
    public class Wanet03Manager
    {
        public static int totalServicos = 0;
        public static int countPercent = 0;
        public static string status = "Conectando..";

       
        public async Task<bool> connect()
        {
            try
            {
                AuthWanet03 auth = new AuthWanet03();
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
                ExtrairOrdensServicos extrairOrdensServicos = new ExtrairOrdensServicos();
                status = "Configurando...";
                SetarFiltros setarFiltros = new SetarFiltros();
                await setarFiltros.configurarFiltros();
                status = "Extraindo serviços";
                string XML = await extrairOrdensServicos.GetOrders();
                return await GetOs(XML);
            }
            catch
            {
                return null;
            }

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
