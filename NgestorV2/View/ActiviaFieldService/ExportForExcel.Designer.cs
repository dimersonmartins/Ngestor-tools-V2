namespace NgestorFieldServiceTools.View.ActiviaFieldService
{
    partial class ExportForExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportForExcel));
            this.img_loading = new System.Windows.Forms.PictureBox();
            this.img_error = new System.Windows.Forms.PictureBox();
            this.img_concluido = new System.Windows.Forms.PictureBox();
            this.btn_abort = new System.Windows.Forms.Button();
            this.lbl_status = new System.Windows.Forms.Label();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.lbl_tipo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
            ((System.ComponentModel.ISupportInitialize)(this.img_loading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_concluido)).BeginInit();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.bunifuCards2.SuspendLayout();
            this.SuspendLayout();
            // 
            // img_loading
            // 
            this.img_loading.Image = ((System.Drawing.Image)(resources.GetObject("img_loading.Image")));
            this.img_loading.Location = new System.Drawing.Point(185, 19);
            this.img_loading.Name = "img_loading";
            this.img_loading.Size = new System.Drawing.Size(96, 91);
            this.img_loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_loading.TabIndex = 71;
            this.img_loading.TabStop = false;
            // 
            // img_error
            // 
            this.img_error.Image = ((System.Drawing.Image)(resources.GetObject("img_error.Image")));
            this.img_error.Location = new System.Drawing.Point(185, 27);
            this.img_error.Name = "img_error";
            this.img_error.Size = new System.Drawing.Size(92, 83);
            this.img_error.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_error.TabIndex = 70;
            this.img_error.TabStop = false;
            this.img_error.Visible = false;
            // 
            // img_concluido
            // 
            this.img_concluido.Image = ((System.Drawing.Image)(resources.GetObject("img_concluido.Image")));
            this.img_concluido.Location = new System.Drawing.Point(185, 27);
            this.img_concluido.Name = "img_concluido";
            this.img_concluido.Size = new System.Drawing.Size(92, 83);
            this.img_concluido.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_concluido.TabIndex = 69;
            this.img_concluido.TabStop = false;
            this.img_concluido.Visible = false;
            // 
            // btn_abort
            // 
            this.btn_abort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_abort.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_abort.Location = new System.Drawing.Point(146, 156);
            this.btn_abort.Name = "btn_abort";
            this.btn_abort.Size = new System.Drawing.Size(175, 36);
            this.btn_abort.TabIndex = 68;
            this.btn_abort.Text = "Fechar";
            this.btn_abort.UseVisualStyleBackColor = true;
            this.btn_abort.Visible = false;
            this.btn_abort.Click += new System.EventHandler(this.btn_abort_Click);
            // 
            // lbl_status
            // 
            this.lbl_status.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_status.AutoSize = true;
            this.lbl_status.Font = new System.Drawing.Font("Arial", 12F);
            this.lbl_status.ForeColor = System.Drawing.Color.Black;
            this.lbl_status.Location = new System.Drawing.Point(143, 124);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(20, 18);
            this.lbl_status.TabIndex = 67;
            this.lbl_status.Text = "...";
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.lbl_tipo);
            this.bunifuCards1.Controls.Add(this.label1);
            this.bunifuCards1.Controls.Add(this.pictureBox1);
            this.bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(477, 51);
            this.bunifuCards1.TabIndex = 86;
            // 
            // lbl_tipo
            // 
            this.lbl_tipo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_tipo.AutoSize = true;
            this.lbl_tipo.Font = new System.Drawing.Font("Arial", 12F);
            this.lbl_tipo.ForeColor = System.Drawing.Color.Green;
            this.lbl_tipo.Location = new System.Drawing.Point(124, 18);
            this.lbl_tipo.Name = "lbl_tipo";
            this.lbl_tipo.Size = new System.Drawing.Size(69, 18);
            this.lbl_tipo.TabIndex = 84;
            this.lbl_tipo.Text = "Serviços";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(54, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 83;
            this.label1.Text = "Relatório:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 82;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuCards2
            // 
            this.bunifuCards2.BackColor = System.Drawing.Color.White;
            this.bunifuCards2.BorderRadius = 5;
            this.bunifuCards2.BottomSahddow = true;
            this.bunifuCards2.color = System.Drawing.Color.Tomato;
            this.bunifuCards2.Controls.Add(this.btn_abort);
            this.bunifuCards2.Controls.Add(this.lbl_status);
            this.bunifuCards2.Controls.Add(this.img_loading);
            this.bunifuCards2.Controls.Add(this.img_error);
            this.bunifuCards2.Controls.Add(this.img_concluido);
            this.bunifuCards2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCards2.LeftSahddow = false;
            this.bunifuCards2.Location = new System.Drawing.Point(0, 51);
            this.bunifuCards2.Name = "bunifuCards2";
            this.bunifuCards2.RightSahddow = true;
            this.bunifuCards2.ShadowDepth = 20;
            this.bunifuCards2.Size = new System.Drawing.Size(477, 237);
            this.bunifuCards2.TabIndex = 87;
            // 
            // ExportForExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(477, 288);
            this.Controls.Add(this.bunifuCards2);
            this.Controls.Add(this.bunifuCards1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExportForExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExportForExcel";
            this.Load += new System.EventHandler(this.ExportForExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.img_loading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_concluido)).EndInit();
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.bunifuCards2.ResumeLayout(false);
            this.bunifuCards2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox img_loading;
        private System.Windows.Forms.PictureBox img_error;
        private System.Windows.Forms.PictureBox img_concluido;
        private System.Windows.Forms.Button btn_abort;
        private System.Windows.Forms.Label lbl_status;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.Label lbl_tipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCards bunifuCards2;
    }
}