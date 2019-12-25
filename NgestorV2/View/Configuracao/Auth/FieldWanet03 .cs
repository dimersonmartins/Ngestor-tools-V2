using System.Threading.Tasks;
using BotWanet03FieldService.Repository;
namespace NgestorFieldServiceTools.View.Configuracao.Auth
{
    class FieldWanet03
    {
        public async Task<bool> execute(string login, string password)
        {
            BotWanet03FieldService.App.Config.login = login;
            BotWanet03FieldService.App.Config.password = password;

            Wanet03Manager wanet03Manager = new Wanet03Manager();
            return await wanet03Manager.connect();
        }    
    }
}
