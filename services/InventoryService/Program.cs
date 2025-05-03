// Arquivo: Program.cs
// Serviço: InventoryService
// Descrição: Configuração da API para controle de estoque, utilizando .NET 6, MongoDB e AWS SQS.
// Proteção: Direitos autorais reservados © 2024 John Weider. Uso proibido sem autorização.

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container.
builder.Services.AddControllers();

// Configurações específicas do InventoryService podem ser adicionadas aqui

var app = builder.Build();

// Middleware para autorização (autenticação pode ser adicionada conforme necessidade)
app.UseAuthorization();

// Mapeia os controllers para rotas
app.MapControllers();

// Executa a aplicação
app.Run();
