using BotActiviaClaroFieldService.App;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BotActiviaClaroFieldService.Http
{
   public class Roterizador
    {

        public Roterizador(string _data_inicial, string _data_final)
        {
            this.data_inicial = _data_inicial;
            this.data_final = _data_final;
        }

        private Dictionary<string, string> _FORM_DATA = new Dictionary<string, string>();
        private string data_inicial = null;
        private string data_final   = null;

        public async Task<string> GetOrders()
        {
            try
            {
                HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
                client.Timeout = TimeSpan.FromHours(2);

                string[] AcceptGetOrdersActivia = new string[] { "application/json", "text/plain", "*/*" };
                string[] AcceptEncodingGetOrdersActivia = new string[] { "gzip", "deflate", "br" };
                string[] AcceptLanguageGetOrdersActivia = new string[] { "pt-BR" };

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", AcceptGetOrdersActivia);
                client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncodingGetOrdersActivia);
                client.DefaultRequestHeaders.Add("Accept-Language", AcceptLanguageGetOrdersActivia);
                client.DefaultRequestHeaders.Add("Host", "clarofs.iclass.com.br:9081");
                client.DefaultRequestHeaders.Add("Referer", "http://embratelfs.activia.com.br/embratelfs/swf/roteirizadornetv2.lzx.swf?lzproxied=false");
                client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Config.tokenAcesso);

                HttpContent content = new FormUrlEncodedContent(_FORM_DATA);
                HttpResponseMessage response = await client.GetAsync("https://clarofs.iclass.com.br:9081/fs-am/api/roteirizador/os?dataAgendamentoFim=" + data_final + "&dataAgendamentoInicio=" + data_inicial + "&operadoraId=" + Config.idOperadora + "&slas=1&slas=2&slas=3&slas=4&slas=5&slas=6&slas=7&statusOS=ABERTA&statusOS=DESP_CRED&statusOS=DESP_EQPE&statusOS=ROT_CRED&statusOS=ROT_EQPE");
                var contents = await response.Content.ReadAsStringAsync();
                HttpContentHeaders headers = content.Headers;

                if (response.IsSuccessStatusCode)
                {
                    return contents;
                }

                return null;
            }

            catch
            {
                return null;
            }

        }
    }
}
