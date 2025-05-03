// Arquivo: Program.cs
// Serviço: AuthService
// Descrição: Configuração da API para autenticação via JWT, utilizando .NET 6 e ASP.NET Core.
// Proteção: Direitos autorais reservados © 2024 John Weider. Uso proibido sem autorização.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container.
builder.Services.AddControllers();

// Configuração da autenticação JWT
var chaveSecreta = Encoding.ASCII.GetBytes("SuaChaveSecretaSuperSecretaAquiTroque");

// Configura o esquema de autenticação padrão para JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // Em produção, deve ser true para segurança
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true, // Valida a chave de assinatura
        IssuerSigningKey = new SymmetricSecurityKey(chaveSecreta), // Chave usada para validar o token
        ValidateIssuer = false, // Pode ser configurado para validar emissor
        ValidateAudience = false // Pode ser configurado para validar audiência
    };
});

var app = builder.Build();

// Middleware para autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

// Mapeia os controllers para rotas
app.MapControllers();

// Executa a aplicação
app.Run();
