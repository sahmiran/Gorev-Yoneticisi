using Gorev_Yoneticisi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Gorev_Yoneticisi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<KullaniciDatabaseSettings>(builder.Configuration.GetSection(nameof(KullaniciDatabaseSettings)));

builder.Services.AddSingleton<IKullaniciDatabaseSettings>(sp => sp.GetRequiredService<IOptions<KullaniciDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(sp => new MongoClient(builder.Configuration.GetValue<string>("KullaniciDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IKullaniciService,KullaniciService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
