using BotNetHome.App;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BotNetHome.Http.RequestDWR
{
    class DWR
    {
        public DWR(DWRParameters dWRParameters)
        {
             dWRParameters.KEYSESSION = GenerateKeys.GenereteKeyNumber(4) + 
                                        "_" + GenerateKeys.GenereteKeyNumber(11);
            _dWRParameters = dWRParameters;
        }
        DWRParameters _dWRParameters;
        public async Task<bool> GetSessionDWR()
        {
            HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            client.Timeout = TimeSpan.FromHours(2);

            string[] Accept = new string[] { "*/*" };
            string[] AcceptEncoding = new string[] { "gzip", "deflate" };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", Accept);
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
            client.DefaultRequestHeaders.Add("Referer", "https://www.atlas.netservicos.com.br/nethome/equipamento/relatorioEquipamentos.do?acao=prepareSearch");
            client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            client.DefaultRequestHeaders.Add("Host", "www.atlas.netservicos.com.br");
            client.DefaultRequestHeaders.Add("Cookie", Config.COOKIES[0] + "; " + Config.COOKIES[1] + "; " + Config.COOKIES[2]);

            HttpResponseMessage response = await client.GetAsync("https://www.atlas.netservicos.com.br/nethome/dwr/engine.js");
            var contents = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    _dWRParameters.DWRKEYSESSION = GetBetween.Between(contents, "DWREngine._scriptSessionId = ", ";").Replace("\"", "");
                    return true;
                }
                catch { return false; }
            }
            return false;
        }
        
    }
}
