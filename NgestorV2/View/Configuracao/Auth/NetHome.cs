using BotNetHome.Repository;
using System;
using System.IO;
using System.Threading.Tasks;
using NgestorFieldServiceTools.App;
using DataBase;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NgestorFieldServiceTools.View.Configuracao.Auth
{
    class NetHome
    {
        public async Task<bool> execute(string pathApplication, string login, string password)
        {
            BotNetHome.App.Config.LOGIN = login;
            BotNetHome.App.Config.PASSWORD = password;

            NetHomeManager netHomeManager = new NetHomeManager();
            if (await netHomeManager.connect() != null)
            {
                createJsonConfig(pathApplication, login, password);

                return true;
            }
            return false;
        }

     
        private void createJsonConfig(string path,string login, string password)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                JsonConfig jsonConfig               = new JsonConfig();
                jsonConfig.base_operadora           = Config.base_operadora;
                jsonConfig.codigo_atlas             = Config.codigo_atlas;
                jsonConfig.tipo_filtro_operadora    = Config.tipo_filtro_operadora;
                jsonConfig.codigo_localizacao       = Config.codigo_localizacao;
                jsonConfig.codigo_operacao          = Config.codigo_operacao;
                jsonConfig.id_dominio_ngestor       = Config.id_dominio_ngestor;
                jsonConfig.id_user_ngestor          = Config.id_user_ngestor;
                jsonConfig.token_negestor           = Config.token_negestor;
                jsonConfig.ngestor_url_server       = Config.ngestor_url_server;
                jsonConfig.login                    = login;
                jsonConfig.password                 = password;

                string json = JsonConvert.SerializeObject(jsonConfig);
                string configJson = "{\"config\":" + json + "}";
                File.WriteAllText(path + "\\CONFIG_NETHOME.json", configJson);
            }
          
        }
    }

    public class JsonConfig
    {
        public string login { get; set; }
        public string password { get; set; }
        public string token_negestor { get; set; }
        public string ngestor_url_server { get; set; }
        public int id_user_ngestor { get; set; }
        public int id_dominio_ngestor { get; set; }
        public string codigo_atlas { get; set; }
        public string codigo_operacao { get; set; }
        public string base_operadora { get; set; }
        public string tipo_filtro_operadora { get; set; }
        public string codigo_localizacao { get; set; }
    }
}
