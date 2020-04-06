using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CustomerChurn.Shared;

namespace CustomerChurn.Client.Services
{
    public class ChurnModel : IChurnModel
    {
        private readonly HttpClient _httpClient;

        public ChurnModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<decimal>> Predict(CustomerViewModel viewModel)
        {
            var randomizer = new Random();

            return new[] { (decimal)randomizer.NextDouble() };

            //_httpClient.BaseAddress = new Uri("");

            //var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/...") {
            //    Content = new StringContent(JsonSerializer.Serialize(viewModel, new JsonSerializerOptions()
            //    {
            //        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            //    }))};

            //var responseMessage = await _httpClient.SendAsync(requestMessage);

            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var responseStream = await responseMessage.Content.ReadAsStreamAsync();
            //    var responseData = await JsonSerializer.DeserializeAsync<IEnumerable<decimal>>(responseStream);

            //    return responseData;
            //}

            //return Enumerable.Empty<decimal>();
        }
    }
}