// Arquivo: Program.cs
// Serviço: GatewayAPI
// Descrição: Configuração do API Gateway utilizando Ocelot, .NET 6 e ASP.NET Core.
// Proteção: Direitos autorais reservados © 2024 John Weider. Uso proibido sem autorização.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Configuração de logging com Serilog
builder.Host.UseSerilog((context, config) =>
{
    config.WriteTo.Console()
          .WriteTo.File("logs/gateway.log", rollingInterval: RollingInterval.Day);
});

// Adiciona o Ocelot para roteamento de API Gateway
builder.Services.AddOcelot();

// Configuração de autenticação JWT
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://your-auth-server";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization();

// Configuração de cache com Redis
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379"; // Configuração do Redis
    options.InstanceName = "GatewayCache";
});

// Configuração de Health Checks
builder.Services.AddHealthChecks()
    .AddRedis("localhost:6379", name: "Redis")
    .AddUrlGroup(new Uri("https://your-downstream-service"), name: "DownstreamService");

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Configuração de documentação com Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware de CORS
app.UseCors("AllowAll");

// Middleware de autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

// Middleware de documentação Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Middleware de Health Checks
app.MapHealthChecks("/health");

// Middleware para roteamento Ocelot
await app.UseOcelot();

app.Run();