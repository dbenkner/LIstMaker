using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LIstMaker.Data;
using LIstMaker.Controllers;
using LIstMaker.DTOs;
using Xunit;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LIstMakerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevDb") ?? throw new InvalidOperationException("Connection string 'LIstMakerContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();


