using BotNetfsActivia8080.App;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Helpers;
using System.Net;

namespace BotNetfsActivia8080.Http.Auth
{
    public class AuthNetfsActivia8080
    {
        public async Task<bool> execute()
        {
            Config.JSESSIONID = await getSession();
            if (string.IsNullOrWhiteSpace(Config.JSESSIONID))
            {
                return false;
            }

            return await logar();
        }

        private async Task<string> getSession()
        {
            HttpClient http = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            http.DefaultRequestHeaders.Clear();
            string[] accept = new string[] { "text/html", "application/xhtml+xml", "image/jxr", "*/*" };
            string[] acceptEncoding = new string[] { "gzip", "deflate" };
            http.DefaultRequestHeaders.Add("Accept", accept);
            http.DefaultRequestHeaders.Add("Accept-Encoding", acceptEncoding);
            http.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            http.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            http.DefaultRequestHeaders.Add("Referer", "http://netfs.activia.com.br:8080/activiafs/");
            Dictionary<string, string> form_data = new Dictionary<string, string>();
            HttpContent content = new FormUrlEncodedContent(form_data);
            HttpResponseMessage response = await http.GetAsync("http://netfs.activia.com.br:8080/activiafs/logonSSO.do?method=acaoLogon");
            var contents = await response.Content.ReadAsStringAsync();
            HttpContentHeaders headers = content.Headers;

            if (response.IsSuccessStatusCode)
            {
                GetBetween getBetween = new GetBetween();
                return getBetween.Between(response.Headers.ToString(), "Set-Cookie: ", "; Path=/activiafs");
            }
            return null;
        }

        private async Task<bool> logar()
        {
            HttpClient http = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            http.DefaultRequestHeaders.Clear();
            string[] accept = new string[] { "text/html", "application/xhtml+xml", "image/jxr", "*/*" };
            string[] acceptEncoding = new string[] { "gzip", "deflate" };
            http.DefaultRequestHeaders.Add("Accept", accept);
            http.DefaultRequestHeaders.Add("Accept-Encoding", acceptEncoding);
            http.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            http.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            http.DefaultRequestHeaders.Add("Referer", "http://netfs.activia.com.br:8080/activiafs/logonSSO.do?method=acaoLogon");
            http.DefaultRequestHeaders.Add("Host", "netfs.activia.com.br:8080");
            http.DefaultRequestHeaders.Add("Cookie", Config.JSESSIONID);
            Dictionary<string, string> form_data = new Dictionary<string, string>();

            form_data.Add("method", "executarLogon");
            form_data.Add("Param", "LOGON");
            form_data.Add("usrLogon", Config.LOGIN);
            form_data.Add("passLogon", Config.PASSWORD);
            form_data.Add("executarLogon", "Entrar");

            HttpContent content = new FormUrlEncodedContent(form_data);
            HttpResponseMessage response = await http.PostAsync("http://netfs.activia.com.br:8080/activiafs/logonSSO.do", content);
            var contents = await response.Content.ReadAsStringAsync();
            HttpContentHeaders headers = content.Headers;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
