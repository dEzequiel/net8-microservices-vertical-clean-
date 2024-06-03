using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace IntegrationTest.Catalog.Endpoints
{
    public class FindAllProductsEndpoint_IntegrationTest : BaseIntegrationTest
    {
        public FindAllProductsEndpoint_IntegrationTest(IntegrationTestApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task FindAllProductsEndpoints_ReturnsResponseAndStatusCode200_IntegrationTest()
        {
            // Arrange
            var getRequest = new HttpRequestMessage(HttpMethod.Get, "/products");
            var token = new JwtTokenForTesting().Build();

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await _client.SendAsync(getRequest);
            var responseString = await response.Content.ReadAsStringAsync();

            JObject jsonResponse = JObject.Parse(responseString);
            JToken? productsToken = jsonResponse.SelectToken("products");

            if(productsToken == null)
                Assert.Fail("Products key in json response not found.");

            var products = productsToken.ToObject<IEnumerable<Product>>();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

    }
}
