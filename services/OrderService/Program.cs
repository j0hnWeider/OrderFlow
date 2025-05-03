// Arquivo: Program.cs
// Serviço: OrderService
// Descrição: Configuração da API para gerenciamento de pedidos, utilizando .NET 6 e ASP.NET Core.
// Proteção: Direitos autorais reservados © 2024 John Weider. Uso proibido sem autorização.

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container.
builder.Services.AddControllers();

// Configurações específicas do OrderService podem ser adicionadas aqui

var app = builder.Build();

// Middleware para autorização (autenticação pode ser adicionada conforme necessidade)
app.UseAuthorization();

// Mapeia os controllers para rotas
app.MapControllers();

// Executa a aplicação
app.Run();
