using System.Threading.Tasks;
using BotNetfsActivia8080.Repository;

namespace NgestorFieldServiceTools.View.Configuracao.Auth
{
    class NetfsActivia8080
    {
        public async Task<bool> execute(string login, string password)
        {
            BotNetfsActivia8080.App.Config.LOGIN    = login;
            BotNetfsActivia8080.App.Config.PASSWORD = password;

            NetfsActivia8080Manager netfsActivia8080Manager = new NetfsActivia8080Manager();
            return await netfsActivia8080Manager.connect();
        }  
    }
}
