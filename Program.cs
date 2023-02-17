using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using repository_pattern.Interfaces;
using repository_pattern.Models;
using repository_pattern.Repository;
using repository_pattern.Services;

var builder = WebApplication.CreateBuilder(args);

//contexto Db
builder.Services.AddDbContext<RepositoryPatternContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//injeção de dependência
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//swagger
builder.Services.AddMvc();

builder.Services.AddEndpointsApiExplorer();//add for swagger
builder.Services.AddSwaggerGen();//add for swagger


var app = builder.Build();

//swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MY API");
});

//minimal API

app.MapGet("/Product/{id}", ([FromRoute] int id, [FromServices] IRepository<Product> product) =>
{
    ProductService service = new ProductService(product);

    return Results.Ok(service.GetProductById(id));
});

app.MapPost("/Product", ([FromBody] Product model, [FromServices] IRepository<Product> product) =>
{
    ProductService service = new ProductService(product);
    service.AddProduct(model);


    return Results.Created($"/products/{model.Id}", model.Id);
});

app.Run();
