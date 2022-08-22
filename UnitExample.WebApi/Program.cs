using Microsoft.EntityFrameworkCore;
using UnitExample.Data.Entidad;
using UnitExample.Negocio.Repositorio.Interfaz;
using UnitExample.Negocio.Repositorio.Implementacion;

using UnitExample.Data.Repositorio.Interfaz;
using UnitExample.Data.Repositorio.Implementacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<RepositoryPatternContext>(builder.Configuration.GetSection("Database:ConnectionString").Value);

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddTransient<IOrderService, OrderService>();

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
