using DataBase;
using NgestorFieldServiceTools.App;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NgestorFieldServiceTools.View.Componentes.FiltrosPorServicos
{
    public partial class FiltroServico : Form
    {
        public FiltroServico()
        {
            InitializeComponent();
        }

        public List<KeyValuePair<int, string>> servicoslist = new List<KeyValuePair<int, string>>();
        private void btn_filter_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        CheckBox listServiceCheck(int key, string id, string value)
        {
            CheckBox box = new CheckBox();
            box.Name = id;
            box.Tag = value;
            box.Text = value;
            box.AutoSize = true;
            box.Location = new Point(20, key * 30); //vertical //box.Location = new Point(key * 50, 10); //horizontal           
            return box;
        }
        int clickSv = 0;
        private void checkServiceFilter(object servico, EventArgs e)
        {
            CheckBox currentChecked = (CheckBox)servico;
            servicoslist.Add(new KeyValuePair<int, string>(clickSv, currentChecked.Text));
            clickSv = +1;
        }

        private void FiltroServico_Load(object sender, EventArgs e)
        {
            DbMain dbMain = new DbMain("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "Manager");
            List<string> filtersList = dbMain.getFilters(Config.id_dominio_ngestor, Config.id_operadora_servidor);
            int key = 0;
            foreach (var item in filtersList)
            {
                CheckBox check = listServiceCheck(key, item, item);
                key++;

                flowLayoutPanel1.Controls.Add(check);
                check.Click += new System.EventHandler(this.checkServiceFilter);
            }
        }
    }
}
