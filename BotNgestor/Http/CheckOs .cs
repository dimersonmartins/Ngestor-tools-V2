using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BotNgestor.Http
{
    public class CheckOs
    {
        public async Task<string> ordensServicos(string token, string postUrl, string data, string sistema)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromHours(2);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                MultipartFormDataContent content = new MultipartFormDataContent();
                content.Add(new StringContent(data, Encoding.UTF8, "application/json"), "lista_os");

                HttpResponseMessage response = await client.PostAsync(postUrl + $"api-v1/appdesktop/{sistema}/verificar_os", content);
                var contents = await response.Content.ReadAsStringAsync();
                HttpContentHeaders headers = content.Headers;

                if (response.IsSuccessStatusCode)
                {
                    client.Dispose();
                    return contents;
                }
                client.Dispose();
            }
            catch
            {
                return null;
            }
            return null;
        }
    }
}
