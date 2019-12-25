using DataBase;
using Newtonsoft.Json.Linq;
using NgestorFieldServiceTools.App;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NgestorFieldServiceTools.View.FieldService
{
    public partial class ExportForExcel : Form
    {
        public ExportForExcel(DataGridView data)
        {
            InitializeComponent();
            this._data = data;
        }

        private DataGridView _data;
        private string status = "";
        private string order = "";

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
            // createCsvFromDataGridView();
            importarTUDO();
        }

        private void createCsvFromDataGridView()
        {
            if (_data != null)
            {
                StringBuilder csv = new StringBuilder();
                csv.AppendLine("CONTRATO; CLIENTE; ENDERECO; BAIRRO; TELEFONE; TIPO_OS; PRODUTO; PERIODO; STATUS;");
                Thread thread = new Thread(() =>
                {
                    string json = "{\"jsonOS\": [";

                    for (int i = 0; i < _data.Rows.Count; i++)
                    {
                        json += _data.Rows[i].Cells[5].Value;
                    }
                    json += "]}";
                    var obJson = JObject.Parse(json.Replace(",]}", "]}"));

                    foreach (var itemOs in obJson["jsonOS"])
                    {
                        csv.AppendLine($"{itemOs["AccountID"].ToString()};" +
                            $"{itemOs["CustFirstName"].ToString()};" +
                            $"{itemOs["StreetAddress"].ToString()};" +
                            $"{itemOs["LocInfo1"].ToString()};" +
                            $"{itemOs["CustomerPhone1"].ToString()};" +
                            $"{itemOs["JobTypeDesc"].ToString()};" +
                            $"{itemOs["DetailExt1"].ToString()};" +
                            $"{itemOs["TimeSlotDesc"].ToString()};" +
                            $"{itemOs["StatusDesc"].ToString()};");
                    }

                    File.WriteAllText(Path.GetDirectoryName(Application.ExecutablePath) + "\\Ordem De Serviço Net.csv", csv.ToString());
                    status = "Concluido";
                })
                { IsBackground = true }; thread.Start();
            }
        }
        private void btn_abort_Click(object sender, EventArgs e)
        {
            if (btn_abort.Text == "Abrir o Arquivo")
            {
                Process process = new Process();
                process.StartInfo.FileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\Ordem De Serviço Net.csv";
                process.Start();
            }
            this.Close();
        }

#pragma warning disable CS1998 // Este método assíncrono não possui operadores 'await' e será executado de modo síncrono. É recomendável o uso do operador 'await' para aguardar chamadas à API desbloqueadas ou do operador 'await Task.Run(...)' para realizar um trabalho associado à CPU em um thread em segundo plano.
        private async void importarTUDO()
#pragma warning restore CS1998 // Este método assíncrono não possui operadores 'await' e será executado de modo síncrono. É recomendável o uso do operador 'await' para aguardar chamadas à API desbloqueadas ou do operador 'await Task.Run(...)' para realizar um trabalho associado à CPU em um thread em segundo plano.
        {
            try
            {
                DbMain db = new DbMain("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "Manager");
                var datatable = db.Query($"SELECT * FROM ordens_de_servicos WHERE id_dominio_ngestor = '{Config.id_dominio_ngestor}' AND id_sistemas_tipo = {Config.id_operadora_servidor}");

                string osJson = "{\"os_itens\": [";
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    var obj = JObject.Parse(datatable.Rows[i][6].ToString());
                    osJson += obj["os"][0].ToString() + ",";
                }
                osJson += "]}";
                var obJson = JObject.Parse(osJson);
                StringBuilder csv = new StringBuilder();
                csv.AppendLine("CONTRATO; CLIENTE; ENDERECO; BAIRRO; TELEFONE; TIPO_OS; PRODUTO; PERIODO; STATUS;");
                Thread thread = new Thread(() =>
                {
                    foreach (var itemOs in obJson["os_itens"])
                    {
                        csv.AppendLine($"{itemOs["AccountID"].ToString()};" +
                            $"{itemOs["CustFirstName"].ToString()};" +
                            $"{itemOs["StreetAddress"].ToString()};" +
                            $"{itemOs["LocInfo1"].ToString()};" +
                            $"{itemOs["CustomerPhone1"].ToString()};" +
                            $"{itemOs["JobTypeDesc"].ToString()};" +
                            $"{itemOs["DetailExt1"].ToString()};" +
                            $"{itemOs["TimeSlotDesc"].ToString()};" +
                            $"{itemOs["StatusDesc"].ToString()};");
                    }

                    File.WriteAllText(Path.GetDirectoryName(Application.ExecutablePath) + "\\Ordem De Serviço Net.csv", csv.ToString());
                    status = "Concluido";
                })
                { IsBackground = true }; thread.Start();
            }
            catch { }
        }
    }
}
