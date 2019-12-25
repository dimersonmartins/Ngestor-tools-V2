namespace NgestorFieldServiceTools.View.Home.ActiviaFieldServiceDashboard
{
    partial class Default
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

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Default));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuCards5 = new Bunifu.Framework.UI.BunifuCards();
            this.button1 = new System.Windows.Forms.Button();
            this.gridStatus = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_os = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS_os = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.bunifuCards5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCards5
            // 
            this.bunifuCards5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bunifuCards5.BackColor = System.Drawing.Color.White;
            this.bunifuCards5.BorderRadius = 5;
            this.bunifuCards5.BottomSahddow = true;
            this.bunifuCards5.color = System.Drawing.Color.Tomato;
            this.bunifuCards5.Controls.Add(this.button1);
            this.bunifuCards5.Controls.Add(this.gridStatus);
            this.bunifuCards5.Controls.Add(this.btn_refresh);
            this.bunifuCards5.Controls.Add(this.label13);
            this.bunifuCards5.LeftSahddow = false;
            this.bunifuCards5.Location = new System.Drawing.Point(5, 3);
            this.bunifuCards5.Name = "bunifuCards5";
            this.bunifuCards5.RightSahddow = true;
            this.bunifuCards5.ShadowDepth = 20;
            this.bunifuCards5.Size = new System.Drawing.Size(854, 529);
            this.bunifuCards5.TabIndex = 58;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 10F);
            this.button1.ForeColor = System.Drawing.Color.Tomato;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(3, 141);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 108);
            this.button1.TabIndex = 22;
            this.button1.Text = "Limpar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridStatus
            // 
            this.gridStatus.AllowUserToAddRows = false;
            this.gridStatus.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridStatus.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridStatus.BackgroundColor = System.Drawing.Color.White;
            this.gridStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridStatus.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.total_os,
            this.STATUS_os,
            this.Data});
            this.gridStatus.DoubleBuffered = true;
            this.gridStatus.EnableHeadersVisualStyles = false;
            this.gridStatus.HeaderBgColor = System.Drawing.Color.Tomato;
            this.gridStatus.HeaderForeColor = System.Drawing.Color.White;
            this.gridStatus.Location = new System.Drawing.Point(132, 25);
            this.gridStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridStatus.Name = "gridStatus";
            this.gridStatus.ReadOnly = true;
            this.gridStatus.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridStatus.Size = new System.Drawing.Size(719, 498);
            this.gridStatus.TabIndex = 21;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 40;
            // 
            // total_os
            // 
            this.total_os.HeaderText = "TOTAL DE OS ENVIDAS";
            this.total_os.Name = "total_os";
            this.total_os.ReadOnly = true;
            this.total_os.Width = 200;
            // 
            // STATUS_os
            // 
            this.STATUS_os.HeaderText = "STATUS";
            this.STATUS_os.Name = "STATUS_os";
            this.STATUS_os.ReadOnly = true;
            this.STATUS_os.Width = 130;
            // 
            // Data
            // 
            this.Data.HeaderText = "DATA e HORA";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Width = 300;
            // 
            // btn_refresh
            // 
            this.btn_refresh.BackColor = System.Drawing.Color.White;
            this.btn_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_refresh.Font = new System.Drawing.Font("Arial", 10F);
            this.btn_refresh.ForeColor = System.Drawing.Color.Tomato;
            this.btn_refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_refresh.Image")));
            this.btn_refresh.Location = new System.Drawing.Point(3, 25);
            this.btn_refresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(123, 108);
            this.btn_refresh.TabIndex = 19;
            this.btn_refresh.Text = "Atualizar";
            this.btn_refresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_refresh.UseVisualStyleBackColor = false;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Tomato;
            this.label13.Font = new System.Drawing.Font("Arial", 10F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(2, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(163, 16);
            this.label13.TabIndex = 1;
            this.label13.Text = "Histórico de Importações";
            // 
            // Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bunifuCards5);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Name = "Default";
            this.Size = new System.Drawing.Size(865, 535);
            this.Load += new System.EventHandler(this.Default_Load);
            this.bunifuCards5.ResumeLayout(false);
            this.bunifuCards5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuCards bunifuCards5;
        private Bunifu.Framework.UI.BunifuCustomDataGrid gridStatus;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_os;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS_os;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.Button button1;
    }
}
