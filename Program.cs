using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.DTOs;
using minimal_api.Infraestrutura.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContexto>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("mysql");
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 35)));
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/Login", (LoginDTO loginDTO) =>
{
    if(loginDTO.Email == "admteste@gmail.com" && loginDTO.Senha == "123456")
        return Results.Ok("Login efetuado com sucesso!");
    else
        return Results.Unauthorized();
    
});

app.Run();




