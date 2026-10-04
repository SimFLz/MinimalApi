using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Interfaces;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.Db;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAdministradorServico, AdministradorServico>();
builder.Services.AddDbContext<DbContexto>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("mysql");
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 35)));
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/Login", ([FromBody] LoginDTO loginDTO, IAdministradorServico administradorServico) =>
{
    if(administradorServico.Login(loginDTO) != null)
        return Results.Ok("Login efetuado com sucesso!");
    else
        return Results.Unauthorized();
    
});

app.Run();




