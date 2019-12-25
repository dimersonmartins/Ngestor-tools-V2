using BotWanet01FieldService.Repository;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using NgestorFieldServiceTools.App;
using System;

namespace NgestorFieldServiceTools.View.Configuracao.Auth
{
    class FieldWanet01
    {
        public async Task<bool> execute(string pathApplication, string login, string password)
        {
            BotWanet01FieldService.App.Config.login = login;
            BotWanet01FieldService.App.Config.password = password;
            Wanet01Manager wanet01Manager = new Wanet01Manager();
            if (await wanet01Manager.connect())
            {
                createJsonConfig(pathApplication);
                return true;
            }

            return false;
        }
        private void createJsonConfig(string pathApplication)
        {
            JsonConfigWanet01 jsonConfig = new JsonConfigWanet01();

            jsonConfig.id_dominio_ngestor = Config.id_dominio_ngestor;
            jsonConfig.id_user_ngestor = Config.id_user_ngestor;
            jsonConfig.token_negestor = Config.token_negestor;
            jsonConfig.ngestor_url_server = Config.ngestor_url_server;
            jsonConfig.id_operadora_servidor = Config.id_operadora_servidor;

            string json = JsonConvert.SerializeObject(jsonConfig);
            string configJson = "{\"config\":" + json + "}";
            File.WriteAllText(pathApplication + "\\CONFIG_FIELD_WANET01.json", configJson);

        }
    }
    public class JsonConfigWanet01
    {

        public int id_user_ngestor { get; set; }
        public int id_dominio_ngestor { get; set; }
        public int id_operadora_servidor { get; set; }
        public string ngestor_url_server { get; set; }
        public string token_negestor { get; set; }

    }
}
