using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Journey.Helpers
{
    public class ServiceHelper<TRequest, TResponse>
    where TResponse : class
    where TRequest : class
    {
        private const string BaseUrl = "https://v2-api.obilet.com/api/";

        public async Task<TResponse> PostAsync(TRequest request, string method)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
                    //client.DefaultRequestHeaders.Add("Authorization", "Basic ZEdocGMybHpZV0p5WVc1a2JtVjNZbWx1");
                    //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                    client.DefaultRequestHeaders.Accept.Clear();
                    Uri myUri = new Uri("https://v2-api.obilet.com/api");

                    client.BaseAddress = myUri;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "token");

                    //var contentx = new StringContent(JsonConvert.SerializeObject(request), null, "application/json");

                    var reqMsg = new HttpRequestMessage(HttpMethod.Post, "/client/getsession")
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(request),Encoding.UTF8, "application/json")
                    };
                    
                    //reqMsg.Headers.Add("Authorization", "Basic ZEdocGMybHpZV0p5WVc1a2JtVjNZbWx1");
                    //reqMsg.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
                    //reqMsg.Headers.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    

                    var httpResponse = await client.SendAsync(reqMsg);
                    var content = await httpResponse.Content.ReadAsStringAsync();

                    if (!httpResponse.IsSuccessStatusCode && string.IsNullOrEmpty(content))
                        throw new Exception($"Status Code:{httpResponse.StatusCode}");
                    var response = JsonConvert.DeserializeObject<TResponse>(content);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
