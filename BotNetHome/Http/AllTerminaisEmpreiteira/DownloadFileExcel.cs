using BotNetHome.App;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BotNetHome.Http.AllTerminaisEmpreiteira
{
    static class DownloadExcel
    {
        public static async Task<bool> force(string URI, string COOKIES, string FILE_NAME)
        {
            HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            client.Timeout = TimeSpan.FromHours(2);

            string[] AcceptEncoding = new string[] { "gzip", "deflate" };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
            client.DefaultRequestHeaders.Add("Referer", "https://www.atlas.netservicos.com.br/nettask/filas/detalhes.do?idFila=153752498&status=2&tipoConsulta=consultaId&alterar=no&visualizado=false&carregar=yes");
            client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            client.DefaultRequestHeaders.Add("Host", "batatlas.netservicos.com.br");
            client.DefaultRequestHeaders.Add("Cookie", COOKIES);
            // Send asynchronous request
            await client.GetAsync(URI).ContinueWith(
                (requestTask) =>
                {
                // Get HTTP response from completed task.
                HttpResponseMessage response = requestTask.Result;
                // Check that response was successful or throw exception
                response.EnsureSuccessStatusCode();

                // Read response asynchronously and save to file
                response.Content.ReadAsFileAsync(FILE_NAME, true);
                });
            client.Dispose();
            return true;
        }
        public static async Task<bool> ReadAsFileAsync(this HttpContent content, string filename, bool overwrite)
        {
            //string pathname = Path.GetFullPath(filename); //LOCAL ONDE O ARQUIVA VAI SER SALVO
            string pathname = AppDomain.CurrentDomain.BaseDirectory;

            if (!Directory.Exists(pathname))
            {
                DirectoryInfo directory = Directory.CreateDirectory(pathname);
            }

            if (!overwrite && File.Exists(pathname + "/" + filename))
            {
                throw new InvalidOperationException(string.Format("File {0} already exists.", pathname));
            }

            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(pathname + "/" + filename, FileMode.Create, FileAccess.Write, FileShare.None);

                await content.CopyToAsync(fileStream).ContinueWith(
                (copyTask) =>
                {
                    fileStream.Close();
                });

                return true;
            }
            catch
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }

                throw;
            }
        }  
    }
}
