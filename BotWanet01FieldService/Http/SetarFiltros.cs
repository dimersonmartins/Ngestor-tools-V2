using BotWanet01FieldService.App;
using BotWanet01FieldService.XmlToObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BotWanet01FieldService.XmlToObject.RootXML;

namespace BotWanet01FieldService.Http
{
    class SetarFiltros 
    {
       
        public async Task<string> configurarFiltros()
        {
            try
            {
                Config.sesseion = GenereteKey(13);
                string url = @"http://wanet01.netservicos.com.br/net1/TD/TDMaster.asp?InstID=1&UID=" + Config.sesseion + "&Function=GetSessionInfo";
                HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
                client.Timeout = TimeSpan.FromHours(2);
                string[] AcceptEncoding = new string[] { "gzip", "deflate" };
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "*/*");
                client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
                client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
                client.DefaultRequestHeaders.Add("Referer", "wanet01.netservicos.com.br");
                client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);


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
                    WebTable filters = ReadXmlParseObj.Deserialize<WebTable>(contents);

                    foreach (var filter in filters.Rows.Row)
                    {
                        var typeOfFilters = filter.Split(',');
                        Config.servcices = separarFiltros(typeOfFilters[8], "", "|");
                        Config.vts = typeOfFilters[8].Replace(Config.servcices + "|", "");
                        break;
                    }
                    client.Dispose();
                }
                client.Dispose();
                return contents;
            }
            catch
            {
                return "[]";
            }
           
        }
        private string GenereteKey(int length)
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private string separarFiltros(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "Não encontrado!";
            }
        }
    }
}
