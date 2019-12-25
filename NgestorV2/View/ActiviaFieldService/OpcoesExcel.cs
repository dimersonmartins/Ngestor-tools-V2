using System;
using System.Windows.Forms;

namespace NgestorFieldServiceTools.View.ActiviaFieldService
{
    public partial class OpcoesExcel : Form
    {
        public OpcoesExcel()
        {
            InitializeComponent();
        }
        public string status_os = "";
        public int tipo_acao    = 0;
        public string data      = "";
        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            data = data_inicial.Text;
            if (os_concluidas.Checked)
            {
                status_os = "7";
            }
            if (os_canceladas.Checked)
            {
                status_os = "5";
            }
            if (os_arquivadas.Checked)
            {
                status_os = "8";
            }

            if (radio_excel_rapido.Checked)
            {
                tipo_acao = 2;
            }
            if (radio_excel_lento.Checked)
            {
                tipo_acao = 3;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void ImportacaoOpcoes_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
