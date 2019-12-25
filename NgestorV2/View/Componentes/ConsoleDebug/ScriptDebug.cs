using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NgestorFieldServiceTools.View.Componentes.ConsoleDebug
{
    public partial class ScriptDebug : Form
    {
        public ScriptDebug(string value)
        {
            InitializeComponent();
            this._value = value;
        }
        private string _value;
        private void ScriptDebug_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_value))
            {
                content.AppendText(_value);
            }
           
        }
    }
}
