using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity.Data;
using minimal_api.Dominio.DTOs;

var builder = WebApplication.CreateBuilder(args);
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




