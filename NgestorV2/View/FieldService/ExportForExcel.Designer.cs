namespace NgestorFieldServiceTools.View.FieldService
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
            ((System.ComponentModel.ISupportInitialize)(this.img_loading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_concluido)).BeginInit();
            this.SuspendLayout();
            // 
            // img_loading
            // 
            this.img_loading.Image = ((System.Drawing.Image)(resources.GetObject("img_loading.Image")));
            this.img_loading.Location = new System.Drawing.Point(193, 57);
            this.img_loading.Name = "img_loading";
            this.img_loading.Size = new System.Drawing.Size(96, 91);
            this.img_loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_loading.TabIndex = 76;
            this.img_loading.TabStop = false;
            // 
            // img_error
            // 
            this.img_error.Image = ((System.Drawing.Image)(resources.GetObject("img_error.Image")));
            this.img_error.Location = new System.Drawing.Point(193, 65);
            this.img_error.Name = "img_error";
            this.img_error.Size = new System.Drawing.Size(92, 83);
            this.img_error.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_error.TabIndex = 75;
            this.img_error.TabStop = false;
            this.img_error.Visible = false;
            // 
            // img_concluido
            // 
            this.img_concluido.Image = ((System.Drawing.Image)(resources.GetObject("img_concluido.Image")));
            this.img_concluido.Location = new System.Drawing.Point(193, 65);
            this.img_concluido.Name = "img_concluido";
            this.img_concluido.Size = new System.Drawing.Size(92, 83);
            this.img_concluido.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_concluido.TabIndex = 74;
            this.img_concluido.TabStop = false;
            this.img_concluido.Visible = false;
            // 
            // btn_abort
            // 
            this.btn_abort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_abort.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_abort.Location = new System.Drawing.Point(151, 196);
            this.btn_abort.Name = "btn_abort";
            this.btn_abort.Size = new System.Drawing.Size(175, 36);
            this.btn_abort.TabIndex = 73;
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
            this.lbl_status.Location = new System.Drawing.Point(168, 159);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(20, 18);
            this.lbl_status.TabIndex = 72;
            this.lbl_status.Text = "...";
            // 
            // ExportForExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(477, 288);
            this.Controls.Add(this.img_loading);
            this.Controls.Add(this.img_error);
            this.Controls.Add(this.img_concluido);
            this.Controls.Add(this.btn_abort);
            this.Controls.Add(this.lbl_status);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExportForExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExportForExcel";
            this.Load += new System.EventHandler(this.ExportForExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.img_loading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_concluido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox img_loading;
        private System.Windows.Forms.PictureBox img_error;
        private System.Windows.Forms.PictureBox img_concluido;
        private System.Windows.Forms.Button btn_abort;
        private System.Windows.Forms.Label lbl_status;
    }
}