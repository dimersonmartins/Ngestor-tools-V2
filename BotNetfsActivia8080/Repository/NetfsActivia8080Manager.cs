using BotNetfsActivia8080.App;
using BotNetfsActivia8080.Http.Auth;
using BotNetfsActivia8080.Http.Service;
using BotNetfsActivia8080.Http.XmlToObject.XMLRoot.Service;
using DataBase;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotNetfsActivia8080.Repository
{
    public class NetfsActivia8080Manager
    {
        public static int totalServicos = 0;
        public static int countPercent = 0;
        public static string status = "Conectando..";

        public async Task<bool> connect()
        {
            try
            {
                AuthNetfsActivia8080 auth = new AuthNetfsActivia8080();
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

        public async Task<List<OrdensServicos>> getOrders()
        {
            try
            {
                status = "Extraindo Serviços";
                GetOSs getOSs = new GetOSs();
                return await getOSs.execute();
            }
            catch
            {
                return null;
            }
        }
      
        public string generateJsonContent(List<OrdensServicos> servicos)
        {
            string json = JsonConvert.SerializeObject(servicos);
            string services = "{\"os_itens\": " + json + "}";
            return services;
        }

    }
}
