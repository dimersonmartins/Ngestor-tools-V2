using BotNetHome.App;
using System;
using System.Threading.Tasks;

namespace BotNetHome.Repository
{
    public class NetHomeStartAutoImport :IDisposable
    {
        private bool disposed;
        public NetHomeStartAutoImport()
        {

        }
        ~NetHomeStartAutoImport()
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

        public NetHomeStartAutoImport(
            string LOGIN,
            string PASSWORD,
            string TOKEN_NGESTOR,
            int ID_DOMINIO_NGESTOR,
            int ID_USER_NGESTOR,
            string NGESTOR_URL_SERVER,
            string CODIGO_ATLAS,
            string CODIGO_OPERACAO,
            string BASE_OPERADORA,
            string TIPO_FILTRO_OPEARADORA,
            string CODIGO_LOCALIZACAO)
        {
            Config.LOGIN                    = LOGIN;
            Config.PASSWORD                 = PASSWORD;
            Config.TOKEN_NGESTOR            = TOKEN_NGESTOR;
            Config.NGESTOR_URL_SERVER       = NGESTOR_URL_SERVER;
            Config.ID_DOMINIO_NGESTOR       = ID_DOMINIO_NGESTOR;
            Config.ID_USER_NGESTOR          = ID_USER_NGESTOR;
            Config.CODIGO_ATLAS             = CODIGO_ATLAS;
            Config.CODIGO_OPERACAO          = CODIGO_OPERACAO;
            Config.BASE_OPERADORA           = BASE_OPERADORA;
            Config.TIPO_FILTRO_OPEARADORA   = TIPO_FILTRO_OPEARADORA;
            Config.CODIGO_LOCALIZACAO       = CODIGO_LOCALIZACAO;
        }

        public async Task<bool> start()
        {
            NetHomeManager netHomeManager = new NetHomeManager();
            if (string.IsNullOrWhiteSpace(Config.CODIGO_ATLAS))
            {
                return false;
            }
            Config.COOKIES = await netHomeManager.connect();
            if (Config.COOKIES != null)
            {
                string dwrContent        = await netHomeManager.montedDWR();

                Config.ID_TASK_RELATORIO = await netHomeManager.generateRelatorio(dwrContent);

                NetHomeManager.hasProcess = true;

                if (NetHomeManager.hasProcess)
                {
                    netHomeManager.checkTASK();
                }
               
            }
         
            return true;
        }

    }
}
