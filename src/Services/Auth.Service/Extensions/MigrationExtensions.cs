using Auth.Service.Data;
using Microsoft.EntityFrameworkCore;

namespace Auth.Service.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

        }
    }
}
