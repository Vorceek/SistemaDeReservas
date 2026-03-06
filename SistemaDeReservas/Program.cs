using FluentValidation;
using Microsoft.Data.SqlClient;
using SistemaDeReservas.Application.Interfaces.Hoteis;
using SistemaDeReservas.Application.Interfaces.Quartos;
using SistemaDeReservas.Application.Interfaces.Reservas;
using SistemaDeReservas.Application.Interfaces.Users;
using SistemaDeReservas.Application.Services;
using SistemaDeReservas.Application.Services.Hoteis;
using SistemaDeReservas.Application.Services.Quartos;
using SistemaDeReservas.Application.Services.Reservas;
using SistemaDeReservas.Application.Validators.Users;
using SistemaDeReservas.Infraestructure.Repositories;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Validators
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();

// Users
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Hoteis
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IHotelService, HotelService>();

// Quartos
builder.Services.AddScoped<IQuartoRepository, QuartoRepository>();
builder.Services.AddScoped<IQuartoService, QuartoService>();

// Reservas
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IReservaService, ReservaService>();

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
