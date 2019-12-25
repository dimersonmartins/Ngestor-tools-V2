using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace NgestorFieldServiceTools.View.Componentes.Relatorio
{
    public partial class ReportExcel : Form
    {
        public ReportExcel(string tipoRelatorio)
        {
            InitializeComponent();
            _tipoRelatorio = tipoRelatorio;
        }
        private string _tipoRelatorio = null;
        private string pathFile = null;

        private Controllers.FieldService fieldService = null;
        private Controllers.Atlas atlas = null;



        private void ReportExcel_Load(object sender, EventArgs e)
        {
            executeTipoForm();
            startWatch();
        }


        Timer timer = new Timer();

        private void startWatch()
        {
            timer.Enabled = true;
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (fieldService != null)
            {
                if (fieldService.status)
                {
                    img_concluido.Visible = true;
                    img_loading.Visible = false;
                    img_error.Visible = false;
                    btn_open.Visible = true;
                    btn_open.Text = "Abrir";
                    lbl_status.Text = "Relatório finalizado";
                    timer.Enabled = false;
                }
                else
                {
                    img_concluido.Visible = false;
                    img_loading.Visible = false;
                    img_error.Visible = true;
                    lbl_status.Text = "Ocorreu um erro no processo!";
                    timer.Enabled = false;
                }
            }
            if (atlas != null)
            {
                if (atlas.status)
                {
                    img_concluido.Visible = true;
                    img_loading.Visible = false;
                    img_error.Visible = false;
                    btn_open.Visible = true;
                    btn_open.Text = "Abrir";
                    lbl_status.Text = "Relatório finalizado";
                    timer.Enabled = false;
                }
                else
                {
                    img_concluido.Visible = false;
                    img_loading.Visible = false;
                    img_error.Visible = true;
                    lbl_status.Text = "Ocorreu um erro no processo!";
                    timer.Enabled = false;
                }
            }
        }

#pragma warning disable CS1998 // Este método assíncrono não possui operadores 'await' e será executado de modo síncrono. É recomendável o uso do operador 'await' para aguardar chamadas à API desbloqueadas ou do operador 'await Task.Run(...)' para realizar um trabalho associado à CPU em um thread em segundo plano.
        private async void executeTipoForm()
#pragma warning restore CS1998 // Este método assíncrono não possui operadores 'await' e será executado de modo síncrono. É recomendável o uso do operador 'await' para aguardar chamadas à API desbloqueadas ou do operador 'await Task.Run(...)' para realizar um trabalho associado à CPU em um thread em segundo plano.
        {
            if (_tipoRelatorio == "fieldservice")
            {
                lbl_tipo.Text = "Field Service";
                fieldService = new Controllers.FieldService("field");
                fieldService.execute();
            }

            if (_tipoRelatorio == "activia")
            {
                lbl_tipo.Text = "Field Service";
                fieldService = new Controllers.FieldService("activia");
                fieldService.execute();
            }

            if (_tipoRelatorio == "atlas")
            {
                lbl_tipo.Text = "Atlas";
                atlas = new Controllers.Atlas();
                atlas.execute();
            }
        }



        private void btn_abort_Click(object sender, EventArgs e)
        {
            if (fieldService != null)
            {
                pathFile = fieldService.lastFileName;
            }
            if (atlas != null)
            {
                pathFile = atlas.lastFileName;
            }
            Process process = new Process();
            process.StartInfo.FileName = pathFile;
            process.Start();
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
