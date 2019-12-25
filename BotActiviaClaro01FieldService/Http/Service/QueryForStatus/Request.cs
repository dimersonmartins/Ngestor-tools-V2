using BotActiviaClaroFieldService.App;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BotActiviaClaroFieldService.Http.QueryForStatus
{
    class Request
    {
        public Request(int tipoForm)
        {
            this.tipoForm = tipoForm;
        }
        private int tipoForm;
        public delegate void httpSuccessCallBackData(string result);
        public async Task<string> contatro_Endereco(string url, string num_os)
        {
            try
            {
                string useragent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:52.0) Gecko/20100101 Firefox/52.0";
                HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
                client.Timeout = TimeSpan.FromHours(2);

                client.DefaultRequestHeaders.Clear();

                string[] AcceptGetOrdersActivia = new string[] { "application/xhtml+xml", "text/plain", "application/xml;q=0.9", "image/webp", "image/apng", "*/*" };
                string[] AcceptEncodingGetOrdersActivia = new string[] { "gzip", "deflate", "br" };
                string[] AcceptLanguageGetOrdersActivia = new string[] { "pt-BR", "pt;q=0.9", "en-US;q=0.8", "en;q=0.7" };

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", AcceptGetOrdersActivia);
                client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncodingGetOrdersActivia);
                client.DefaultRequestHeaders.Add("Accept-Language", AcceptLanguageGetOrdersActivia);
                client.DefaultRequestHeaders.Add("Host", "clarofs.iclass.com.br");
                client.DefaultRequestHeaders.Add("Referer", "https://clarofs.iclass.com.br/activiafs/Gerente?hid_Acao=principalresultado&hid_IdObj=" + tipoForm + "&hid_MeuId=2121" + num_os);
                client.DefaultRequestHeaders.Add("User-Agent", useragent);

                string cookie = "";
                foreach (var coolies in Config.CookiesFromngestor_url_server)
                {
                    client.DefaultRequestHeaders.Add("Cookie", $"{coolies.Key}={coolies.Value}");
                    cookie = $"{coolies.Key}={coolies.Value}";
                }

                Dictionary<string, string> form_data = new Dictionary<string, string>();
                HttpContent content = new FormUrlEncodedContent(form_data);

                HttpResponseMessage response = await client.GetAsync(url);
                var contents = await response.Content.ReadAsStringAsync();
                HttpContentHeaders headers = content.Headers;

                if (response.IsSuccessStatusCode)
                {
                    return contents;
                }
            }
            catch
            {
                return "Conexão indisponivel!";
            }
            return "Conexão indisponivel!";
        }
    }
}
