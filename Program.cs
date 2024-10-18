using Microsoft.EntityFrameworkCore;
using MinimalApi.DTOs;
using MinimalApi.Inflaestrutura.Db;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbContexto>(options => {
    options.UseMySql(builder.Configuration.GetConnectionString("mysql"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql")));
});

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (LoginDTO loginDTO) => {
    if(loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
        return Results.Ok("Login com Sucesso");
    else
        return Results.Unauthorized();
});

app.Run();

