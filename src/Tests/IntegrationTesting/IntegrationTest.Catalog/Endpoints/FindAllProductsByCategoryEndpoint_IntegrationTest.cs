using Catalog.Api.Domain.Enums;
using Catalog.Api.DTOs;
using Catalog.Api.Features.FindProductsByCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Catalog.Endpoints
{
    public class FindAllProductsByCategoryEndpoint_IntegrationTest : BaseIntegrationTest
    {
        public FindAllProductsByCategoryEndpoint_IntegrationTest(IntegrationTestApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task FindAllProductsByCategoryEndpoint_ReturnsResponseAndStatusCode200_IntegrationTest()
        {
            // Arrange
            IEnumerable<int> productCategoriesIds = new List<int>() { 1, 6, 3 };
            var request = new FindAllProductsByCategoryRequest(productCategoriesIds);

            // Act
            var response = await _client.PostAsJsonAsync("/products/categories", request);
            var responseString = await response.Content.ReadAsStringAsync();

            JObject jsonResponse = JObject.Parse(responseString);
            JToken? productsToken = jsonResponse.SelectToken("products");

            if (productsToken == null)
                Assert.Fail("Products key in json response not found.");

            var products = productsToken.ToObject<IEnumerable<ProductDTO>>();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
