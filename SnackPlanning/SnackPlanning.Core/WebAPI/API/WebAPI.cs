using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SnackPlanning.Core.WebAPI.API
{
    public class WebAPI
    {
        private const string WEB_API_URL = "https://snackplanning-snackplan.azurewebsites.net";

        HttpClient _httpClient;

        public WebAPI()
        {
            if (_httpClient != null)
                return;
            
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(WEB_API_URL)
            };
        }

        public async Task<T> Send<T>(string requestRoute, Object obj) where T : class
        {
            var jsonUserCredentials = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            var httpContent = new StringContent(jsonUserCredentials, Encoding.UTF8, "application/json");

             return await _httpClient.PostAsync(requestRoute, httpContent)
                       .ContinueWith((Task<HttpResponseMessage> arg) =>
                        {
                            var response = arg.Result.Content.ReadAsStringAsync().Result;

                            if (response == null)
                                return null;


                            var responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);

                            return responseObject;
                        });
         }
    }
}
