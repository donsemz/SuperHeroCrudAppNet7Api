global using SuperHeroCrudAppNet7Api.Models;
using Microsoft.EntityFrameworkCore;
using SuperHeroCrudAppNet7Api.Data;
using SuperHeroCrudAppNet7Api.Services.SuperHeroService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Api Controller with dependency injection
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();// can also use addsingleton or addtransient

//Add the connection string
//Add Db Context
builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer")));

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
