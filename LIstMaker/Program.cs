using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LIstMaker.Data;
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
