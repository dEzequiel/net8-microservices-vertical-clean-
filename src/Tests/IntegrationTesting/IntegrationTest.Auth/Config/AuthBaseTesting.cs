using Auth.Service.Data;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTest.Auth.Config
{
    public abstract class AuthBaseTesting : IClassFixture<AuthApplicationFactory>
    {
        private readonly IServiceScope _scope;
        protected readonly ApplicationDbContext _dbContext;
        protected HttpClient _client;

        protected AuthBaseTesting(AuthApplicationFactory factory)
        {
            _scope = factory.Services.CreateScope();
            _dbContext = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            _client = factory.CreateClient();
        }
    }
}
