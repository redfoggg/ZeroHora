using System;
using System.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using ZeroHora.Domain.Interfaces;
using ZeroHora.Infra.Data.Repository;

var builder = WebApplication.CreateBuilder(args);
string dbConnectionString = "Server=localhost;Port=5432;Database=Particular;User Id=postgres;Password=elias1993;";

builder.Services.AddTransient<IDbConnection>((sp) => new NpgsqlConnection(dbConnectionString));
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();


await using var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", (Func<string>)(() => "Hello World!"));

app.MapGet("/enderecos", async (http) =>
{
    var dados = http.RequestServices.GetService<IEnderecoRepository>();
    var response = dados.GetAll();

    await http.Response.WriteAsJsonAsync(response);
});

app.Run();
