using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Catalog.Api
{
    public static class Extensions
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Product, ProductDetailsDTO>
            .NewConfig().Map(dest => dest.category, src => src.ProductCategory);

            TypeAdapterConfig<Product, ProductDTO>
                .NewConfig().Map(dest => dest.category, src => src.ProductCategory.Name);

            TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
        }

        public static void RegisterAuthenticationWithConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}

