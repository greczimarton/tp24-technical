using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TP24ReceivablesAPI;

namespace TP24Receivables.Test
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public IntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("./TestData/IntegrationTest/Test1/input.json", "./TestData/IntegrationTest/Test1/output.json")]
        [InlineData("./TestData/IntegrationTest/Test2/input.json", "./TestData/IntegrationTest/Test2/output.json")]
        [InlineData("./TestData/IntegrationTest/Test3/input.json", "./TestData/IntegrationTest/Test3/output.json")]
        public async Task PostRequest_StatisticsApiEndpoint(string requestJsonPath, string expectedResponseJsonPath)
        {
            // Arrange
            var client = _factory.CreateClient();

            //Act
            string jsonBody = File.ReadAllText(requestJsonPath);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("api/Receivables/StatisticsWithoutDb", content);

            // Assert
            Assert.True(response.IsSuccessStatusCode);

            string actualResponseContent = await response.Content.ReadAsStringAsync();
            string expectedResponseContent = File.ReadAllText(expectedResponseJsonPath);

            var expectedJson = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(expectedResponseContent));
            var actualJson = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(actualResponseContent));

            Assert.Equal(expectedJson, actualJson);
        }
    }
}
