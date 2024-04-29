using Microsoft.EntityFrameworkCore;
using System;

namespace Catalog.Api.Data.Extensions
{
    public static class UseDataExtension
    {
        public static async Task SeedDevelopmentDatabase(this WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

            if (context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                context.Database.Migrate();
            }

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
