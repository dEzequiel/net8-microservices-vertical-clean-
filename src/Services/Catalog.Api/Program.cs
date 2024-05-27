using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter JWT token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddCarter();
builder.Services.AddMapster();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(RequestPerformanceBehaviour<,>));
});
builder.Services.AddDbContext<DatabaseContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
});
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.RegisterMapsterConfiguration();
builder.Services.RegisterAuthenticationWithConfiguration(builder.Configuration);
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()/* && !Environment.GetEnvironmentVariable("EnviromentVar").Equals("EnviromentTest")*/)
{
    await app.SeedDevelopmentDatabase();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapCarter();
app.Run();
app.UseAuthentication();
app.UseAuthorization();

public partial class Program { }
