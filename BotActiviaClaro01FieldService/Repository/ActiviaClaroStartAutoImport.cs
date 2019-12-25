using BotActiviaClaroFieldService.App;
using BotActiviaClaroFieldService.Http.QueryForStatus;
using DataBase;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BotActiviaClaroFieldService.Repository
{
    public class ActiviaClaroStartAutoImport
    {
        public ActiviaClaroStartAutoImport(
           int id_dominio_ngestor,
           string token_ngestor,
           string ngestor_url_server,
           int id_user_ngestor,
           int id_operadora_servidor)
        {
            Config.id_dominio_ngestor               = id_dominio_ngestor;
            Config.ngestor_url_server               = ngestor_url_server;
            Config.id_operadora_servidor  = id_operadora_servidor;
            Config.id_sistemas_tipo                 = id_operadora_servidor;
            Config.id_user_ngestor                  = id_user_ngestor;
            Config.token_ngestor                    = token_ngestor;

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

                DbMain database = new DbMain("Data Source=" + AppDomain.CurrentDomain.BaseDirectory.Replace(prefixFolder, "") + "Manager");
                DataTable datatable = database.Query($"SELECT * FROM manager_config_timer WHERE id_dominio_ngestor = {Config.id_dominio_ngestor}");
                if (datatable != null)
                {
                    days = int.Parse(datatable.Rows[0][3].ToString());
                    timer = int.Parse(datatable.Rows[0][4].ToString());
                }

                string query = $"SELECT * FROM users_servers WHERE id_dominio_ngestor = {Config.id_dominio_ngestor} AND id_user_ngestor = {Config.id_user_ngestor} AND id_sistemas_tipo = {Config.id_operadora_servidor}";
                DataTable dataUserPass = database.Query(query);

                if (datatable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataUserPass.Rows.Count; i++)
                    {
                        Config.login = dataUserPass.Rows[i][4].ToString();
                        Config.password = dataUserPass.Rows[i][5].ToString();
                    }
                }
            }
            catch { }
        }

        private ActiviaClaroManager activiaClaroManager = new ActiviaClaroManager();
        public async Task<string> start()
        {
            if (await activiaClaroManager.connect())
            {

                ActiviaClaroManager.count_os   = 0;
                GetOrdersFromStatus.total_r_processadas = 0;

                DateTime today = DateTime.Now;
                DateTime maximo_de_dias = today;
                if (days != 0)
                {
                    maximo_de_dias = today.AddDays(days);
                }
                var data = await activiaClaroManager.PainelRoterizador(
                    DateTime.Now.ToShortDateString(),
                    maximo_de_dias.ToShortDateString());

                if (data != null)
                {
                    return data;
                }
            }
            return null;
        }

        public async Task<string> forStatus(string data_inicial, string status, int tipo_acao)
        {
            if (await activiaClaroManager.connect())
            {
                return await activiaClaroManager.OrdersForStatus(data_inicial, status, tipo_acao);
            }
            return null;
        }
    }
}
