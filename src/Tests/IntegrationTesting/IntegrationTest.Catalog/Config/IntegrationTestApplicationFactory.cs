using Microsoft.AspNetCore.Builder;
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
            .WithReuse(true)
            .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            Environment.SetEnvironmentVariable("EnviromentVar", "EnviromentTest");
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

        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();
            using var scope = Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            await dbContext.Database.MigrateAsync();
            await SeedDatabaseAsync(dbContext);
        }

        public new async Task DisposeAsync()
        {
            Environment.SetEnvironmentVariable("EnviromentVar", "");
            await _dbContainer.DisposeAsync();
        }

        public static async Task SeedDatabaseAsync(DatabaseContext context)
        {
            await SeedProductAsync(context);

        }
        private static async Task SeedProductAsync(DatabaseContext dbContext)
        {
            var isAnyProduct = await dbContext.Products.AnyAsync();
            if (!isAnyProduct)
            {
                await dbContext.AddRangeAsync(InitialData.Products);
                await dbContext.SaveChangesAsync();
            }
        }
    }


}
