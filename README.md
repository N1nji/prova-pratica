# 🛒 Claps Product Catalog API

API REST desenvolvida em .NET 8 para gerenciamento de produtos de um catálogo de e-commerce.

Este projeto foi desenvolvido como prova prática para a vaga de Desenvolvedor .NET, seguindo boas práticas de arquitetura, organização e qualidade de código.

---

## Tecnologias Utilizadas

- .NET 8  
- ASP.NET Core Web API  
- Entity Framework Core  
- PostgreSQL  
- Docker & Docker Compose  
- Swagger (OpenAPI)  
- xUnit (Testes Unitários)  
- GitHub Actions (CI/CD)  

---

## Arquitetura

O projeto segue arquitetura em camadas, com separação clara de responsabilidades:

API (Controllers)  
↓
Application (Regras de negócio)  
↓
Domain (Entidades e regras do domínio)  
↓
Infrastructure (EF Core, Banco de Dados, FileService)  


### 📂 Estrutura do Projeto

- `Claps.ProductCatalog.Api` → Camada de apresentação (Controllers)
- `Claps.ProductCatalog.Application` → Serviços e interfaces
- `Claps.ProductCatalog.Domain` → Entidades e enums
- `Claps.ProductCatalog.Infrastructure` → Repositórios, EF Core e FileService
- `Claps.ProductCatalog.Tests` → Testes unitários

---

## 📦 Funcionalidades Implementadas

Cadastrar produto  
Editar produto  
Excluir produto  
Listar produtos com filtros:
- Por categoria
- Por faixa de preço
- Por status (Ativo/Inativo)

Upload de imagem do produto  
- Simulação de envio para S3 (salvando localmente em `/uploads`)

Documentação automática com Swagger  

---

## Como Executar com Docker

### Pré-requisitos:
- Docker Desktop instalado
- WSL 2 habilitado (Windows)

### Passos:

```bash
docker-compose up --build

## Após iniciar, acessar:

```bash
http://localhost:8080/swagger

## Rodar Testes

```bash
dotnet test

### Endpoints Principais

Criar Produto
```bash
POST /api/Products

Listar Produtos
```bash
GET /api/Products

Filtros disponíveis:

category  
minPrice  
maxPrice  
status  

## Buscar Produto por ID

```bash
GET /api/Products/{id}

Atualizar Produto
```bash
PUT /api/Products/{id}

Deletar Produto
```bash
DELETE /api/Products/{id}

Upload de Imagem
```bash
POST /api/Products/{id}/upload

## Diferenciais Implementados

Arquitetura em camadas  
Princípios SOLID aplicados  
Separação de responsabilidades  
Testes unitários na camada de aplicação  
Docker com banco e API  
Configuração preparada para CI/CD  

## Observações Finais TESTE

O upload de imagem simula armazenamento S3 salvando arquivos localmente.  
O projeto pode ser executado totalmente via Docker.  
Swagger disponível para teste rápido dos endpoints.  

##  Autor

Desenvolvido por Felipe.

