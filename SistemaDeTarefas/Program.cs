using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Repositorios;
using SistemaDeTarefas.Repositorios.Interfaces.Context;
using SistemaDeTarefas.Repositorios.Interfaces.Usuario;
using SistemaDeTarefas.Repository.Context;
using SistemaDeTarefas.Service;
using SistemaDeTarefas.Services.Interfaces.Usuario;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<SistemaTarefasDBContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<SistemaTarefasDBContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

builder.Services.AddScoped<IContext, SistemaTarefasDBContext>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }