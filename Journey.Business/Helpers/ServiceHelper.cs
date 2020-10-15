using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Journey.Business.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace Journey.Helpers
{
    public class ServiceHelper<TRequest, TResponse>
    where TResponse : class
    where TRequest : class
    {
        public async Task<TResponse> PostAsync(TRequest request, string method)
        {
            try
            {

                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                configurationBuilder.AddJsonFile(path, false);
                var root = configurationBuilder.Build();
                var token = root.GetSection("Api").GetSection("ApiToken").Value;
                var baseUrl = root.GetSection("Api").GetSection("ApiUrl").Value;

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);

                    var reqMsg = new HttpRequestMessage(HttpMethod.Post, baseUrl+method)
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(request),Encoding.UTF8, "application/json")
                    };
                    
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
                throw new Exception("ServiceHelper:"+ex.ToString());
            }
        }
    }
}
