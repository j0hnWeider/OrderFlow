# OrderFlow - Distributed Order Management System

Sistema de gerenciamento de pedidos distribuído baseado em microsserviços, construído com .NET Core, mensageria, bancos de dados distribuídos, observabilidade e arquitetura moderna.

Este projeto começou como um estudo e aprimoramento de habilidades em arquitetura de microsserviços e tecnologias modernas, mas acabou tomando uma proporção muito maior, tornando-se um sistema completo e funcional.
CI/CD
Pipeline automatizado via GitHub Actions para build e testes.

© 2024 John Weider. Todos os direitos reservados. Uso proibido sem autorização expressa.
---

## Tecnologias principais

- C# .NET Core
- RabbitMQ, AWS SQS
- PostgreSQL, MongoDB, Redis
- Docker, Docker Compose
- Grafana, Prometheus, Serilog
- GitHub Actions (CI/CD)
- CQRS, DDD, SOLID, Clean Architecture

---

## Serviços

- **AuthService**: Autenticação e sessões
- **OrderService**: Gestão de pedidos
- **InventoryService**: Estoque
- **PaymentService**: Processamento de pagamento
- **NotificationService**: Notificações
- **GatewayAPI**: API Gateway

---

## Atualizações no GatewayAPI

O **GatewayAPI** foi aprimorado com as seguintes funcionalidades:

### 1. **Logging**
- Configurado com **Serilog** para registrar logs no console e em arquivos.
- Logs são armazenados no diretório `logs/` com rotação diária.

### 2. **Autenticação e Autorização**
- Implementado suporte a **JWT Bearer Tokens**.
- Configurado para validar tokens emitidos por um servidor de autenticação externo.

### 3. **Cache**
- Integração com **Redis** para cache de respostas.
- Configuração do Redis:
  - Host: `localhost` (em produção, configure via variáveis de ambiente).
  - Porta: `6379` (em produção, configure via variáveis de ambiente).

### 4. **Health Checks**
- Verificação de saúde configurada para:
  - **Redis** (cache).
  - Serviços downstream (URLs configuradas via variáveis de ambiente).
- Endpoint de Health Check: `/health` (recomenda-se proteger este endpoint em produção).

### 5. **CORS**
- Configurado para permitir requisições de qualquer origem.
- Suporte a todos os métodos HTTP e cabeçalhos.

### 6. **Documentação**
- Documentação interativa gerada com **Swagger**.
- Endereço da documentação: `/swagger`.

### 7. **Roteamento**
- Gerenciado pelo **Ocelot**, com suporte a configurações avançadas como:
  - Cache por rota.
  - Rate Limiting (limitação de requisições).

---

## Como Executar

### Pré-requisitos
- **.NET 6 SDK** instalado.
- **Redis** em execução no endereço configurado via variáveis de ambiente.
- Servidor de autenticação configurado (substituir `https://your-auth-server` no código pelo endereço correto).

### Passos
1. Clone o repositório:
   ```bash
   git clone https://github.com/j0hnWeider/OrderFlow.git
   cd OrderFlow/services/GatewayAPI

2. Restaure as dependências:
`dotnet restore`
3. Execute o projeto:
`dotnet run`
Acesse os endpoints: <vscode_annotation details='%5B%7B%22title%22%3A%22hardcoded-credentials%22%2C%22description%22%3A%22Embedding%20credentials%20in%20source%20code%20risks%20unauthorized%20access%22%7D%5D'> -</vscode_annotation> Swagger UI: http://localhost:5000/swagger

Acesse os endpoints:

Swagger UI: http://localhost:5000/swagger
Health Check: http://localhost:5000/health
Configuração do Ocelot
O arquivo ocelot.json contém as configurações de roteamento, cache e rate limiting. Exemplo de configuração (substitua valores sensíveis por variáveis de ambiente):
```bash
{
  "Routes": [
    {
      "DownstreamPathTemplate": "/api/orders",
      "UpstreamPathTemplate": "/orders",
      "CacheOptions": {
        "TtlSeconds": 60
      },
      "RateLimitOptions": {
        "EnableRateLimiting": true,
        "Period": "1s",
        "Limit": 5
      }
    }
  ],
  "GlobalConfiguration": {
    "RateLimitOptions": {
      "DisableRateLimitHeaders": false,
      "QuotaExceededMessage": "Too many requests. Please try again later."
    }
  }
}

