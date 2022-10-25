using Microsoft.EntityFrameworkCore;
using MeuLivroDeReceitas.Infrastructure.Migrations;
using MeuLivroDeReceitas.Domain.Extension;
using MeuLivroDeReceitas.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositorio(builder.Configuration);

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
UpdateDatabase();

app.Run();

void UpdateDatabase()
{
    var dataName = builder.Configuration.GetNameDataBase();
    var context = builder.Configuration.GetConnection();
    Database.CreateDatabase(context, dataName);

    app.MigrateDatabase();
}