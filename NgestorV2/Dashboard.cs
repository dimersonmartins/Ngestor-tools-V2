using DataBase;
using NgestorFieldServiceTools.ACL;
using NgestorFieldServiceTools.App;
using NgestorFieldServiceTools.View.Configuracao;
using NgestorFieldServiceTools.View.Login;
using NgestorFieldServiceTools.View.UserViewController;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NgestorFieldServiceTools
{
    public partial class Dashboard : MetroFramework.Forms.MetroForm
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        private DbMain database    = new DbMain("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "Manager");
        private Form _objectForm;
        private void callLogin()
        {
            _objectForm?.Close();

            _objectForm = new PainelLogin(this)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
            };
            panelCallLogin.Controls.Add(_objectForm);
            _objectForm.Show();
        }
        public async void closeLogin()
        {
            panelCallLogin.Visible                  = false;
            configuraçãoToolStripMenuItem.Visible   = true;
            dashboardToolStripMenuItem.Visible      = true;
            ocultarToolStripMenuItem.Visible        = true;
            //excelToolStripMenuItem.Visible          = true;
            try
            {
                painel_central.Controls.Clear();
                AdminController adminController = new AdminController();
                var sistema = await adminController.sistema(this);
                sistema.Dock = DockStyle.Fill;
                painel_central.Controls.Add(sistema);

                saveUser();

                if (!string.IsNullOrWhiteSpace(Config.ngestor_url_server))
                {
                    ngestor_auto_importa.Text = "       " + Config.ngestor_url_server;
                }
                else
                {
                    ngestor_auto_importa.Text = "Logar no Ngestor";
                }
            }
            catch
            { }
        }
        public string ngestor_url_serverName
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
        private void saveUser()
        {
            try
            {
                database.ExecuteSqlCommand($"INSERT INTO ngestor_users (id_dominio_ngestor, id_user, login, password) VALUES({Config.id_dominio_ngestor}, {Config.id_user_ngestor}, '{Config.login_ngestor}', '{Config.password_ngestor}' )");
            }
            catch { }          
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            database.execute();
            callLogin();
        }
        private void painel_central_Resize(object sender, EventArgs e)
        {
            int x = (painel_central.Size.Width - panelCallLogin.Width) / 2;
            int y = (painel_central.Size.Height - panelCallLogin.Height) / 2;
            panelCallLogin.Location = new Point(x, y);
        }
        private void configuraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                painel_central.Controls.Clear();
                if (UserControls.Config != null)
                {
                    UserControls.Config.Dock = DockStyle.Fill;
                    painel_central.Controls.Add(UserControls.Config);
                }
                else
                {
                    Admin admin = new Admin();
                    admin.Dock = DockStyle.Fill;
                    painel_central.Controls.Add(admin);
                    UserControls.Config = admin;
                } 
            }
            catch { }         
        }
        private string text_notificao;
        private void exibirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Maximized;
        }
        private void ngestor_auto_importa_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Maximized;
        }
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ocultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Config.ngestor_url_server))
            {
                ngestor_auto_importa.Text = "       " + Config.ngestor_url_server;
            }
            else
            {
                ngestor_auto_importa.Text = "Logar no Ngestor";
            }
            text_notificao = "Aplicação ainda está ativo";
            ngestor_auto_importa.BalloonTipTitle = "Ngestor";
            ngestor_auto_importa.BalloonTipText = text_notificao;
            ngestor_auto_importa.ShowBalloonTip(100);
            this.Hide();
        }

        private async void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                painel_central.Controls.Clear();
                if (UserControls.Dashboard != null)
                {
                    UserControls.Dashboard.Dock = DockStyle.Fill;
                    painel_central.Controls.Add(UserControls.Dashboard);
                }
                else
                {
                    AdminController adminController = new AdminController();
                    var sistema = await adminController.sistema(this);
                    sistema.Dock = DockStyle.Fill;
                    painel_central.Controls.Add(sistema);
                    UserControls.Dashboard = sistema;
                }
               
            }
            catch { }
        }


    }
}
