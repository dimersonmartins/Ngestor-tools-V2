using BotASCWebBrowser.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BotASCWebBrowser.Http.Auth
{
    public class AuthAscWebBrowser
    {
        public async Task<string[]> execute()
        {
            Config.ASC_KEY_REMOTE = GenereteKey(8);
            return await login();
        }
        public string GenereteKey(int length)
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public async Task<string[]> login()
        {
            Dictionary<string, string> form_data = new Dictionary<string, string>
            {
                { "token", "20160708*Artit@ASCWebBrowserV1.1" },
                { "login","Enter Here" }
            };

            HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            client.Timeout = TimeSpan.FromHours(2);

            string[] AcceptEncoding = new string[] { "gzip", "deflate" };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident/7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729)");
            client.DefaultRequestHeaders.Add("Host", "updateasc.netservicos.com.br");
            client.DefaultRequestHeaders.Add("Cookie", "asc-key-remote=" + Config.ASC_KEY_REMOTE + ";BIGipServerpool_netascs_https=2244091146.47873.0000; BIGipServerPOOL-ASC_HTTPS=370744586.20480.0000; BIGipServerpool_netasc_https=2193759498.47873.00");

            HttpContent content = new FormUrlEncodedContent(form_data);
            HttpResponseMessage response = await client.PostAsync("https://updateasc.netservicos.com.br/home/portal.do", content);
            var contents = await response.Content.ReadAsStringAsync();
            HttpContentHeaders headers = content.Headers;

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    string resposta = response.Headers.ToString();
                    int postion_incial = resposta.IndexOf("Set-Cookie:");
                    Config.ASC_JSESSIONID = resposta.Substring(postion_incial, 75).Replace("Set-Cookie: ", "");

                    return new string[]
                    {
                        Config.ASC_KEY_REMOTE,
                        Config.ASC_JSESSIONID
                    };
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
