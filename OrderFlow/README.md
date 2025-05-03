# OrderFlow - Distributed Order Management System

Sistema de gerenciamento de pedidos distribuído baseado em microsserviços, construído com .NET Core, mensageria, bancos de dados distribuídos, observabilidade e arquitetura moderna.

## Tecnologias principais

- C# / .NET Core
- RabbitMQ / AWS SQS
- PostgreSQL / MongoDB / Redis
- Docker / Docker Compose
- Grafana / Prometheus / Serilog
- GitHub Actions (CI/CD)
- CQRS / DDD / SOLID / Clean Architecture

## Serviços

- AuthService: Autenticação e sessões
- OrderService: Gestão de pedidos
- InventoryService: Estoque
- PaymentService: Processamento de pagamento
- NotificationService: Notificações
- GatewayAPI: API Gateway

## Executando localmente

```bash
docker-compose up --build
```

## CI/CD

Pipeline automatizado via GitHub Actions para build e testes.

---

> Projeto criado como portfólio técnico demonstrando domínio de arquitetura moderna com .NET.
