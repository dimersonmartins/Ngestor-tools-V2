using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BotNgestor.Http
{
    public class Importacao :IDisposable
    {
        private bool disposed;
        public Importacao()
        {

        }
        ~Importacao()
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
        public async Task<bool> servicos(string token, string ngestor_url_server, string data, string sistema)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromHours(2);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                MultipartFormDataContent content = new MultipartFormDataContent();
                content.Add(new StringContent(data, Encoding.UTF8, "application/json"), "import");

                HttpResponseMessage response = await client.PostAsync(ngestor_url_server + $"api-v1/appdesktop/{sistema}/import", content);
                var contents = await response.Content.ReadAsStringAsync();
                HttpContentHeaders headers = content.Headers;

                if (response.IsSuccessStatusCode)
                {
                    client.Dispose();
                    return true;
                }
                client.Dispose();
            }
            catch
            {
                return false;
            }
           
            return false;
        }
        public async Task<string> seriais(string token, string postUrl, string path)
        {
            try
            {
                HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
                client.Timeout = TimeSpan.FromHours(2);
                string[] AcceptEncoding = new string[] { "gzip", "deflate" };
                string[] AcceptLenguage = new string[] { "pt-BR", "pt;q=0.8", "en-US;q=0.5", "en;q=0.3" };

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Add("Accept-Language", AcceptLenguage);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Accept", "text/plain");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
                client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);

                FileStream fs = File.OpenRead(path);

                MultipartFormDataContent content = new MultipartFormDataContent
                {
                    {new StringContent("6"),"idTipoProcesso"},
                    {new StreamContent(fs), "fileAtlas", path }
                };

                HttpResponseMessage response = await client.PostAsync(postUrl + $"api-v1/estoque/serializado/serialAuditoriaAtlasImportarOnline", content);
                var contents = await response.Content.ReadAsStringAsync();
                HttpContentHeaders headers = content.Headers;

                if (response.IsSuccessStatusCode)
                {
                    fs.Close();
                    client.Dispose();
                    return contents;
                }
                fs.Close();
                client.Dispose();
            }
            catch
            {
                return null;
            }
            return null;

        }

        public async Task<bool> updateEquipes(string token, string ngestor_url_server, string data)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromHours(2);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                MultipartFormDataContent content = new MultipartFormDataContent();
                content.Add(new StringContent(data, Encoding.UTF8, "application/json"), "import");

                HttpResponseMessage response = await client.PostAsync(ngestor_url_server + $"api-v1/admin/equipe/nova", content);
                var contents = await response.Content.ReadAsStringAsync();
                HttpContentHeaders headers = content.Headers;

                if (response.IsSuccessStatusCode)
                {
                    client.Dispose();
                    return true;
                }
                client.Dispose();
            }
            catch
            {
                return false;
            }

            return false;
        }

    }
}
