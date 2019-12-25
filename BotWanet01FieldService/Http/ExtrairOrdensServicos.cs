using BotWanet01FieldService.App;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BotWanet01FieldService.Http
{
    public  class ExtrairOrdensServicos
    {
        public delegate void httpSuccessCallBackData(string result);
        public async Task<string> GetOrders()
        {     
            string url = @"http://wanet01.netservicos.com.br/net1/TD/TDMaster.asp?InstID=1&UID=" + Config.sesseion;

            HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            client.Timeout = TimeSpan.FromHours(2);

            string[] AcceptEncoding = new string[] { "gzip", "deflate" };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
            client.DefaultRequestHeaders.Add("Referer", "http://wanet01.netservicos.com.br/net1/TD/TDMain1.asp?InstID=1");
            client.DefaultRequestHeaders.Add("Host", "wanet01.netservicos.com.br");
            client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            client.DefaultRequestHeaders.Add("Cookie", $"nv=Username={Config.login}");

            string cookie = "";
            foreach (var coolies in Config.CookiesFromngestor_url_server)
            {
                client.DefaultRequestHeaders.Add("Cookie", $"{coolies.Key}={coolies.Value}");
                cookie = $"{coolies.Key}={coolies.Value}";
            }

            string dateNow = DateTime.ParseExact(DateTime.Now.ToShortDateString(),
                "dd/MM/yyyy", CultureInfo.InvariantCulture)
                .ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            Dictionary<string, string> form_data = new Dictionary<string, string>();

            form_data = new Dictionary<string, string>
            {
                { "Function",        "GetWorkOrders" },
                { "Initial",         "true" },
                { "StartSchedDate",  dateNow },
                { "EndSchedDate",    dateNow },
                { "FilterJobStatus", "1|AS|IP|CP|JC|XO|ND" },
                { "FilterRole",      "0" },
                { "FilterFsrBUID",   "0|" + Config.servcices},
                { "AddlColumns",     "LastTardyMin,LastLagMin,CoordX,CoordY,Tag,Pending,Error,Submitted,ErrorMessage" },
                { "WorkDate",        dateNow }
            };

            HttpContent content = new FormUrlEncodedContent(form_data);
            HttpResponseMessage response = await client.PostAsync(url, content);
            var contents = await response.Content.ReadAsStringAsync();
            HttpContentHeaders headers = content.Headers;

            if (response.IsSuccessStatusCode)
            {
                client.Dispose();
                return contents;
            }
            client.Dispose();
            return null;
        }
        public async Task<string> GetOrderByWo(string WorkOrderUID)
        {
            string url = "http://wanet01.netservicos.com.br/net1/TD/TDMaster.asp?InstID=1&UID=" + Config.sesseion + "&Function=GetAllInformation&FilterWorkOrder=1|" + WorkOrderUID;
            HttpClient client = new HttpClient(
                new HttpClientHandler
                {
                    UseCookies = false,
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                });
            client.Timeout = TimeSpan.FromHours(2);

            string[] AcceptEncoding = new string[] { "gzip", "deflate" };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Referer", "http://wanet01.netservicos.com.br/net1/TD/TDMain1.asp?InstID=1");
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
            client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            client.DefaultRequestHeaders.Add("Host", "wanet01.netservicos.com.br");
            client.DefaultRequestHeaders.Add("Cookie", $"nv=Username={Config.login}");

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
                client.Dispose();
                return contents;
            }
            client.Dispose();
            return null;
        }
    }
}
