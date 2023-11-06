using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP24ReceivablesAPI;

namespace TP24Receivables.Test
{
    public class IntegrationTests /*: IClassFixture<WebApplicationFactory<Program>>*/
    {
        private HttpClient _httpClient;
        //private readonly WebApplicationFactory<Program> _factory;

        public IntegrationTests()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7253")
            };
        }

        [Theory]
        [InlineData("./TestData/IntegrationTest/example.json", "./TestData/IntegrationTest/example.json")]
        public async Task PostRequestToStatisticsApiEndpoint(string requestJsonPath, string expectedResponseJsonPath)
        {
            //Act
            string jsonBody = File.ReadAllText(requestJsonPath);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("api/Receivables/GetStatistics", content);

            // Assert
            Assert.True(response.IsSuccessStatusCode);

            string responseContent = await response.Content.ReadAsStringAsync();

            // Read the expected response JSON from the response file
            string expectedResponse = File.ReadAllText(expectedResponseJsonPath);

            // Compare the expected response JSON with the actual response JSON
            //Assert.Equal(expectedResponse, responseContent);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
