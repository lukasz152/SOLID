using Microsoft.Extensions.Options;
using MySpot.Api;
using MySpot.Infrastructure;
using MySpot.Infrastructure.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddCore()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
//.AddControllers();

builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.WriteTo
        .Console();
    // .WriteTo
    // .File("logs.txt")
    // .WriteTo
    // .Seq("http://localhost:5341");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseInfrastructure();
app.MapGet("api", (IOptions<AppOptions> options) => Results.Ok(options.Value.Name));
app.UseUsersApi();
app.Run();