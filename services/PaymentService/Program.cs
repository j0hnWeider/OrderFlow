// Arquivo: Program.cs
// Serviço: PaymentService
// Descrição: Configuração da API para simulação de processamento de pagamentos, utilizando .NET 6 e Redis.
// Proteção: Direitos autorais reservados © 2024 John Weider. Uso proibido sem autorização.

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container.
builder.Services.AddControllers();

// Configurações específicas do PaymentService podem ser adicionadas aqui

var app = builder.Build();

// Middleware para autorização (autenticação pode ser adicionada conforme necessidade)
app.UseAuthorization();

// Mapeia os controllers para rotas
app.MapControllers();

// Executa a aplicação
app.Run();
