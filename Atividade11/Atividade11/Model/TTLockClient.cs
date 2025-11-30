using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Atividade11.Model
{
    public class TTLockClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _clientId;
        private readonly string _clientSecret;
        public string _accessToken;
        private readonly string _username;
        private readonly string _password;

        public TTLockClient(HttpClient httpClient, string clientId, string clientSecret, string accessToken, string username, string password)
        {
            _httpClient = httpClient;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _accessToken = accessToken;
            _username = username;
            _password = password;
        }

        public async Task<string> GerarAccessToken()
        {
            var url = "https://euapi.ttlock.com/oauth2/token";

            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("clientId", _clientId),
                new KeyValuePair<string, string>("clientSecret", _clientSecret),
                new KeyValuePair<string, string>("username", _username),
                new KeyValuePair<string, string>("password", _password),
            });

            using (var response = await _httpClient.PostAsync(url, formContent))
            {
                var responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(
                        string.Format("HTTP error {0}: {1}", response.StatusCode, responseBody)
                    );
                }

                TTLockTokenResponse jsonResponse = JsonConvert.DeserializeObject<TTLockTokenResponse>(responseBody);
                return jsonResponse.Access_Token;
            }       
        }

        public async Task<bool> UnlockAsync(int lockId)
        {
            var url = "https://euapi.ttlock.com/v3/lock/unlock";

            // Timestamp em milissegundos desde 1970-01-01 UTC
            long date = (long)(DateTime.UtcNow
                .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
                .TotalMilliseconds);

            var formContent = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("clientId", _clientId),
            new KeyValuePair<string, string>("accessToken", _accessToken),
            new KeyValuePair<string, string>("lockId", lockId.ToString()),
            new KeyValuePair<string, string>("date", date.ToString())
        });

            using (var response = await _httpClient.PostAsync(url, formContent))
            {
                var responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(
                        string.Format("HTTP error {0}: {1}", response.StatusCode, responseBody)
                    );
                }

                TTlockResponse ttResp;
                try
                {
                    ttResp = JsonConvert.DeserializeObject<TTlockResponse>(responseBody);
                }
                catch (Exception ex)
                {
                    throw new Exception("Falha ao interpretar o JSON de resposta da TTLock.", ex);
                }

                if (ttResp == null)
                {
                    throw new Exception("Resposta da TTLock veio vazia ou em formato inesperado.");
                }

                if (ttResp.errcode != 0)
                {
                    throw new Exception(
                        string.Format("TTLock error {0}: {1}", ttResp.errcode, ttResp.errmsg)
                    );
                }

                return true;
            }
        }
    }
}
