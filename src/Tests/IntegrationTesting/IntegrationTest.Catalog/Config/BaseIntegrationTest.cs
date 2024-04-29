namespace IntegrationTest.Catalog.Config
{
    public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestApplicationFactory>
    {
        private readonly IServiceScope _scope;
        protected readonly ISender _sender;
        protected readonly DatabaseContext _dbContext;
        protected HttpClient _client;

        protected BaseIntegrationTest(IntegrationTestApplicationFactory factory)
        {
            _scope = factory.Services.CreateScope();
            _sender = _scope.ServiceProvider.GetRequiredService<ISender>();
            _dbContext = _scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            _client = factory.CreateClient();
        }
    }
}
