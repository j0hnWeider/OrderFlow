# OrderFlow - Distributed Order Management System

Sistema de gerenciamento de pedidos distribuído baseado em microsserviços, construído com .NET Core, mensageria, bancos de dados distribuídos, observabilidade e arquitetura moderna.

Este projeto começou como um estudo e aprimoramento de habilidades em arquitetura de microsserviços e tecnologias modernas, mas acabou tomando uma proporção muito maior, tornando-se um sistema completo e funcional.

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

Para rodar o sistema completo localmente, incluindo os microserviços e serviços de infraestrutura, utilize o seguinte comando dentro do diretório `OrderFlow`:

```bash
docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build
```

> Nota: Certifique-se de que o Docker Desktop está instalado e rodando corretamente no seu sistema. O Docker Desktop deve estar aberto e totalmente iniciado antes de executar o comando acima.

## CI/CD

Pipeline automatizado via GitHub Actions para build e testes.

---

© 2024 John Weider. Todos os direitos reservados. Uso proibido sem autorização expressa.
