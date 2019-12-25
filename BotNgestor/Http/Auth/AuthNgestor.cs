using BotNgestor.App;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BotNgestor.Http.Auth
{
    public class AuthNgestor
    {
        private string _ngestor_url_server;
        public AuthNgestor(string ngestor_url_server)
        {
            _ngestor_url_server   = ngestor_url_server;
        }
        public async Task<string> execute(string login, string password)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromHours(2);  //TEMPO LIMTE DE RESPOSTA DA REQUISÃO

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Config.token);

                Dictionary<string, string> form_data = new Dictionary<string, string>
                {
                    {"email", login },
                    {"password", password }
                };

                HttpContent content = new FormUrlEncodedContent(form_data);

                HttpResponseMessage response = await client.PostAsync($"{_ngestor_url_server}api-v1/auth_desktop", content);
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
