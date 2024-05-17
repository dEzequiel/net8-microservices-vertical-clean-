using Catalog.Api.Domain;
using Catalog.Api.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Catalog.Endpoints
{
    public class FindAllProductsBetweenPricesEndpoint_IntegrationTest : BaseIntegrationTest
    {
        public FindAllProductsBetweenPricesEndpoint_IntegrationTest(IntegrationTestApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task FindAllProductsBetweenPricesEndpoint_ReturnsResponseAndStatusCode200_IntegrationTest()
        {
            // Arrange
            decimal minPrice = 160;
            decimal maxPrice = 350;
            string queryString = $"minimalPrice={minPrice}&maxPrice={maxPrice}";
            var getRequest = new HttpRequestMessage(HttpMethod.Get, $"/products/prices?{queryString}");

            // Act
            var response = await _client.SendAsync(getRequest);
            var responseString = await response.Content.ReadAsStringAsync();

            JObject jsonResponse = JObject.Parse(responseString);
            JToken? productsToken = jsonResponse.SelectToken("products");

            if (productsToken == null)
                Assert.Fail("Products key in json response not found.");

            var products = productsToken.ToObject<IEnumerable<ProductDetailsDTO>>();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
