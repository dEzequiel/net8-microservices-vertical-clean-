namespace IntegrationTest.Catalog.Endpoints
{
    public class AddProductEndpoint_IntegrationTest : BaseIntegrationTest
    {
        public AddProductEndpoint_IntegrationTest(IntegrationTestApplicationFactory factory) : base(factory)
        {
        }

        [Theory]
        [AutoMoqData]
        public async Task AddProductEndpoint_ReturnsResponseAndStatusCode201_Test(
            AddProductRequest request)
        {
            // Act
            var result = await _client.PostAsJsonAsync("/products", request);
            var responseString = await result.Content.ReadAsStringAsync();

            JObject jsonResponse = JObject.Parse(responseString);
            JToken? idToken = jsonResponse.SelectToken("id");

            if (idToken == null)
                Assert.Fail("Id key in json response not found.");

            var sut = idToken.ToObject<Guid>();

            // Assert
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
            var product = _dbContext.Products.First(x => x.Id == sut);
            Assert.NotNull(product);
        }
    }
}
