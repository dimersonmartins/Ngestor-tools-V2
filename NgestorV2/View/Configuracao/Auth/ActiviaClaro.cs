using System.IO;
using System.Threading.Tasks;
using BotActiviaClaroFieldService.Repository;
using Newtonsoft.Json;
using NgestorFieldServiceTools.App;

namespace NgestorFieldServiceTools.View.Configuracao.Auth
{
    class ActiviaClaro
    {
        public async Task<bool> execute(string pathApplication, string login, string password)
        {
            BotActiviaClaroFieldService.App.Config.login    = login;
            BotActiviaClaroFieldService.App.Config.password = password;

            ActiviaClaroManager activiaClaroManager = new ActiviaClaroManager();
            if (await activiaClaroManager.connect())
            {
                createJsonConfig(pathApplication);
                return true;
            }

            return false;
        }

        private void createJsonConfig(string pathApplication)
        {
            JsonConfigActiviaClaro jsonConfig = new JsonConfigActiviaClaro();

            jsonConfig.id_dominio_ngestor = Config.id_dominio_ngestor;
            jsonConfig.id_user_ngestor = Config.id_user_ngestor;
            jsonConfig.token_negestor = Config.token_negestor;
            jsonConfig.ngestor_url_server = Config.ngestor_url_server;
            jsonConfig.id_operadora_servidor = Config.id_operadora_servidor;

            string json = JsonConvert.SerializeObject(jsonConfig);
            string configJson = "{\"config\":" + json + "}";
            File.WriteAllText(pathApplication + "\\CONFIG_ACTIVIA_CLARO_FIELD.json", configJson);

        }
    }

    public class JsonConfigActiviaClaro
    {

        public int id_user_ngestor { get; set; }
        public int id_dominio_ngestor { get; set; }
        public int id_operadora_servidor { get; set; }
        public string ngestor_url_server { get; set; }
        public string token_negestor { get; set; }

    }
}
