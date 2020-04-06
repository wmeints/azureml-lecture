using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CustomerChurn.Shared;

namespace CustomerChurn.Client.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient _httpClient;

        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CustomerViewModel> GetCustomerAsync(string id)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/customers/{id}");
            var responseMessage = await _httpClient.SendAsync(requestMessage);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseStream = await responseMessage.Content.ReadAsStreamAsync();
                var responseData = await JsonSerializer.DeserializeAsync<CustomerViewModel>(responseStream, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                return responseData;
            }
            
            if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            var responseText = await responseMessage.Content.ReadAsStringAsync();

            throw new WebException(responseText);

        }

        public async Task<PagedResultSet<CustomerViewModel>> GetCustomersAsync(int pageIndex)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/customers?page={pageIndex}");
            var responseMessage = await _httpClient.SendAsync(requestMessage);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseStream = await responseMessage.Content.ReadAsStreamAsync();
                var responseData = await JsonSerializer.DeserializeAsync<PagedResultSet<CustomerViewModel>>(responseStream, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                return responseData;
            }

            var responseText = await responseMessage.Content.ReadAsStringAsync();

            throw new WebException(responseText, WebExceptionStatus.ProtocolError);
        }
    }
}