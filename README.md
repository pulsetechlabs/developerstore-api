# Como rodar o projeto

## Pré-requisitos

- .NET 8.0 SDK
- PostgreSQL

## Configuração inicial

### 1. Clone o repositório
```bash
git clone [url-do-repositorio]
cd backend
```

### 2. Configure o banco de dados

Abra o arquivo `src/Ambev.DeveloperEvaluation.WebApi/appsettings.json` e ajuste a connection string com seus dados do PostgreSQL:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=54760;Database=developer_evaluation;Username=developer;Password=ev@luAt10n"
  }
}
```

### 3. Instale as ferramentas do Entity Framework (se não tiver)
```bash
dotnet tool install --global dotnet-ef
```

### 4. Execute as migrações
```bash
cd src/Ambev.DeveloperEvaluation.WebApi
dotnet ef database update --project ../Ambev.DeveloperEvaluation.ORM
```

### 5. Execute o projeto
```bash
dotnet run
```

A API vai estar rodando em `https://localhost:7181` (ou similar - vai aparecer no terminal).

## Como testar

### Swagger UI
Acesse `https://localhost:7181/swagger` no seu navegador para ver a documentação interativa e testar os endpoints.

### Endpoints principais

- **POST /api/sales** - Criar uma venda
- **GET /api/sales** - Listar vendas (com paginação)
- **GET /api/sales/{id}** - Obter detalhes de uma venda
- **PUT /api/sales/{id}/cancel** - Cancelar uma venda
- **PUT /api/sales/{id}/items/{itemId}/cancel** - Cancelar um item

### Exemplo de teste rápido

**Criar uma venda** (POST /api/sales):
```json
{
  "date": "2024-01-15T10:30:00",
  "customerId": "123e4567-e89b-12d3-a456-426614174000",
  "customerName": "João Silva",
  "branchId": "123e4567-e89b-12d3-a456-426614174001",
  "branchName": "Filial Centro",
  "items": [
    {
      "productId": "123e4567-e89b-12d3-a456-426614174002",
      "productName": "Produto A",
      "quantity": 5,
      "unitPrice": 10.00
    }
  ]
}
```

### Validação das regras de negócio

Tente alguns cenários para ver as regras funcionando:

- **3 itens**: Sem desconto
- **5 itens**: 10% de desconto  
- **12 itens**: 20% de desconto
- **25 itens**: Erro (máximo 20)

## Estrutura do projeto

```
src/
├── Ambev.DeveloperEvaluation.Domain/     # Entidades e regras de negócio
├── Ambev.DeveloperEvaluation.Application/ # Casos de uso (CQRS)
├── Ambev.DeveloperEvaluation.ORM/         # Persistência (EF Core)
├── Ambev.DeveloperEvaluation.WebApi/      # API REST
├── Ambev.DeveloperEvaluation.Common/      # Utilitários compartilhados
└── Ambev.DeveloperEvaluation.IoC/         # Injeção de dependência
```

## Health Check

Acesse `/health` para verificar se a aplicação está funcionando corretamente.
