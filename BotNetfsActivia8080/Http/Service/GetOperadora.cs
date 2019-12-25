using BotNetfsActivia8080.App;
using Helpers;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BotNetfsActivia8080.Http.Service
{
    public class GetOperadora
    {
        private async Task<string> Operadora()
        {
            HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            client.Timeout = TimeSpan.FromHours(2);

            string[] AcceptEncoding = new string[] { "gzip", "deflate" };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Host", "netfs.activia.com.br:8080");
            client.DefaultRequestHeaders.Add("x-flash-version", " 32,0,0,114");
            client.DefaultRequestHeaders.Add("Referer", "http://netfs.activia.com.br:8080/activiafs/swf/roteirizadornetv2.lzx.swf?lzproxied=false");
            client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            client.DefaultRequestHeaders.Add("Cookie", Config.JSESSIONID);

            GenerateKey generateKey = new GenerateKey();

            HttpResponseMessage response = await client.GetAsync("http://netfs.activia.com.br:8080/activiafs/roteirizadornetv2.do?curPage=0&method=listaOperadoras&%5F%5Flzbc%5F%5F=" + generateKey.NumberKey(13));
            var contents = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return contents;
            }

            return null;
        }
    }
}
