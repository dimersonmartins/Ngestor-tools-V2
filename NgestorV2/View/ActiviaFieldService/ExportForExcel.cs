using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NgestorFieldServiceTools.View.ActiviaFieldService
{
    public partial class ExportForExcel : Form
    {
        public ExportForExcel(DataGridView data, string json, int tipo_entrada)
        {
            InitializeComponent();
            this._data = data;
            this._tipo_entrada = tipo_entrada;
            this._json = json;
        }
        private DataGridView _data;
        private string _json;
        private string status = "";
        private string order = "";
        private int _tipo_entrada = 0;
        private string fileNameExcel = "\\" + 
             DateTime.Now.ToString()
            .Replace("-", "")
            .Replace(":", "")
            .Replace("/","")
            .Replace(" ","") + ".csv";

        private string pathFile = Path.GetTempPath();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        private void startWatch()
        {
            timer.Enabled = true;
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            processForRelatorio();
            if (status == "Concluido")
            {
                lbl_status.Text = status;
                img_concluido.Visible = true;
                img_loading.Visible = false;
                img_error.Visible = false;
                btn_abort.Text = "Abrir o Arquivo";
                btn_abort.Visible = true;
                timer.Enabled = false;
            }
            else
            {
                lbl_status.Text = status;
                img_concluido.Visible = false;
                img_loading.Visible = false;
                img_error.Visible = true;
                btn_abort.Text = "Fechar";
                btn_abort.Visible = true;
                timer.Enabled = false;
            }

        }

        private void processForRelatorio()
        {
            lbl_status.Text = $"Gerando Relatório \r\n Processo: {order}";
        }

        private void ExportForExcel_Load(object sender, EventArgs e)
        {
            startWatch();
            if (_tipo_entrada == 1)
            {
                createCsvFromDataGridView();
            }
            if (_tipo_entrada == 2)
            {
                createCsvFromJson();
            }
        }

        private void createCsvFromDataGridView()
        {
            if (_data != null)
            {
                StringBuilder csv = new StringBuilder();
                //CSV HEADER
                csv.AppendLine("OS; " +
                    "CONTRATO; " +
                    "STATUS; " +
                    "CLIENTE; " +
                    "ENDERECO; " +
                    "BAIRRO; " +
                    "CIDADE; " +
                    "TELEFONES; " +
                    "TIPO OS; " +
                    "PRODUTO ATUAL; " +
                    "PRODUTO NOVO; " +
                    "DATA SOLICITACAO; " +
                    "PERIODO; " +
                    "STATUS CONTRATO; ");

                Thread thread = new Thread(() =>
                {
                    string json = "{\"jsonOS\": [";

                    for (int i = 0; i < _data.Rows.Count; i++)
                    {
                        json += _data.Rows[i].Cells[9].Value;
                    }
                    json += "]}";
                    var obJson = JObject.Parse(json.Replace(",]}", "]}"));
                    if (obJson != null)
                    {
                        foreach (var itemOs in obJson["jsonOS"])
                        {
                            string telefones = montedTelefones(itemOs["telCel"].ToString(), itemOs["telRes"].ToString());

                            csv.AppendLine($"{itemOs["numeroOs"].ToString()};" +
                                 $"{itemOs["numeroContrato"].ToString()};" +
                                 $"{itemOs["status"].ToString()};" +
                                 $"{itemOs["nomeCliente"].ToString()};" +
                                 $"{itemOs["endereco"].ToString()};" +
                                 $"{itemOs["bairro"].ToString()};" +
                                 $"{itemOs["cidade"].ToString()};" +
                                 $"{telefones};" +
                                 $"{itemOs["tipoOS"].ToString()};" +
                                 $"{itemOs["produtoAtual"].ToString()};" +
                                 $"{itemOs["produtoNovo"].ToString()};" +
                                 $"{itemOs["dataSolicitacao"].ToString()};" +
                                 $"{itemOs["periodoAgendamento"].ToString()};" +
                                 $"{itemOs["statusContrato"].ToString()};");
                        }

                        File.WriteAllText(pathFile + fileNameExcel, csv.ToString());
                        status = "Concluido";
                    }   
                })
                { IsBackground = true }; thread.Start();

            }

        }
        private void createCsvFromJson()
        {
            if (!string.IsNullOrWhiteSpace(_json))
            {
                StringBuilder csv = new StringBuilder();
                //CSV HEADER
                csv.AppendLine("OS; " +
                    "CONTRATO; " +
                    "STATUS; " +
                    "CLIENTE; " +
                    "ENDERECO; " +
                    "BAIRRO; " +
                    "CIDADE; " +
                    "TELEFONES; " +
                    "TIPO OS; " +
                    "PRODUTO ATUAL; " +
                    "PRODUTO NOVO; " +
                    "DATA SOLICITACAO; " +
                    "PERIODO; " +
                    "STATUS CONTRATO; ");
                Thread thread = new Thread(() =>
                {
                    var obJson = JObject.Parse(_json.Replace(",]}", "]}"));
                    if (obJson != null)
                    {
                        foreach (var itemOs in obJson["os_itens"])
                        {

                            string telefones = montedTelefones(itemOs["telCel"].ToString(), itemOs["telRes"].ToString());

                            csv.AppendLine($"{itemOs["numeroOs"].ToString()};" +
                                $"{itemOs["numeroContrato"].ToString()};" +
                                $"{itemOs["status"].ToString()};" +
                                $"{itemOs["nomeCliente"].ToString()};" +
                                $"{itemOs["endereco"].ToString()};" +
                                $"{itemOs["bairro"].ToString()};" +
                                $"{itemOs["cidade"].ToString()};" +
                                $"{telefones};" +
                                $"{itemOs["tipoOS"].ToString()};" +
                                $"{itemOs["produtoAtual"].ToString()};" +
                                $"{itemOs["produtoNovo"].ToString()};" +
                                $"{itemOs["dataSolicitacao"].ToString()};" +
                                $"{itemOs["periodoAgendamento"].ToString()};" +
                                $"{itemOs["statusContrato"].ToString()};");
                        }

                        File.WriteAllText(pathFile + fileNameExcel, csv.ToString());
                        status = "Concluido";
                    }
                   
                })
                { IsBackground = true }; thread.Start();
            }
        }

        private string montedTelefones(string celular, string residencial)
        {
            if (!string.IsNullOrWhiteSpace(celular) && !string.IsNullOrWhiteSpace(residencial))
            {
                return $"{celular} / {residencial}";
            }
            if (!string.IsNullOrWhiteSpace(celular))
            {
                return celular;
            }
            if (!string.IsNullOrWhiteSpace(residencial))
            {
                return residencial;
            }
            return null;
        }

        private void btn_abort_Click(object sender, EventArgs e)
        {
            if (btn_abort.Text == "Abrir o Arquivo")
            {
                Process process = new Process();
                process.StartInfo.FileName = pathFile + fileNameExcel;
                process.Start();
            }
            this.Close();
        }
    }
}
