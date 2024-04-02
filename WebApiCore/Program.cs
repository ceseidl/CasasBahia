using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebApiCore.Data;
using WebApiCore.Externals;
using WebApiCore.Externals.Interfaces;
using WebApiCore.Repositories;
using WebApiCore.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<ApplicationDbContext>(options=> options.UseSqlServer())
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IKafkaServices, KafkaServices>();
builder.Services.AddDbContext<ApplicationDbContext>();

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
