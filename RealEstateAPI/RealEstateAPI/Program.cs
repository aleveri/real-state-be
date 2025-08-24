using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RealEstateAPI.Application.Interfaces;
using RealEstateAPI.Application.Services;
using RealEstateAPI.Infrastructure.Interfaces;
using RealEstateAPI.Infrastructure.Repositories;
using RealEstateAPI.Infrastructure.Settings;
using RealEstateAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetConnectionString("MongoDb")));

builder.Services.AddScoped(s =>
{
    var client = s.GetRequiredService<IMongoClient>();
    var settings = s.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return client.GetDatabase(settings.DatabaseName);
});

builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IPropertyService, PropertyService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
