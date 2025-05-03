// Arquivo: Program.cs
// Serviço: GatewayAPI
// Descrição: Configuração do API Gateway utilizando Ocelot, .NET 6 e ASP.NET Core.
// Proteção: Direitos autorais reservados © 2024 John Weider. Uso proibido sem autorização.

var builder = WebApplication.CreateBuilder(args);

// Adiciona o Ocelot para roteamento de API Gateway
builder.Services.AddOcelot();

var app = builder.Build();

// Middleware para roteamento Ocelot
app.UseOcelot().Wait();

app.Run();
