namespace NgestorFieldServiceTools
{
    partial class Dashboard
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.painel_central = new System.Windows.Forms.Panel();
            this.panelCallLogin = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ocultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ngestor_auto_importa = new System.Windows.Forms.NotifyIcon(this.components);
            this.menu_notificacao = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exibirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logo = new System.Windows.Forms.PictureBox();
            this.painel_central.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.menu_notificacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // painel_central
            // 
            this.painel_central.Controls.Add(this.panelCallLogin);
            this.painel_central.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painel_central.Location = new System.Drawing.Point(50, 60);
            this.painel_central.Name = "painel_central";
            this.painel_central.Size = new System.Drawing.Size(874, 498);
            this.painel_central.TabIndex = 3;
            this.painel_central.Resize += new System.EventHandler(this.painel_central_Resize);
            // 
            // panelCallLogin
            // 
            this.panelCallLogin.Location = new System.Drawing.Point(236, 13);
            this.panelCallLogin.Name = "panelCallLogin";
            this.panelCallLogin.Size = new System.Drawing.Size(388, 428);
            this.panelCallLogin.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(46)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardToolStripMenuItem,
            this.configuraçãoToolStripMenuItem,
            this.ocultarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(30, 498);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.dashboardToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dashboardToolStripMenuItem.Image")));
            this.dashboardToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(169, 36);
            this.dashboardToolStripMenuItem.Text = " Dashboard";
            this.dashboardToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dashboardToolStripMenuItem.Visible = false;
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // configuraçãoToolStripMenuItem
            // 
            this.configuraçãoToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.configuraçãoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("configuraçãoToolStripMenuItem.Image")));
            this.configuraçãoToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.configuraçãoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.configuraçãoToolStripMenuItem.Name = "configuraçãoToolStripMenuItem";
            this.configuraçãoToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4);
            this.configuraçãoToolStripMenuItem.Size = new System.Drawing.Size(169, 44);
            this.configuraçãoToolStripMenuItem.Text = " Configurações";
            this.configuraçãoToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.configuraçãoToolStripMenuItem.ToolTipText = "Configuração";
            this.configuraçãoToolStripMenuItem.Visible = false;
            this.configuraçãoToolStripMenuItem.Click += new System.EventHandler(this.configuraçãoToolStripMenuItem_Click);
            // 
            // ocultarToolStripMenuItem
            // 
            this.ocultarToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.ocultarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ocultarToolStripMenuItem.Image")));
            this.ocultarToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ocultarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ocultarToolStripMenuItem.Name = "ocultarToolStripMenuItem";
            this.ocultarToolStripMenuItem.Size = new System.Drawing.Size(169, 34);
            this.ocultarToolStripMenuItem.Text = " Ocultar Aplicação";
            this.ocultarToolStripMenuItem.Visible = false;
            this.ocultarToolStripMenuItem.Click += new System.EventHandler(this.ocultarToolStripMenuItem_Click);
            // 
            // ngestor_auto_importa
            // 
            this.ngestor_auto_importa.ContextMenuStrip = this.menu_notificacao;
            this.ngestor_auto_importa.Icon = ((System.Drawing.Icon)(resources.GetObject("ngestor_auto_importa.Icon")));
            this.ngestor_auto_importa.Text = "Ngestor";
            this.ngestor_auto_importa.Visible = true;
            this.ngestor_auto_importa.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ngestor_auto_importa_MouseDoubleClick);
            // 
            // menu_notificacao
            // 
            this.menu_notificacao.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exibirToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menu_notificacao.Name = "menu_notificacao";
            this.menu_notificacao.Size = new System.Drawing.Size(138, 48);
            // 
            // exibirToolStripMenuItem
            // 
            this.exibirToolStripMenuItem.Name = "exibirToolStripMenuItem";
            this.exibirToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.exibirToolStripMenuItem.Text = "Exibir Painel";
            this.exibirToolStripMenuItem.Click += new System.EventHandler(this.exibirToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(27, 14);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(46, 43);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 6;
            this.logo.TabStop = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 578);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.painel_central);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Dashboard";
            this.Text = "       Ngestor Tools";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.painel_central.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menu_notificacao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel painel_central;
        private System.Windows.Forms.Panel panelCallLogin;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuraçãoToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon ngestor_auto_importa;
        private System.Windows.Forms.ContextMenuStrip menu_notificacao;
        private System.Windows.Forms.ToolStripMenuItem exibirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ocultarToolStripMenuItem;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
    }
}

