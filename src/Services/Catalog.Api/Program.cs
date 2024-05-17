using Carter;
using Catalog.Api;
using Catalog.Api.Data;
using Catalog.Api.Data.Extensions;
using Catalog.Api.Data.Repositories;
using Catalog.Api.Domain;
using Catalog.Api.DTOs;
using Crosscuting.Base.Behaviours;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCarter();
builder.Services.AddMapster();
builder.Services.RegisterMapsterConfiguration();
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() && !Environment.GetEnvironmentVariable("EnviromentVar").Equals("EnviromentTest"))
{
    await app.SeedDevelopmentDatabase();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapCarter();
app.Run();

public partial class Program { }
