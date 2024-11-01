using Microsoft.EntityFrameworkCore;
using MySpot.Api.Entities;
using MySpot.Api.Services;
using MySpot.Api.ValueObjects;
using MySpot.Infrastructure;
using MySpot.Infrastructure.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddCore()
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddControllers(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.MapControllers();
app.Run();
