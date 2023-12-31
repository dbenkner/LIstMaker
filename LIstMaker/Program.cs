using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ListMaker.Data;
using ListMaker.Controllers;
using ListMaker.DTOs;
using Xunit;
using ListMaker;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ListMakerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevDb") ?? throw new InvalidOperationException("Connection string 'ListMakerContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

OnStartup.CheckForAdmin(app);

app.Run();


