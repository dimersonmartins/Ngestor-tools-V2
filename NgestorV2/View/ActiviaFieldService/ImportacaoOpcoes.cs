using System;
using System.Windows.Forms;

namespace NgestorFieldServiceTools.View.ActiviaFieldService
{
    public partial class ImportacaoOpcoes : Form
    {
        public ImportacaoOpcoes()
        {
            InitializeComponent();
        }
        public string status_os = "";
        public int tipo_acao    = 1;
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
