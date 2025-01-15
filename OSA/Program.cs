using Microsoft.AspNetCore.Hosting;
using OSA.API.Infrastructure.Extensions;
using OSA.Utility;

Utils.RootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.GetAppSettingSection(builder.Configuration, out var AppSettigs);

ContentLoader.LanguageLoader();
// Add services to the container.

services.AddAntiforgery();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

services.RegisterServices();
services.RegisterRepositories();
services.ConfigureDatabase(builder.Configuration);
services.AddAutoMapper(typeof(Program));
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
