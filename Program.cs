using Microsoft.AspNetCore.Mvc;
using MinimalApiCrud.Interfaces;
using MinimalApiCrud.Models;
using MinimalApiCrud.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ICarRepository, CarRepository>();

var app = builder.Build();

app.MapGet("/v1/car", ([FromServices]ICarRepository repository) => 
{
   return repository.GetCars();
});

app.MapPost("/v1/car", 
([FromServices]ICarRepository repository, CarModel car)=>
{
    var result = repository.InsertCar(car);

    return (result ? 
    Results.Ok($"Carro {car.Modelo} inserido com sucesso")
    :
    Results.BadRequest("Não foi possivel inserir o carro")
    );
});

app.MapPut("/v1/car", 
([FromServices]ICarRepository repository, int id, string cor)=>
{
    var result = repository.UpdateCarCor(cor, id);
    return (result ? 
    Results.Ok($"Cor alterada com sucesso")
    :
    Results.BadRequest("Não foi possivel alterar a cor do carro")
    );
});

app.MapPut("/v1/car", 
([FromServices]ICarRepository repository, CarModel car)=>
{
    var result = repository.UpdateCarCor(car.Cor, car.Id);
    return (result ? 
    Results.Ok($"Cor alterada com sucesso")
    :
    Results.BadRequest("Não foi possivel alterar a cor do carro")
    );
});

app.MapDelete("/v1/car", 
([FromServices]ICarRepository repository, int id)=>
{
    var result = repository.Delete(id);
    return (result ? 
    Results.Ok($"Carro apagado com sucesso")
    :
    Results.BadRequest("Não foi possivel apagar o carro")
    );
});


app.Run();
