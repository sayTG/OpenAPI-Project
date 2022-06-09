using CompliantAPI.Abstractions.ILogger;
using CompliantAPI.Abstractions.IServices;
using CompliantAPI.Implementations.Logger;
using CompliantAPI.Implementations.Services;
using CompliantAPI.Utilities.Clients;
using CompliantAPI.Utilities.Extensions;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

builder.Services.AddHttpClient<ChuckNorris>(c => c.BaseAddress = new Uri("https://api.chucknorris.io/"));
builder.Services.AddHttpClient<Swapi>(c => c.BaseAddress = new Uri("https://swapi.dev/api/"));

var app = builder.Build();

// Configure the HTTP request pipeline.
ILoggerManager logger = app.Services.GetRequiredService<ILoggerManager>();

app.ConfigureExceptionHandler(logger);
if (app.Environment.IsProduction())
    app.UseHsts();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader()
      .AllowAnyMethod()
      .AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
