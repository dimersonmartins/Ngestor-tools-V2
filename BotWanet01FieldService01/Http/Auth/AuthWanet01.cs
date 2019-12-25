using ApiWanet01FieldService01.App;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiWanet01FieldService01.Http.Auth
{
    class AuthWanet01
    {       
        public async Task<bool> execute()
        {
            if (!string.IsNullOrWhiteSpace(await getSession()))
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
        private async Task<bool> Login()
        {
            if (!string.IsNullOrEmpty(Config.login))
            {
                CultureInfo culture = CultureInfo.CurrentCulture;
                HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
                client.Timeout = TimeSpan.FromHours(2);
                client.DefaultRequestHeaders.Clear();
                Dictionary<string, string> body = new Dictionary<string, string>
                {
                    {"ClientLocale" , culture.LCID.ToString()},
                    {"Username" , Config.login},
                    {"Password" , Config.password },
                };
                client.DefaultRequestHeaders.Add("Accept", "image/gif");
                client.DefaultRequestHeaders.Add("Accept", "image/jpeg");
                client.DefaultRequestHeaders.Add("Accept", "image/pjpeg");
                client.DefaultRequestHeaders.Add("Accept", "application/x-ms-application");
                client.DefaultRequestHeaders.Add("Accept", "application/xaml+xml");
                client.DefaultRequestHeaders.Add("Accept", "application/x-ms-xbap");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
                client.DefaultRequestHeaders.Add("Referer", "http://wanet01.netservicos.com.br/net1/");
                client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
                client.DefaultRequestHeaders.Add("Accept-Encoding", "deflate");
                client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
                client.DefaultRequestHeaders.Add("Host", "wanet01.netservicos.com.br");

                string cookie = "";
                foreach (var coolies in Config.CookiesFromngestor_url_server)
                {
                    client.DefaultRequestHeaders.Add("Cookie", $"{coolies.Key}={coolies.Value}");
                    cookie = $"{coolies.Key}={coolies.Value}";
                }

                HttpContent content = new FormUrlEncodedContent(body);
                HttpResponseMessage response = await client.PostAsync("http://wanet01.netservicos.com.br/net1/login.asp", content);
                var contents = await response.Content.ReadAsStringAsync();
                HttpContentHeaders headers = content.Headers;

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                       
                        if (!contents.Contains("ERROR : 7721 Unknown User/Password "))
                        {
                            return true;
                        }
                        return false;
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
        private async Task<string> getSession()
        {

            Dictionary<string, string> body = new Dictionary<string, string>();
            HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            client.Timeout = TimeSpan.FromHours(2);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "deflate");
            client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            client.DefaultRequestHeaders.Add("Host", "wanet01.netservicos.com.br");
            client.DefaultRequestHeaders.Add("Cookie", $"nv=Username={Config.login}");

            HttpContent content = new FormUrlEncodedContent(body);
            HttpResponseMessage response = await client.GetAsync("http://wanet01.netservicos.com.br/net1/");
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
            return null;
        }
       
    }
}
