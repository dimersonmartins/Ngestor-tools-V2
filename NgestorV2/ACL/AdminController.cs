using DataBase;
using NgestorFieldServiceTools.App;
using NgestorFieldServiceTools.View.Configuracao;
using NgestorFieldServiceTools.View.UserViewController;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActiviaDashboard = NgestorFieldServiceTools.View.Home.ActiviaFieldServiceDashboard;
using FieldDashboard = NgestorFieldServiceTools.View.Home.FieldServiceDashboard;
using NetfsActivia8080 = NgestorFieldServiceTools.View.Home.NetfsActivia8080;

namespace NgestorFieldServiceTools.ACL
{
    class AdminController
    {
        private string login    =  "";
        private string password = "";
        DbMain database = new DbMain("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "Manager");
        private void SET_id_dominio_ngestor()
        {
            try
            {
                DataTable data = database.Query($"SELECT id FROM ngestor_dominios WHERE dominio = '{Config.ngestor_url_server}'");
                Config.id_dominio_ngestor = int.Parse(data.Rows[0][0].ToString());
            }
            catch { }   
        }      
        private async Task<bool> CheckPassword()
        {
            string query = $"SELECT * FROM users_servers WHERE id_dominio_ngestor = {Config.id_dominio_ngestor} AND id_user_ngestor = {Config.id_user_ngestor} AND id_sistemas_tipo = {Config.id_operadora_servidor}";
            DataTable datatable = database.Query(query);
         
            if (datatable.Rows.Count > 0)
            {
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    login    = datatable.Rows[i][4].ToString();
                    password = datatable.Rows[i][5].ToString();
                }
                return true;
            }
            return false;
        }
        public async Task<UserControl> sistema(Dashboard dashboard)
        {       
            SET_id_dominio_ngestor();
            if (Config.id_operadora_servidor == 1)
            {               
                if (await CheckPassword())
                {
                    ActiviaDashboard.Default activiaDashboard = new ActiviaDashboard.Default();
                    UserControls.Dashboard = activiaDashboard;
                    return activiaDashboard;
                }
                else
                {
                    return userControlDefault();
                }
            }
            else if (Config.id_operadora_servidor == 2)
            {
                if (await CheckPassword())
                {
                    FieldDashboard.Default fieldDashboard = new FieldDashboard.Default();
                    UserControls.Dashboard = fieldDashboard;
                    return fieldDashboard;
                }
                else
                {
                    return userControlDefault();
                }
            }
            else if (Config.id_operadora_servidor == 3)
            {
                if (await CheckPassword())
                {
                    FieldDashboard.Default fieldDashboard = new FieldDashboard.Default();
                    UserControls.Dashboard = fieldDashboard;
                    return fieldDashboard;
                }
                else
                {
                    return userControlDefault();
                }
            }
            else if (Config.id_operadora_servidor == 4)
            {
                if (await CheckPassword())
                {
                    NetfsActivia8080.Default fieldDashboard = new NetfsActivia8080.Default();
                    UserControls.Dashboard = fieldDashboard;
                    return fieldDashboard;
                }
                else
                {
                    return userControlDefault();
                }
            }
            return null;
        }
        private UserControl userControlDefault()
        {
            Admin adminConfiguracao = new Admin();
            UserControls.Config = adminConfiguracao;
            return adminConfiguracao;
        }
    }
}
