using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Testcontainers.PostgreSql;

namespace IntegrationTest.Catalog.Config
{
    public class IntegrationTestApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
            .WithImage("postgres:latest")
            .WithDatabase("integration_tests")
            .WithUsername("postgres")
            .WithPassword("postgres")
            .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(srv =>
            {
                var descriptor = srv.SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<DatabaseContext>));

                if (descriptor is not null)
                    srv.Remove(descriptor);

                srv.AddDbContext<DatabaseContext>(opt =>
                {
                    //var postgresConnectionString = $"Host=localhost;Port=5433;Database=integration_tests_{dbSuffix};Username=postgres;Password=postgres;Maximum Pool Size=1";
                    opt.UseNpgsql(_dbContainer.GetConnectionString());
                });
            });
        }

        public Task InitializeAsync()
        {
            return _dbContainer.StartAsync();
        }

        public Task DisposeAsync()
        {
            return _dbContainer.StopAsync();
        }
    }
}
