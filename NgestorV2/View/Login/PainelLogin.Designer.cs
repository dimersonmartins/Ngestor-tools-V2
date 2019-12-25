namespace NgestorFieldServiceTools.View.Login
{
    partial class PainelLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PainelLogin));
            this.btn_storageDominios = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_logar = new System.Windows.Forms.Button();
            this.Menudominos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.txt_senhaNgestor = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.txt_userNgestor = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.txt_dominio = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.bunifuCards1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_storageDominios
            // 
            this.btn_storageDominios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_storageDominios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_storageDominios.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btn_storageDominios.ForeColor = System.Drawing.Color.White;
            this.btn_storageDominios.Location = new System.Drawing.Point(225, 82);
            this.btn_storageDominios.Name = "btn_storageDominios";
            this.btn_storageDominios.Size = new System.Drawing.Size(82, 26);
            this.btn_storageDominios.TabIndex = 53;
            this.btn_storageDominios.Text = "Source ...";
            this.btn_storageDominios.UseVisualStyleBackColor = false;
            this.btn_storageDominios.Click += new System.EventHandler(this.btn_storageDominios_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Arial", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(9, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 50;
            this.label3.Text = "Domínio:";
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(103, 11);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(100, 97);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 48;
            this.logo.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Arial", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(9, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 47;
            this.label2.Text = "Senha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(9, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 46;
            this.label1.Text = "E-mail:";
            // 
            // btn_logar
            // 
            this.btn_logar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_logar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logar.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_logar.Location = new System.Drawing.Point(12, 269);
            this.btn_logar.Name = "btn_logar";
            this.btn_logar.Size = new System.Drawing.Size(296, 38);
            this.btn_logar.TabIndex = 3;
            this.btn_logar.Text = "Logar";
            this.btn_logar.UseVisualStyleBackColor = false;
            this.btn_logar.Click += new System.EventHandler(this.btn_logar_Click);
            // 
            // Menudominos
            // 
            this.Menudominos.Name = "Menudominos";
            this.Menudominos.Size = new System.Drawing.Size(61, 4);
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(54)))));
            this.bunifuCards1.Controls.Add(this.btn_logar);
            this.bunifuCards1.Controls.Add(this.label3);
            this.bunifuCards1.Controls.Add(this.btn_storageDominios);
            this.bunifuCards1.Controls.Add(this.label2);
            this.bunifuCards1.Controls.Add(this.label1);
            this.bunifuCards1.Controls.Add(this.logo);
            this.bunifuCards1.Controls.Add(this.txt_senhaNgestor);
            this.bunifuCards1.Controls.Add(this.txt_userNgestor);
            this.bunifuCards1.Controls.Add(this.txt_dominio);
            this.bunifuCards1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(322, 320);
            this.bunifuCards1.TabIndex = 4;
            // 
            // txt_senhaNgestor
            // 
            this.txt_senhaNgestor.AcceptsReturn = false;
            this.txt_senhaNgestor.AcceptsTab = false;
            this.txt_senhaNgestor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txt_senhaNgestor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txt_senhaNgestor.BackColor = System.Drawing.Color.Transparent;
            this.txt_senhaNgestor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txt_senhaNgestor.BackgroundImage")));
            this.txt_senhaNgestor.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txt_senhaNgestor.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.txt_senhaNgestor.BorderColorHover = System.Drawing.Color.Teal;
            this.txt_senhaNgestor.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.txt_senhaNgestor.BorderRadius = 1;
            this.txt_senhaNgestor.BorderThickness = 2;
            this.txt_senhaNgestor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txt_senhaNgestor.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_senhaNgestor.DefaultText = "167167";
            this.txt_senhaNgestor.FillColor = System.Drawing.Color.White;
            this.txt_senhaNgestor.HideSelection = true;
            this.txt_senhaNgestor.IconLeft = null;
            this.txt_senhaNgestor.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.txt_senhaNgestor.IconPadding = 10;
            this.txt_senhaNgestor.IconRight = null;
            this.txt_senhaNgestor.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.txt_senhaNgestor.Location = new System.Drawing.Point(12, 228);
            this.txt_senhaNgestor.MaxLength = 32767;
            this.txt_senhaNgestor.MinimumSize = new System.Drawing.Size(100, 35);
            this.txt_senhaNgestor.Modified = false;
            this.txt_senhaNgestor.Name = "txt_senhaNgestor";
            this.txt_senhaNgestor.PasswordChar = '*';
            this.txt_senhaNgestor.ReadOnly = false;
            this.txt_senhaNgestor.SelectedText = "";
            this.txt_senhaNgestor.SelectionLength = 0;
            this.txt_senhaNgestor.SelectionStart = 0;
            this.txt_senhaNgestor.ShortcutsEnabled = true;
            this.txt_senhaNgestor.Size = new System.Drawing.Size(295, 35);
            this.txt_senhaNgestor.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.txt_senhaNgestor.TabIndex = 2;
            this.txt_senhaNgestor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_senhaNgestor.TextMarginLeft = 5;
            this.txt_senhaNgestor.TextPlaceholder = "";
            this.txt_senhaNgestor.UseSystemPasswordChar = false;
            this.txt_senhaNgestor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_senhaNgestor_KeyDown);
            // 
            // txt_userNgestor
            // 
            this.txt_userNgestor.AcceptsReturn = false;
            this.txt_userNgestor.AcceptsTab = false;
            this.txt_userNgestor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txt_userNgestor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txt_userNgestor.BackColor = System.Drawing.Color.Transparent;
            this.txt_userNgestor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txt_userNgestor.BackgroundImage")));
            this.txt_userNgestor.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txt_userNgestor.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.txt_userNgestor.BorderColorHover = System.Drawing.Color.Teal;
            this.txt_userNgestor.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.txt_userNgestor.BorderRadius = 1;
            this.txt_userNgestor.BorderThickness = 2;
            this.txt_userNgestor.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txt_userNgestor.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_userNgestor.DefaultText = "dimerson@gmail.com";
            this.txt_userNgestor.FillColor = System.Drawing.Color.White;
            this.txt_userNgestor.HideSelection = true;
            this.txt_userNgestor.IconLeft = null;
            this.txt_userNgestor.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.txt_userNgestor.IconPadding = 10;
            this.txt_userNgestor.IconRight = null;
            this.txt_userNgestor.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.txt_userNgestor.Location = new System.Drawing.Point(12, 169);
            this.txt_userNgestor.MaxLength = 32767;
            this.txt_userNgestor.MinimumSize = new System.Drawing.Size(100, 35);
            this.txt_userNgestor.Modified = false;
            this.txt_userNgestor.Name = "txt_userNgestor";
            this.txt_userNgestor.PasswordChar = '\0';
            this.txt_userNgestor.ReadOnly = false;
            this.txt_userNgestor.SelectedText = "";
            this.txt_userNgestor.SelectionLength = 0;
            this.txt_userNgestor.SelectionStart = 0;
            this.txt_userNgestor.ShortcutsEnabled = true;
            this.txt_userNgestor.Size = new System.Drawing.Size(295, 35);
            this.txt_userNgestor.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.txt_userNgestor.TabIndex = 1;
            this.txt_userNgestor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_userNgestor.TextMarginLeft = 5;
            this.txt_userNgestor.TextPlaceholder = "";
            this.txt_userNgestor.UseSystemPasswordChar = false;
            this.txt_userNgestor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_userNgestor_KeyDown_1);
            // 
            // txt_dominio
            // 
            this.txt_dominio.AcceptsReturn = false;
            this.txt_dominio.AcceptsTab = false;
            this.txt_dominio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txt_dominio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txt_dominio.BackColor = System.Drawing.Color.Transparent;
            this.txt_dominio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txt_dominio.BackgroundImage")));
            this.txt_dominio.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txt_dominio.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.txt_dominio.BorderColorHover = System.Drawing.Color.Teal;
            this.txt_dominio.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.txt_dominio.BorderRadius = 1;
            this.txt_dominio.BorderThickness = 2;
            this.txt_dominio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txt_dominio.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dominio.DefaultText = "";
            this.txt_dominio.FillColor = System.Drawing.Color.White;
            this.txt_dominio.HideSelection = true;
            this.txt_dominio.IconLeft = null;
            this.txt_dominio.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.txt_dominio.IconPadding = 10;
            this.txt_dominio.IconRight = null;
            this.txt_dominio.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.txt_dominio.Location = new System.Drawing.Point(12, 114);
            this.txt_dominio.MaxLength = 32767;
            this.txt_dominio.MinimumSize = new System.Drawing.Size(100, 35);
            this.txt_dominio.Modified = false;
            this.txt_dominio.Name = "txt_dominio";
            this.txt_dominio.PasswordChar = '\0';
            this.txt_dominio.ReadOnly = false;
            this.txt_dominio.SelectedText = "";
            this.txt_dominio.SelectionLength = 0;
            this.txt_dominio.SelectionStart = 0;
            this.txt_dominio.ShortcutsEnabled = true;
            this.txt_dominio.Size = new System.Drawing.Size(295, 35);
            this.txt_dominio.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.txt_dominio.TabIndex = 0;
            this.txt_dominio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_dominio.TextMarginLeft = 5;
            this.txt_dominio.TextPlaceholder = "";
            this.txt_dominio.UseSystemPasswordChar = false;
            this.txt_dominio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_dominio_KeyDown_1);
            // 
            // PainelLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 320);
            this.Controls.Add(this.bunifuCards1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PainelLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PainelLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_storageDominios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_logar;
        private System.Windows.Forms.ContextMenuStrip Menudominos;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox txt_senhaNgestor;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox txt_userNgestor;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox txt_dominio;
    }
}