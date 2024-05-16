﻿using Catalog.Api.Domain.Enums;

namespace IntegrationTest.Catalog.Endpoints
{
    public class AddProductEndpoint_IntegrationTest : BaseIntegrationTest
    {
        public AddProductEndpoint_IntegrationTest(IntegrationTestApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        [AutoMoqData]
        public async Task AddProductEndpoint_ReturnsResponseAndStatusCode201_Test()
        {
            // Arrange
            string GenerateNewGuid() => Guid.NewGuid().ToString();
            var request = new AddProductRequest(GenerateNewGuid(), GenerateNewGuid(), 00, (int)ProductCategories.MobilePhone);
            
            // Act
            var response = await _client.PostAsJsonAsync("/products", request);
            var responseString = await response.Content.ReadAsStringAsync();

            JObject jsonResponse = JObject.Parse(responseString);
            JToken? idToken = jsonResponse.SelectToken("id");

            if (idToken == null)
                Assert.Fail("Id key in json response not found.");

            var sut = idToken.ToObject<Guid>();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}