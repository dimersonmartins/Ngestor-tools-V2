using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotNetHome.Repository
{
    public class HtmlTableToArray : IDisposable
    {
        private bool disposed;
        public HtmlTableToArray()
        {

        }
        ~HtmlTableToArray()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The virtual dispose method that allows
        /// classes inherithed from this one to dispose their resources.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources here.
                }

                // Dispose unmanaged resources here.
            }

            disposed = true;
        }

        public string[] trToArray(string html)
        {
            try
            {
               string[] trsList = html.Split(new string[] { "<TR>" }, StringSplitOptions.None);
               return trsList.Skip(1).ToArray();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

    }
}
