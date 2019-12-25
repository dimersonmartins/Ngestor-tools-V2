using BotWanet03FieldService.App;
using DataBase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Threading.Tasks;

namespace BotWanet03FieldService.Repository
{
    public class Wanet03StartAutoImport
    {

        public Wanet03StartAutoImport(
            int id_user_ngestor,
            int id_operadora_servidor,
            int id_dominio_ngestor,
            string ngestor_url_server)
        {
            Config.id_user_ngestor                 = id_user_ngestor;
            Config.id_operadora_servidor           = id_operadora_servidor;
            Config.id_sistemas_tipo                = id_operadora_servidor;
            Config.id_dominio_ngestor              = id_dominio_ngestor;
            Config.ngestor_url_server              = ngestor_url_server;
          
            SET_CONFIG_AUTO_IMPORT();
        }

        public int days                            = 0;
        public int timer                           = 15;

        private void SET_CONFIG_AUTO_IMPORT()
        {
            try
            {
                string prefixFolder = Config.ngestor_url_server.Replace("https:/", "")
               .Replace("http:/", "")
               .Replace("/", "")
               .Replace(".", "_");

                DbMain db = new DbMain("Data Source=" + AppDomain.CurrentDomain.BaseDirectory.Replace(prefixFolder, "") + "Manager");
                DataTable datatable = db.Query($"SELECT * FROM manager_config_timer WHERE id_dominio_ngestor = {Config.id_dominio_ngestor}");
                if (datatable != null)
                {
                    days = int.Parse(datatable.Rows[0][0].ToString());
                    timer = int.Parse(datatable.Rows[0][4].ToString());
                }

                string query = $"SELECT * FROM users_servers WHERE id_dominio_ngestor = {Config.id_dominio_ngestor} AND id_user_ngestor = {Config.id_user_ngestor} AND id_sistemas_tipo = {Config.id_operadora_servidor}";
                DataTable dataUserPass = db.Query(query);

                if (datatable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataUserPass.Rows.Count; i++)
                    {
                        Config.login    = dataUserPass.Rows[i][4].ToString();
                        Config.password = dataUserPass.Rows[i][5].ToString();
                    }
                }
            }
            catch { }
        }

        public async Task<string> start()
        {
            Wanet03Manager wanet03Manager = new Wanet03Manager();
            if(await wanet03Manager.connect())
            {
                Wanet03Manager.countPercent = 0;
                Wanet03Manager.totalServicos = 0;

                var data = await wanet03Manager.getOrders();
                if (data != null)
                {
                    return generateJson(data);
                }               
            }
            return null;
        }

        private string generateJson(List<ExpandoObject> data)
        {
            if (data != null)
            {
                string os = "{\"os_itens\": [";
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
                return json;
            }
            return null;
        }
    }
}
