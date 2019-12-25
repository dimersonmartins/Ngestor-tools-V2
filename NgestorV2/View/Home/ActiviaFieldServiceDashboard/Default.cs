using DataBase;
using NgestorFieldServiceTools.App;
using NgestorFieldServiceTools.Http.Controllers.Service;
using System;
using System.Data;
using System.Windows.Forms;

namespace NgestorFieldServiceTools.View.Home.ActiviaFieldServiceDashboard
{
    public partial class Default : UserControl
    {
        public Default()
        {
            InitializeComponent();
        }
       
        private void Default_Load(object sender, EventArgs e)
        {
            try
            {
                list_status();
                IndexServiceController indexServiceController = new IndexServiceController();
                indexServiceController.execute();
            }
            catch { }          
        }

       
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            list_status();
        }

        private void list_status()
        {
            DbMain database = new DbMain("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "Manager");
            DataTable dataTable = database.Query($"SELECT * FROM ngestor_importacoes_automatica WHERE id_dominio_ngestor = {Config.id_dominio_ngestor} AND id_user = {Config.id_user_ngestor} AND id_sistemas_tipo = {Config.id_operadora_servidor} ORDER BY id DESC");
            gridStatus.Rows.Clear();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                try
                {
                    var table_status = database.Query($"SELECT name FROM status WHERE id = {dataTable.Rows[i][3]}");
                    gridStatus.Rows.Add(
                        dataTable.Rows[i][0].ToString(),
                        dataTable.Rows[i][5].ToString(),
                        table_status.Rows[0][0].ToString(),
                        dataTable.Rows[i][6].ToString()
                        );
                }
                catch
                {
                    continue;
                }
            }
        }

    
        private void button1_Click(object sender, EventArgs e)
        {
            DbMain database = new DbMain("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "Manager");
            database.ExecuteSqlCommand($"DELETE FROM ngestor_importacoes_automatica WHERE id_dominio_ngestor = {Config.id_dominio_ngestor} AND id_user = {Config.id_user_ngestor} AND id_sistemas_tipo = {Config.id_operadora_servidor}");
            list_status();
        }
    }
}
