using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Gateway.API.Helpers
{
    public static class HttpClientHelper
    {
        public static async Task<T> GetAsync<T>(string url,string token = null)
        {
            T? requestData = default(T);           
            using (var clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                using (var client = new HttpClient(clientHandler))
                {
                    string content =String.Empty;
                    StringContent stringContent = new StringContent(content,Encoding.UTF8, "application/json");                   
                    var request = new HttpRequestMessage(HttpMethod.Get, url);
                    request.Content = stringContent;
                    if (token != null)
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Substring(6).Trim());
                    var response = await client.SendAsync(request).Result.Content.ReadAsStringAsync();
                    if (response != null)
                        requestData = JsonConvert.DeserializeObject<T>(response) ?? throw new ArgumentNullException();
                }
            }


            return requestData;
        }

        public static async Task<T> PostAsync<T>(string url,string json,string? token=null)
        {
            T? requestData = default(T);

            using (var clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                using (var client = new HttpClient(clientHandler))
                {
                    string content = json;
                    var request = new HttpRequestMessage(HttpMethod.Post, url);
                    if (token != null)
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Substring(6).Trim());
                    StringContent stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                    request.Content = stringContent;
                    var response = await client.SendAsync(request).Result.Content.ReadAsStringAsync();
                    if (response != null)
                        requestData = JsonConvert.DeserializeObject<T>(response) ?? throw new ArgumentNullException();
                }
            }

            return requestData;
        }

        public static async Task<T> PutAsync<T>(string url,string json, string? token=null)
        {
            T? requestData = default(T);
            using (var clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                using (var client = new HttpClient(clientHandler))
                {
                    string content = json;
                    var request = new HttpRequestMessage(HttpMethod.Put, url);
                    if (token != null)
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Substring(6).Trim());
                    StringContent stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                    request.Content = stringContent;
                    var response = await client.SendAsync(request).Result.Content.ReadAsStringAsync();
                    if (response != null)
                        requestData = JsonConvert.DeserializeObject<T>(response) ?? throw new ArgumentNullException();
                }
            }
            return requestData;
        }
    }
}
