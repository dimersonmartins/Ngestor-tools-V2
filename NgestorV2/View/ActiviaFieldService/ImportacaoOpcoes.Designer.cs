namespace NgestorFieldServiceTools.View.ActiviaFieldService
{
    partial class ImportacaoOpcoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportacaoOpcoes));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_confirmar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.data_inicial = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.os_concluidas = new System.Windows.Forms.RadioButton();
            this.os_arquivadas = new System.Windows.Forms.RadioButton();
            this.os_canceladas = new System.Windows.Forms.RadioButton();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
            this.logo = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.bunifuCards1.SuspendLayout();
            this.bunifuCards2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btn_confirmar);
            this.groupBox2.Location = new System.Drawing.Point(12, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 112);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            // 
            // btn_confirmar
            // 
            this.btn_confirmar.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_confirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_confirmar.Font = new System.Drawing.Font("Arial", 10F);
            this.btn_confirmar.ForeColor = System.Drawing.Color.White;
            this.btn_confirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_confirmar.Location = new System.Drawing.Point(132, 64);
            this.btn_confirmar.Margin = new System.Windows.Forms.Padding(0);
            this.btn_confirmar.Name = "btn_confirmar";
            this.btn_confirmar.Size = new System.Drawing.Size(141, 33);
            this.btn_confirmar.TabIndex = 43;
            this.btn_confirmar.Text = "Confirmar";
            this.btn_confirmar.UseVisualStyleBackColor = false;
            this.btn_confirmar.Click += new System.EventHandler(this.btn_confirmar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.data_inicial);
            this.groupBox3.Location = new System.Drawing.Point(12, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(410, 48);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 41;
            this.label4.Text = "Data inicial";
            // 
            // data_inicial
            // 
            this.data_inicial.CalendarFont = new System.Drawing.Font("Arial", 10F);
            this.data_inicial.Font = new System.Drawing.Font("Arial", 11F);
            this.data_inicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.data_inicial.Location = new System.Drawing.Point(194, 16);
            this.data_inicial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.data_inicial.Name = "data_inicial";
            this.data_inicial.Size = new System.Drawing.Size(122, 24);
            this.data_inicial.TabIndex = 40;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.os_concluidas);
            this.groupBox1.Controls.Add(this.os_arquivadas);
            this.groupBox1.Controls.Add(this.os_canceladas);
            this.groupBox1.Location = new System.Drawing.Point(12, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 63);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de O.S";
            // 
            // os_concluidas
            // 
            this.os_concluidas.AutoSize = true;
            this.os_concluidas.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.os_concluidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.os_concluidas.Font = new System.Drawing.Font("Arial", 10F);
            this.os_concluidas.ForeColor = System.Drawing.Color.White;
            this.os_concluidas.Location = new System.Drawing.Point(37, 26);
            this.os_concluidas.Name = "os_concluidas";
            this.os_concluidas.Size = new System.Drawing.Size(100, 20);
            this.os_concluidas.TabIndex = 46;
            this.os_concluidas.TabStop = true;
            this.os_concluidas.Text = "Concluídas ";
            this.os_concluidas.UseVisualStyleBackColor = false;
            // 
            // os_arquivadas
            // 
            this.os_arquivadas.AutoSize = true;
            this.os_arquivadas.BackColor = System.Drawing.Color.DarkOrange;
            this.os_arquivadas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.os_arquivadas.Font = new System.Drawing.Font("Arial", 10F);
            this.os_arquivadas.ForeColor = System.Drawing.Color.White;
            this.os_arquivadas.Location = new System.Drawing.Point(261, 26);
            this.os_arquivadas.Name = "os_arquivadas";
            this.os_arquivadas.Size = new System.Drawing.Size(100, 20);
            this.os_arquivadas.TabIndex = 44;
            this.os_arquivadas.TabStop = true;
            this.os_arquivadas.Text = "Arquivadas ";
            this.os_arquivadas.UseVisualStyleBackColor = false;
            // 
            // os_canceladas
            // 
            this.os_canceladas.AutoSize = true;
            this.os_canceladas.BackColor = System.Drawing.Color.IndianRed;
            this.os_canceladas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.os_canceladas.Font = new System.Drawing.Font("Arial", 10F);
            this.os_canceladas.ForeColor = System.Drawing.Color.White;
            this.os_canceladas.Location = new System.Drawing.Point(144, 26);
            this.os_canceladas.Name = "os_canceladas";
            this.os_canceladas.Size = new System.Drawing.Size(100, 20);
            this.os_canceladas.TabIndex = 45;
            this.os_canceladas.TabStop = true;
            this.os_canceladas.Text = "Canceladas";
            this.os_canceladas.UseVisualStyleBackColor = false;
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.logo);
            this.bunifuCards1.Controls.Add(this.label1);
            this.bunifuCards1.Controls.Add(this.btnClose);
            this.bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(432, 50);
            this.bunifuCards1.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(56, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 88;
            this.label1.Text = "Importações";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Maroon;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(375, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 42);
            this.btnClose.TabIndex = 87;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // bunifuCards2
            // 
            this.bunifuCards2.BackColor = System.Drawing.Color.White;
            this.bunifuCards2.BorderRadius = 5;
            this.bunifuCards2.BottomSahddow = true;
            this.bunifuCards2.color = System.Drawing.Color.Tomato;
            this.bunifuCards2.Controls.Add(this.groupBox2);
            this.bunifuCards2.Controls.Add(this.groupBox3);
            this.bunifuCards2.Controls.Add(this.groupBox1);
            this.bunifuCards2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCards2.LeftSahddow = false;
            this.bunifuCards2.Location = new System.Drawing.Point(0, 50);
            this.bunifuCards2.Name = "bunifuCards2";
            this.bunifuCards2.RightSahddow = true;
            this.bunifuCards2.ShadowDepth = 20;
            this.bunifuCards2.Size = new System.Drawing.Size(432, 278);
            this.bunifuCards2.TabIndex = 53;
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(3, 5);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(46, 43);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 89;
            this.logo.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 32);
            this.label2.TabIndex = 44;
            this.label2.Text = "Ao confirmar, todos os serviços serão\r\nimportados diretamento para o Ngestor";
            // 
            // ImportacaoOpcoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(432, 328);
            this.Controls.Add(this.bunifuCards2);
            this.Controls.Add(this.bunifuCards1);
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ImportacaoOpcoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opcões";
            this.Load += new System.EventHandler(this.ImportacaoOpcoes_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            this.bunifuCards2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_confirmar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker data_inicial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton os_concluidas;
        private System.Windows.Forms.RadioButton os_arquivadas;
        private System.Windows.Forms.RadioButton os_canceladas;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuCards bunifuCards2;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label label2;
    }
}