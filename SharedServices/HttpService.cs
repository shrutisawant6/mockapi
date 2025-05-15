using MockAPI.SharedServices.ExceptionHandling;
using Newtonsoft.Json;
using System.Text;

namespace MockAPI.SharedServices
{
    public interface IHttpService
    {
        Task<string> GetDataAsync(string url);

        Task<string> PostDataAsync(string url, object data);

        Task<string> DeleteDataAsync(string url, string id);
    }

    public class HttpService : IHttpService
    {
        private static readonly string MainUrl = "https://api.restful-api.dev/objects";
        private static readonly string GetAllObjects = "https://api.restful-api.dev/objects";

        private readonly HttpClient _httpClient;

        public HttpService()
        {
            _httpClient = new HttpClient();
        }


        public async Task<string> GetDataAsync(string url)
        {
            try
            {

                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();

            }
            catch (Exception ex)
            {
            }
            return string.Empty;
        }

        public async Task<string> PostDataAsync(string url, object data)
        {

            string json = JsonConvert.SerializeObject(data); ;
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();

        }

        public async Task<string> DeleteDataAsync(string url, string id)
        {
            try
            {
                var finalurl = $"{url}/{id}";

                HttpResponseMessage response = await _httpClient.DeleteAsync(finalurl);

                if(response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new CustomHttpResponseException((int)response.StatusCode, response.ReasonPhrase);

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch(CustomHttpResponseException custEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
