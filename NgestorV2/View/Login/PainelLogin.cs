using DataBase;
using Newtonsoft.Json.Linq;
using NgestorFieldServiceTools.App;
using NgestorFieldServiceTools.Properties;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BotNgestor.Http.Auth;

namespace NgestorFieldServiceTools.View.Login
{
    public partial class PainelLogin : Form
    {
        private Dashboard form_dashbord = null;
        public PainelLogin(Form callingForm)
        {
            form_dashbord = callingForm as Dashboard;
            InitializeComponent();
        }
       
        DbMain      database    = new DbMain("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "Manager");
        public void disable_form(bool formTrueOrFasle, string textButoon)
        {
            txt_dominio.Enabled = formTrueOrFasle;
            txt_userNgestor.Enabled = formTrueOrFasle;
            txt_senhaNgestor.Enabled = formTrueOrFasle;
            btn_logar.Enabled = formTrueOrFasle;
            btn_logar.Text = textButoon;
        }

        private async Task<AuthNgestor> lastDominios()
        {
            await checkInputDominio(txt_dominio.Text);
            AuthNgestor authNgestor = new AuthNgestor(txt_dominio.Text);
            Config.ngestor_url_server = txt_dominio.Text;
            Settings.Default["dominio"] = txt_dominio.Text;
            Settings.Default.Save();

            return authNgestor;
        }
        private async Task<bool> checkInputDominio(string dominio)
        {
            if (!dominio.Contains("http://"))
            {
                txt_dominio.Text = "http://" + txt_dominio.Text;
                if (!dominio.Contains(".com/"))
                {
                    txt_dominio.Text = txt_dominio.Text.Replace(".com", ".com/");
                    return true;
                }
            }
            else
            {
                if (!dominio.Contains(".com/"))
                {
                    txt_dominio.Text = txt_dominio.Text.Replace(".com", ".com/");
                    return true;
                }
            }
            return true;
        }

        private async void btn_logar_Click(object sender, EventArgs e)
        {
             var authNgestor = await lastDominios();
             logar(txt_userNgestor.Text, txt_senhaNgestor.Text, authNgestor);
        }

        private async void logar(string login, string password, AuthNgestor authNgestor)
        {
            disable_form(false, "Aguarde...");
            string responsengestor_url_server = await authNgestor.execute(login, password);
            try
            {
                if (!string.IsNullOrWhiteSpace(responsengestor_url_server))
                {
                    var JosonObj = JObject.Parse(responsengestor_url_server);
                    Config.token_negestor = JosonObj["token"].ToString();
                    Config.id_operadora_servidor    = int.Parse(JosonObj["operadora_servidor"]["id"].ToString());
                    Config.name_operadora_servidor  = JosonObj["operadora_servidor"]["name"].ToString();
                    Config.id_user_ngestor = int.Parse(JosonObj["user"]["id"].ToString());
                    Config.user_name_ngestor = JosonObj["user"]["name"].ToString();
                    Config.login_ngestor = txt_userNgestor.Text;
                    Config.password_ngestor = txt_senhaNgestor.Text;

                    if (JosonObj["nethome"].HasValues)
                    {
                        Config.codigo_atlas = JosonObj["nethome"]["codigo_atlas"].ToString();
                        Config.codigo_operacao = JosonObj["nethome"]["codigo_operacao"].ToString();
                        Config.codigo_localizacao = JosonObj["nethome"]["codigo_localizacao"].ToString();
                        Config.tipo_filtro_operadora = JosonObj["nethome"]["tipo_filtro_operadora"].ToString();
                        Config.base_operadora = JosonObj["nethome"]["base_operadora"].ToString();
                    }

                    saveDominio();
                    disable_form(true, "Logar");
                    setConfiguracao(responsengestor_url_server);
                }
                else
                {
                    MessageBox.Show("Usuário ou senhas invalidos!",
                   "Ngestor",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
               
            }
            catch (Exception ex)
            {
                disable_form(true, "Logar");
                MessageBox.Show(ex.Message + "Usuário ou senhas invalidos!",
                    "Ngestor",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            disable_form(true, "Logar");

        }
       
        public void saveDominio()
        {
            database.ExecuteSqlCommand($"INSERT INTO ngestor_dominios (dominio) VALUES('{Config.ngestor_url_server}')");
        }
        public void setConfiguracao(string responsengestor_url_server)
        {
            this.form_dashbord.closeLogin();
            this.form_dashbord.ngestor_url_serverName = "       " + Config.ngestor_url_server;
        }

        private void PainelLogin_Load(object sender, EventArgs e)
        {
            txt_dominio.Text = Settings.Default["dominio"].ToString();
        }

        private void btn_storageDominios_Click(object sender, EventArgs e)
        {
            try
            {
                ImageB64 imageBase64 = new ImageB64();
                var datatableDominios = database.Query("SELECT * FROM ngestor_dominios");
                if (datatableDominios.Rows.Count >= 1)
                {
                    Menudominos.Items.Clear();

                    for (int i = 0; i < datatableDominios.Rows.Count; i++)
                    {
                        Object cellValue = datatableDominios.Rows[i][1];
                        Menudominos.Items.Add(cellValue.ToString(), imageBase64.imgngestor_url_server());
                    }

                    Menudominos.Show(txt_dominio, 1, txt_dominio.Height);
                    Menudominos.ItemClicked += Menudominos_ItemClicked;
                    txt_dominio.Focus();
                }
                else
                {
                    MessageBox.Show("Não há Domínios Salvos!",
                        "Ngestor Sync",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
           
        }
        private void Menudominos_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            txt_dominio.Text = e.ClickedItem.Text;
        }

        private void txt_dominio_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_userNgestor.Focus();
            }
        }

        private void txt_userNgestor_KeyDown_1(object sender, KeyEventArgs e)
        {
            
        }

        private void txt_senhaNgestor_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
