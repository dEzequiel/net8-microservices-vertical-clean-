using Auth.Service.Data;
using Microsoft.Win32;

namespace IntegrationTest.Auth.Endpoints
{
    public class RegisterUserController_IntegrationTest : AuthBaseTesting
    {
        public RegisterUserController_IntegrationTest(AuthApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task RegisterUserEndpoint_ReturnsResponseAndStatusCode201_Test()
        {
            // Arrange
            const string REGISTER_ENDPOINT = "/api/user/register"; 
            string userEmail = "register@test.com";
            var registerApplicationUserData = new RegisterApplicationUserDTO(userEmail);

            // Act
            var response = await _client.PostAsJsonAsync(REGISTER_ENDPOINT, registerApplicationUserData);
            var responseString = await response.Content.ReadAsStringAsync();

            JObject jsonResponse = JObject.Parse(responseString);
            JToken? statusToken = jsonResponse.SelectToken("status");

            if (statusToken == null)
                Assert.Fail("Id key in json response not found.");
            
            var sut = statusToken.ToObject<bool>();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(sut);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task LoginUserEndpoint_ReturnsResponseAndStatusCode200_Test()
        {
            // Arrange
            const string LOGIN_ENDPOINT = "/api/user/login";
            string userEmail = "login@test.com";
            var registerApplicationUserData = new LoginApplicationUserDTO(userEmail);

            ApplicationUser user = new ApplicationUser(userEmail);
            _dbContext.ApplicationUsers.Add(user);
            _dbContext.SaveChanges();

            // Act
            var response = await _client.PostAsJsonAsync(LOGIN_ENDPOINT, registerApplicationUserData);
            var responseString = await response.Content.ReadAsStringAsync();

            JObject jsonResponse = JObject.Parse(responseString);
            JToken? statusToken = jsonResponse.SelectToken("status");
            JToken? messageToken = jsonResponse.SelectToken("message");

            if (statusToken is null || messageToken is null)
                Assert.Fail("Required key in json response not found.");

            var sut = jsonResponse.ToObject<LoginApplicationUserResponse>();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(sut.Status);
            Assert.NotNull(sut.Message);
            Assert.NotEmpty(sut.Message);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
