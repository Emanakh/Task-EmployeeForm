using EmployeeMVC.Models.DTOs;
using EmployeeMVC.Services.IServices;
using Newtonsoft.Json;
using System.Text;
using static EmployeeMVC.Enums.Enums;

namespace EmployeeMVC.Services
{
    public class MainService : IMainService
    {
        private readonly IHttpClientFactory _httpClient;

        public APIResponse _response { get; set; }

        public MainService(IHttpClientFactory httpClient, APIResponse response)
        {
            _response = response;
            _httpClient = httpClient;
        }


        public async Task<APIResponse> SendRequest(APIRequest apiRequest)
        {
            try
            {
                var client = _httpClient.CreateClient(); 

                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");

                //convert the url string to the Uri 
                message.RequestUri = new Uri(apiRequest.Url);

                if (apiRequest.Data != null) 
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
                }
                switch (apiRequest.apiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;

                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;

                }

				HttpResponseMessage apiResponse = await client.SendAsync(message);
                //convert the HTTP content to a string
                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                _response = JsonConvert.DeserializeObject<APIResponse>(apiContent);
                return _response;
              
            }
            catch (Exception e)
            {
                _response.ErrorMessages = new List<string> { (e.Message.ToString()) };
                _response.IsSuccess = false;
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return _response;
            }
        }

    }
}
