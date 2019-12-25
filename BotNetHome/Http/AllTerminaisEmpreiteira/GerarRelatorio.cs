using BotNetHome.App;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
namespace BotNetHome.Http.AllTerminaisEmpreiteira
{
    public class GerarRelatorio
    {
        public async Task<string> gerarRelatorio(string DWR)
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
                client.DefaultRequestHeaders.Add("Referer", "https://www.atlas.netservicos.com.br/nethome/equipamento/relatorioEquipamentos.do?acao=prepareSearch");
                client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
                client.DefaultRequestHeaders.Add("Host", "www.atlas.netservicos.com.br");
                client.DefaultRequestHeaders.Add("Cookie", Config.COOKIES[0] + "; " + Config.COOKIES[1] + "; " + Config.COOKIES[2]);

                var content = new StringContent(DWR);

                content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");

                HttpResponseMessage response = await client.PostAsync("https://www.atlas.netservicos.com.br/nethome/dwr/plaincall/BaseDWR.executeService.dwr", content);
                var contents = await response.Content.ReadAsStringAsync();
                HttpContentHeaders headers = content.Headers;

                if (response.IsSuccessStatusCode)
                {
                    client.Dispose();
                    return contents;
                }
                client.Dispose();
            }
            catch
            {
                return null;
            }
           
            return null;
        }
    }
}
