using BotNetHome.App;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BotNetHome.Http.AllTerminaisEmpreiteira
{
    class DownloadContentRelatorio
    {
        public async Task<string> download(string url)
        {
            try
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
                client.DefaultRequestHeaders.Add("Cookie", Config.COOKIES[0] + "; " + Config.COOKIES[1] + "; " + Config.COOKIES[2]);
                HttpResponseMessage response = await client.GetAsync(url);
                var contents = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return contents;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
      
    }
}
