using TrendFlow.Api;
using TrendFlow.Api.Controllers;
using TrendFlow.Api.Extensions;
using TrendFlow.Api.Infrastructure;
using TrendFlow.Application;
using TrendFlow.DataAccess;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplication(builder.Configuration)
    .AddDataAccess(builder.Configuration);

builder.ConfigureServiceLayer();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.UseHttpsRedirection();

//app.UseRequestContextLogging();

//app.UseExceptionHandler();

app.MapBrandEndpoints();


//app.UseAuthorization();

//app.MapControllers();

app.Run();

public partial class Program;
