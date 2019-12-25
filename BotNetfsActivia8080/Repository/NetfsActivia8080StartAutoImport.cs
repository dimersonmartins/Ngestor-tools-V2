using BotNetfsActivia8080.App;
using DataBase;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BotNetfsActivia8080.Repository
{
    public class NetfsActivia8080StartAutoImport
    {
        public NetfsActivia8080StartAutoImport(
            int ID_DOMINIO_NGESTOR,
            int id_operadora_servidor,
            int ID_USER_NGESTOR
            )
        {
            Config.id_dominio_ngestor               = ID_DOMINIO_NGESTOR;
            Config.id_operadora_servidor            = id_operadora_servidor;
            Config.id_user_ngestor                  = ID_USER_NGESTOR;

            SET_CONFIG_AUTO_IMPORT();
        }

        public int days = 0;
        public int timer = 15;
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
                        Config.LOGIN = dataUserPass.Rows[i][4].ToString();
                        Config.PASSWORD = dataUserPass.Rows[i][5].ToString();
                    }
                }
            }
            catch { }
        }

        private NetfsActivia8080Manager netfsActivia8080Manager = new NetfsActivia8080Manager();

        public async Task<string> start()
        {
            if (await netfsActivia8080Manager.connect())
            {
                NetfsActivia8080Manager.totalServicos   = 0;
                NetfsActivia8080Manager.countPercent    = 0;

                var services = await netfsActivia8080Manager.getOrders();
                if (services != null)
                {
                    return netfsActivia8080Manager.generateJsonContent(services);
                }
            }
            return null;
        }

    }
}
