using BotNetHome.App;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BotNetHome.Http.Auth
{
    public class AuthNetHome
    { 
        public async Task<bool> getConteudo()
        {
            HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            client.Timeout = TimeSpan.FromHours(2);

            string[] Accept = new string[] { "image/gif", "image/jpeg", "image/pjpeg", "application/x-ms-application", "application/xaml+xml", "application/x-ms-xbap", "*/*" };
            string[] AcceptEncoding = new string[] { "gzip", "deflate" };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", Accept);
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
            client.DefaultRequestHeaders.Add("Referer", "https://updateasc.netservicos.com.br/home/portal.do");
            client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            client.DefaultRequestHeaders.Add("Host", "www.atlas.netservicos.com.br");
            
            client.DefaultRequestHeaders.Add("Cookie", "asc-key-remote=" + Config.ASC_KEY_REMOTE);

            HttpResponseMessage response = await client.GetAsync("https://www.atlas.netservicos.com.br/nethome/");
            var contents = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                Config._JSESSIONID = GetBetween.Between(response.Headers.ToString(), "Set-Cookie: ", "; path=/");
                client.Dispose();
                return true;                 
            }
            client.Dispose();
            return false;
        }
        public async Task<string[]> login()
        {
            Dictionary<string, string> form_data = new Dictionary<string, string>
            {
                { "j_username", Config.LOGIN },
                { "j_password", Config.PASSWORD },
                { "j_identity_base", Config.BASE_OPERADORA },
                { "j_system","5" },
                { "j_application","NATLAS" }
            };
            CookieContainer cookies = new CookieContainer();
            HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate, AllowAutoRedirect = false });
            client.Timeout = TimeSpan.FromHours(2);

            string[] Accept = new string[] { "image/gif", "image/jpeg", "image/pjpeg", "application/x-ms-application", "application/xaml+xml", "application/x-ms-xbap", "*/*" };
            string[] AcceptEncoding = new string[] { "gzip", "deflate" };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", Accept);
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
            client.DefaultRequestHeaders.Add("Referer", "https://updateasc.netservicos.com.br/home/portal.do");
            client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            client.DefaultRequestHeaders.Add("Host", "www.atlas.netservicos.com.br");
            client.DefaultRequestHeaders.Add("Cookie", "asc-key-remote=" + Config.ASC_KEY_REMOTE + ";" + Config._JSESSIONID);

            HttpContent content = new FormUrlEncodedContent(form_data);
            HttpResponseMessage response = await client.PostAsync("https://www.atlas.netservicos.com.br/nethome/j_security_check", content);
            var contents = await response.Content.ReadAsStringAsync();
            HttpContentHeaders headers = content.Headers;

            if (response.StatusCode.ToString() == "Redirect")
            {
                Config.AUTHCOOKIE = GetBetween.Between(response.Headers.ToString(), "Set-Cookie: ", "; path=/; secure");

                client.Dispose();

                return new string[]
                {
                    "asc-key-remote=" + Config.ASC_KEY_REMOTE,
                    Config._JSESSIONID,
                    Config.AUTHCOOKIE
                };

                
            }
            client.Dispose();
            return null;
        }
        public async Task<string> indexNetHome()
        {
            HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            client.Timeout = TimeSpan.FromHours(2);

            string[] Accept = new string[] { "image/gif", "image/jpeg", "image/pjpeg", "application/x-ms-application", "application/xaml+xml", "application/x-ms-xbap", "*/*" };
            string[] AcceptEncoding = new string[] { "gzip", "deflate" };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", Accept);
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
            client.DefaultRequestHeaders.Add("Referer", "https://www.atlas.netservicos.com.br/nethome/");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident/7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729)");
            client.DefaultRequestHeaders.Add("Host", "www.atlas.netservicos.com.br");
            client.DefaultRequestHeaders.Add("Cookie", "asc-key-remote=" + Config.ASC_KEY_REMOTE + ";" + Config._JSESSIONID + ";" + Config.AUTHCOOKIE);

            HttpResponseMessage response = await client.GetAsync("https://www.atlas.netservicos.com.br/nethome/index.do");
            var contents = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    client.Dispose();
                    return contents;
                }
                catch (Exception)
                {
                    return "[]";
                }
            }
            else
            {
                client.Dispose();
                return "[]";
            }
            client.Dispose();
        }
        private string setCOOKIE(string cookieName, IEnumerable<string> response)
        {
            foreach (var cookies in response)
            {
                string[] listCookies = cookies.Split(new string[] {"=",";" }, StringSplitOptions.None);
                foreach (var value in listCookies)
                {
                    if (value.Contains(cookieName))
                    {
                        return listCookies[0] + "=" + listCookies[1];
                    }
                }
            }

            return null;
        }
    }
}
