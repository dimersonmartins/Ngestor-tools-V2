using Newtonsoft.Json.Linq;
using BotActiviaClaroFieldService.App;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotActiviaClaroFieldService.Http.Auth
{
    class AuthActiviaClaro
    {
        private Dictionary<string, string> form_data = new Dictionary<string, string>();

        public async Task<bool> execute()
        {
            if (!string.IsNullOrWhiteSpace(await GetSession()))
            {
                try
                {
                    if (await Login())
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public async Task<string> GetSession()
        {
            Dictionary<string, string> body = new Dictionary<string, string>();
            HttpClient client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false, UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            client.Timeout = TimeSpan.FromHours(2);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Host", "clarofs.iclass.com.br");
            client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            client.DefaultRequestHeaders.Add("Accept", "text/html");
            client.DefaultRequestHeaders.Add("Accept", "application/xhtml+xml");
            client.DefaultRequestHeaders.Add("Accept", "application/xml");
            client.DefaultRequestHeaders.Add("Accept", "application/xml;q=0.9");
            client.DefaultRequestHeaders.Add("Accept", "image/webp");
            client.DefaultRequestHeaders.Add("Accept", "image/apng");
            client.DefaultRequestHeaders.Add("Accept", "*/*;q=0.8");
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Accept-Language", "pt;q=0.9");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US;q=0.8");
            client.DefaultRequestHeaders.Add("Accept-Language", "en;q=0.7");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "deflate");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "br");

            HttpContent content = new FormUrlEncodedContent(body);
            HttpResponseMessage response = await client.GetAsync("https://clarofs.iclass.com.br/activiafs/Gerente?Param=Login");
            var contents = await response.Content.ReadAsStringAsync();
            HttpContentHeaders headers = content.Headers;

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    Config.CookiesFromngestor_url_server.Clear();

                    var cookies = response.Headers.GetValues("Set-Cookie");
                    foreach (var cookie in cookies)
                    {
                        string[] cookiee = cookie.Replace("; path=/", "").Split('=');
                        Config.CookiesFromngestor_url_server.Add(cookiee[0], cookiee[1]);
                    }

                    return response.ToString();
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> Login()
        {

            if (!string.IsNullOrEmpty(Config.login))
            {
                HttpClient client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false, UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
                client.Timeout = TimeSpan.FromHours(2);
                client.DefaultRequestHeaders.Clear();

                Dictionary<string, string> body = new Dictionary<string, string>
                {
                    {"method" , "executarLogon"},
                    {"errorMessage" , ""},
                    {"usrLogon" , Config.login},
                    {"passLogon" , Config.password},
                    {"executarLogon" , "Entrar"},
                };
                client.DefaultRequestHeaders.Add("Host", "clarofs.iclass.com.br");
                client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
                client.DefaultRequestHeaders.Add("Accept", "text/html");
                client.DefaultRequestHeaders.Add("Accept", "application/xhtml+xml");
                client.DefaultRequestHeaders.Add("Accept", "application/xml;q=0.9");
                client.DefaultRequestHeaders.Add("Accept", "image/webp");
                client.DefaultRequestHeaders.Add("Accept", "image/apng");
                client.DefaultRequestHeaders.Add("Accept", "*/*;q=0.8");
                client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
                client.DefaultRequestHeaders.Add("Accept-Language", "pt;q=0.9");
                client.DefaultRequestHeaders.Add("Accept-Language", "en-US;q=0.8");
                client.DefaultRequestHeaders.Add("Accept-Language", "en;q=0.7");
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
                client.DefaultRequestHeaders.Add("Accept-Encoding", "deflate");
                client.DefaultRequestHeaders.Add("Accept-Encoding", "br");
                client.DefaultRequestHeaders.Add("Referer", "https://clarofs.iclass.com.br/activiafs/logonSSO.do?method=acaoLogon");
                string cookie = "";
                foreach (var coolies in Config.CookiesFromngestor_url_server)
                {
                    client.DefaultRequestHeaders.Add("Cookie", $"{coolies.Key}={coolies.Value}");
                    cookie = $"{coolies.Key}={coolies.Value}";
                }

                HttpContent content = new FormUrlEncodedContent(body);
                HttpResponseMessage response = await client.PostAsync("https://clarofs.iclass.com.br/activiafs/logonSSO.do;" + cookie, content);
                var contents = await response.Content.ReadAsStringAsync();
                HttpContentHeaders headers = content.Headers;

                if (response.IsSuccessStatusCode)
                {
                    try
                    {

                        if (contents.Contains("Usuário ou senha inválidos"))
                        {
                            return false;
                        }

                        var cookies = response.Headers.GetValues("Set-Cookie");
                        foreach (var token in cookies)
                        {
                            string[] cookiee = token.Replace("; path=/", "").Replace("; Domain", "").Split('=');
                            Config.tokenAcesso = $"{cookiee[1]}";
                        }

                        await getIdOperadora();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Usuário não possui senha cadastrada para este dominio", "Ngestor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        private async Task<bool> getIdOperadora()
        {

            HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            client.Timeout = TimeSpan.FromHours(2);
            string[] AcceptEncoding = new string[] { "gzip", "deflate", "br" };
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Host", "clarofs.iclass.com.br:9081");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Accept", "text/plain");
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
            client.DefaultRequestHeaders.Add("Referer", "https://clarofs.iclass.com.br:9082/");
            client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Config.tokenAcesso);

            HttpContent content = new FormUrlEncodedContent(form_data);
            HttpResponseMessage response = await client.GetAsync("https://clarofs.iclass.com.br:9081/fs-am/api/operadoras/");
            // HttpResponseMessage response = await client.GetAsync("https://clarofs.iclass.com.br:9081/fs-am/api/operadoras?osFiltroId=" + Config.idCredenciada);
            var contents = await response.Content.ReadAsStringAsync();
            HttpContentHeaders headers = content.Headers;

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    string response_json = contents.Replace("[{", "{\"operadora\": [{") + "}";
                    var obJson = JObject.Parse(response_json);

                    Config.nomeOperadora = obJson["operadora"][0]["nome"].ToString();
                    Config.idOperadora = obJson["operadora"][0]["id"].ToString();
                }
                catch
                {
                    //ELog elog = new ELog();
                    //elog.log("Get idOperadora activia", ex.Message);
                }

                return true;

            }

            return false;
        }
        public async Task<bool> CheckConnection()
        {

            HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            client.Timeout = TimeSpan.FromHours(2);
            string[] AcceptEncoding = new string[] { "gzip", "deflate", "br" };
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Host", "clarofs.iclass.com.br:9081");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Accept", "text/plain");
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
            client.DefaultRequestHeaders.Add("Referer", "https://clarofs.iclass.com.br:9082/");
            client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Config.tokenAcesso);

            HttpContent content = new FormUrlEncodedContent(form_data);
            HttpResponseMessage response = await client.GetAsync("https://clarofs.iclass.com.br:9081/fs-am/api/operadoras/");

            var contents = await response.Content.ReadAsStringAsync();
            HttpContentHeaders headers = content.Headers;

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    if (response.StatusCode.ToString() == "OK")
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }
    }
}
