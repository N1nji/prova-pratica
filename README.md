# 🛒 Claps Product Catalog API

API REST desenvolvida em **.NET 8** para gerenciamento de produtos de um catálogo de e-commerce.

Este projeto foi desenvolvido como prova prática para a vaga de **Desenvolvedor .NET**, aplicando boas práticas de arquitetura, organização e qualidade de código.

---

##  Tecnologias Utilizadas

- .NET 8  
- ASP.NET Core Web API  
- Entity Framework Core  
- PostgreSQL  
- Docker & Docker Compose  
- Swagger (OpenAPI)  
- xUnit (Testes Unitários)  
- GitHub Actions (CI/CD)  

---

##  Arquitetura

O projeto segue arquitetura em camadas, com separação clara de responsabilidades:

```
API (Controllers)
   ↓
Application (Regras de negócio)
   ↓
Domain (Entidades e regras do domínio)
   ↓
Infrastructure (EF Core, Banco de Dados, FileService)
```

###  Estrutura do Projeto

- `Claps.ProductCatalog.Api` → Camada de apresentação (Controllers)
- `Claps.ProductCatalog.Application` → Serviços e interfaces
- `Claps.ProductCatalog.Domain` → Entidades e enums
- `Claps.ProductCatalog.Infrastructure` → Repositórios, EF Core e FileService
- `Claps.ProductCatalog.Tests` → Testes unitários

---

##  Funcionalidades Implementadas

-  Cadastrar produto  
-  Editar produto  
-  Excluir produto  
-  Listar produtos com filtros:
  - Categoria
  - Faixa de preço
  - Status (Ativo/Inativo)
-  Upload de imagem do produto  
  - Simulação de envio para S3 (arquivos salvos localmente em `/uploads`)
-  Documentação automática com Swagger  

---

##  Como Executar com Docker

### Pré-requisitos

- Docker Desktop instalado  
- WSL 2 habilitado (Windows)  

### Executar aplicação

```bash
docker-compose up --build
```

Após iniciar, acessar:

```
http://localhost:8080/swagger
```

---

##  Executar Testes

```bash
dotnet test
```

---

##  Endpoints Principais

### Criar Produto
```
POST /api/Products
```

### Listar Produtos
```
GET /api/Products
```

Filtros disponíveis:

- `category`
- `minPrice`
- `maxPrice`
- `status`

### Buscar Produto por ID
```
GET /api/Products/{id}
```

### Atualizar Produto
```
PUT /api/Products/{id}
```

### Deletar Produto
```
DELETE /api/Products/{id}
```

### Upload de Imagem
```
POST /api/Products/{id}/upload
```

---

##  Diferenciais Implementados

- Arquitetura em camadas
- Aplicação de princípios SOLID
- Separação clara de responsabilidades
- Testes unitários na camada de aplicação
- Docker com banco e API containerizados
- CI/CD automatizado com GitHub Actions
- Pipeline com build, testes e validação de imagem Docker

---

##  Observações

- O upload de imagem simula armazenamento S3 salvando arquivos localmente.
- O projeto pode ser executado integralmente via Docker.
- Swagger disponível para teste rápido dos endpoints.

---

##  Autor

Desenvolvido por **Felipe**.
