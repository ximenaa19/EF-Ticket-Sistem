using AirlineTicketSystem.Api.Extensions;
using AirlineTicketSystem.Application;
using AirlineTicketSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApiServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGet("/", () => Results.Redirect("/swagger"))
        .ExcludeFromDescription();
}

app.UseCustomExceptionHandling();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
