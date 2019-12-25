using DataBase;
using NgestorFieldServiceTools.App;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NgestorFieldServiceTools.View.Configuracao
{
    public partial class Admin : UserControl
    {
        public Admin()
        {
            InitializeComponent();
        }
        DbMain database = new DbMain("Data Source="+ AppDomain.CurrentDomain.BaseDirectory + "Manager");
        
        private void statusValidacao(bool visible, string text, int validate)
        {
            if (validate == 0)
            {         
                img_validate.Visible        = !visible;
                img_warning.Visible         = !visible;
                loading.Visible             = visible;
                lbl_validation.BackColor    = Color.White;
                lbl_validation.ForeColor    = Color.Black;
                lbl_validation.Text         = text;
            }

            if (validate == 1)
            {
                if(Config.id_operadora_servidor == 1)
                {
                    lbl_activia_date.Visible    = true;
                    quantidade_de_dias.Visible  = true;
                }

                btn_concluir.Visible            = true;
                painel_config_timer.Visible     = true;
                img_warning.Visible             = !visible;
                img_validate.Visible            = visible;
                loading.Visible                 = !visible;
                lbl_validation.BackColor        = Color.Green;
                lbl_validation.ForeColor        = Color.White;
                lbl_validation.Text             = text;
            }

            if (validate == 2)
            {
                img_warning.Visible             = visible;
                loading.Visible                 = !visible;
                img_validate.Visible            = !visible;
                lbl_validation.BackColor        = Color.Maroon;
                lbl_validation.ForeColor        = Color.White;
                lbl_validation.Text             = text;
            }

        }
        private void statusValidacaoNetHome(bool visible, string text, int validate)
        {
            if (validate == 0)
            {
                pictureSucessNetHome.Visible        = !visible;
                pictureAlertNetHome.Visible         = !visible;
                pictureLoadingNetHome.Visible       = visible;
                lbl_status_auth_net_home.BackColor  = Color.White;
                lbl_status_auth_net_home.ForeColor  = Color.Black;
                lbl_status_auth_net_home.Text       = text;
            }

            if (validate == 1)
            {
                pictureAlertNetHome.Visible         = !visible;
                pictureSucessNetHome.Visible        = visible;
                pictureLoadingNetHome.Visible       = !visible;
                lbl_status_auth_net_home.BackColor  = Color.Green;
                lbl_status_auth_net_home.ForeColor  = Color.White;
                lbl_status_auth_net_home.Text       = text;
            }

            if (validate == 2)
            {
                pictureAlertNetHome.Visible         = visible;
                pictureLoadingNetHome.Visible       = !visible;
                pictureSucessNetHome.Visible        = !visible;
                lbl_status_auth_net_home.BackColor  = Color.Maroon;
                lbl_status_auth_net_home.ForeColor  = Color.White;
                lbl_status_auth_net_home.Text       = text;
            }

        }
        private async Task<bool> authPassword()
        {
            statusValidacao(true, "Por favor aguarde... \r\nEstamos validando seu login", 0);
            switch (Config.id_operadora_servidor)
            {
                case 1:
                    Auth.ActiviaClaro activia = new Auth.ActiviaClaro();
                    return await activia.execute(pathApplication, txt_user.Text, txt_pass.Text);
                case 2:
                    Auth.FieldWanet01 fieldWanet01 = new Auth.FieldWanet01();
                    return await fieldWanet01.execute(pathApplication, txt_user.Text, txt_pass.Text);
                case 3:
                    Auth.FieldWanet03 fieldWanet03 = new Auth.FieldWanet03();
                    return await fieldWanet03.execute(txt_user.Text, txt_pass.Text);
                case 4:
                    Auth.NetfsActivia8080 netfsActivia8080 = new Auth.NetfsActivia8080();
                    return await netfsActivia8080.execute(txt_user.Text, txt_pass.Text);
            }

            return false;
        }
        private async void btn_save_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = false;
            if (string.IsNullOrWhiteSpace(txt_user.Text) || string.IsNullOrWhiteSpace(txt_pass.Text))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!", "Ngestor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_save.Enabled = true;
            }
            else
            {
                if (await authPassword())
                {
                    statusValidacao(true, "Usuário e senha validado!", 1);
                    insertDb(txt_user.Text.Trim(), txt_pass.Text.Trim(), Config.tipo_server_operadora);
                    clearCampos();
                    btn_save.Enabled = true;
                }
                else
                {
                    statusValidacao(true, "Usuário ou senha inválido!", 2);
                    btn_save.Enabled = true;
                }
            }      
        }
        private void insertDb(string login, string password, string sistema)
        {
            string deleteOrdensSercivos = $"DELETE FROM ordens_de_servicos WHERE id_dominio_ngestor = {Config.id_dominio_ngestor} AND id_sistemas_tipo = {Config.id_operadora_servidor}";
            database.ExecuteSqlCommand(deleteOrdensSercivos);

            string delete = $"DELETE FROM users_servers WHERE id_dominio_ngestor = {Config.id_dominio_ngestor} AND id_user_ngestor = {Config.id_user_ngestor}";
            database.ExecuteSqlCommand(delete);

            string query = $"INSERT INTO users_servers (id_user_ngestor, id_dominio_ngestor, login, password, id_sistemas_tipo) VALUES({Config.id_user_ngestor}, '{Config.id_dominio_ngestor}', '{login}','{password}', {Config.id_operadora_servidor})";
            database.ExecuteSqlCommand(query);
        }
        private void clearCampos()
        {       
            txt_user.Clear();
            txt_pass.Clear();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            lbl_headerSO.Text = Config.name_operadora_servidor;
            radio15_min.Checked = true;
        }

        private int timer = 15;
        
        private void btn_concluir_Click(object sender, EventArgs e)
        {
            string delete = $"DELETE FROM manager_config_timer WHERE id_dominio_ngestor = {Config.id_dominio_ngestor}";
            database.ExecuteSqlCommand(delete);

            database.ExecuteSqlCommand($"INSERT INTO manager_config_timer (data_maxima, timer, id_dominio_ngestor, id_sistemas_tipo, active) VALUES({quantidade_de_dias.Value}, {timer}, {Config.id_dominio_ngestor}, {Config.id_operadora_servidor}, 1)");
            MessageBox.Show("Configuração salva com sucesso!", "Ngestor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radio_30_min_CheckedChanged(object sender, EventArgs e)
        {
            timer = 30;
        }

        private void radio_1h_CheckedChanged(object sender, EventArgs e)
        {
            timer = 60;
        }

        private void radio_130hm_CheckedChanged(object sender, EventArgs e)
        {
            timer = 90;
        }

        private void radio2h_CheckedChanged(object sender, EventArgs e)
        {
            timer = 120;
        }

        private void radio15_min_CheckedChanged(object sender, EventArgs e)
        {
            timer = 15;
        }

        private async void btn_validar_net_home_Click(object sender, EventArgs e)
        {
            btn_validar_net_home.Enabled = false;
            if (string.IsNullOrWhiteSpace(txt_user_net_home.Text) || string.IsNullOrWhiteSpace(txt_password_net_home.Text))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!", "Ngestor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_validar_net_home.Enabled = true;
            }
            else
            {
                Auth.NetHome netHome = new Auth.NetHome();
                statusValidacaoNetHome(true, "Por favor aguarde... \r\nEstamos validando seu login", 0);
                if (await netHome.execute(pathApplication, txt_user_net_home.Text, txt_password_net_home.Text))
                {
                    statusValidacaoNetHome(true, "Usuário e senha validado!", 1);
                    insertTableNetHome(txt_user_net_home.Text.Trim(), txt_password_net_home.Text.Trim());
                }
                else
                {
                    statusValidacaoNetHome(true, "Usuário ou senha inválido!", 2);
                    btn_validar_net_home.Enabled = true;
                }

            }
        }
        private void insertTableNetHome(string login, string password)
        {
            string delete = $"DELETE FROM net_home WHERE id_dominio_ngestor = {Config.id_dominio_ngestor} AND id_user_ngestor = {Config.id_user_ngestor}";
            database.ExecuteSqlCommand(delete);

            string query = $"INSERT INTO net_home (id_user_ngestor, id_dominio_ngestor, login, password, id_sistemas_tipo) VALUES({Config.id_user_ngestor}, '{Config.id_dominio_ngestor}', '{login}','{password}', 4)";
            database.ExecuteSqlCommand(query);
        }
        private string pathApplication = null;
        private void btn_create_repository_Click(object sender, EventArgs e)
        {
            CreateRepository createRepository = new CreateRepository();
            createRepository.create();
            pathApplication = createRepository.pathFolder;
            tabControl1.Visible = true;
        }
    }
}
