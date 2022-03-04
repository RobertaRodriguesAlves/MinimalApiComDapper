using MinimalApiComDapper.Interfaces;
using MinimalApiComDapper.Repositorios;
using Microsoft.AspNetCore.Mvc;
using MinimalApiComDapper.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICarroRepositorio, CarroRepositorio>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapGet("/v1/carros", ([FromServices]ICarroRepositorio repositorio) =>
{
    return repositorio.Carros();
});

app.MapPost("/v1/carro", ([FromServices] ICarroRepositorio repositorio, CarroModel carro) =>
{
    var result = repositorio.CriarCarro(carro);
    return (result ? Results.Ok($"Carro {carro.Modelo} criado com sucesso") : Results.BadRequest("Falha na criação do carro"));
});

app.MapPut("/v1/carro", ([FromServices] ICarroRepositorio repositorio, int id, string cor) =>
{
    var result = repositorio.AlterarCarroCor(id, cor);
    return (result ? Results.Ok($"Cor alterada com sucesso") : Results.BadRequest("Falha na atualização da cor do carro"));
});

app.MapDelete("/v1/carro", ([FromServices] ICarroRepositorio repositorio, int id) =>
{
    var result = repositorio.ExcluirCarro(id);
    return (result ? Results.Ok($"Carro excluído com sucesso") : Results.BadRequest("Falha na exclusão do carro"));
});

app.Run();
