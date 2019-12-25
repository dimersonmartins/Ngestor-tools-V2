using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BotNetHome.Http.PesquisaEmLote
{
    class IndexPageSerial
    {
        public async Task<string> index(string cookies)
        {
            HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate});
            client.Timeout = TimeSpan.FromHours(2);

            string[] AcceptEncoding = new string[] { "gzip", "deflate" };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
            client.DefaultRequestHeaders.Add("Referer", "https://www.atlas.netservicos.com.br/nethome/equipamento/relatorioEquipamentos.do?acao=prepareSearch");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident/7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729)");
            client.DefaultRequestHeaders.Add("Host", "www.atlas.netservicos.com.br");
            client.DefaultRequestHeaders.Add("Cookie", cookies);
            HttpResponseMessage response = await client.PostAsync("https://www.atlas.netservicos.com.br/nethome/equipamento/relatorioEquipamentos.do?acao=search", null);
            var contents = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    return contents;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
               
            }
        return null;
        }
    }
}
