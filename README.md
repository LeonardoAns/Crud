# CRUD de Produtos e Categorias

## Descrição do Projeto

Este é um sistema de gerenciamento de produtos e categorias, desenvolvido com C# e .NET, para fins de prática e aprendizado.
Atualmente, apenas as funcionalidades de **categorias** e **produtos** estão totalmente implementadas, permitindo as operações básicas de CRUD (Create, Read, Update, Delete). As funcionalidades relacionadas  a **segurança** (usando Identity) estão em desenvolvimento.

## Estrutura do Projeto

O projeto é organizado nos seguintes diretórios principais:

### 1. **Core**

- **Projeto:** `Crud.Domain`
- **Responsabilidade:**
  - Definição das entidades e regras de negócio.
  - Interfaces e contratos que garantem a independência da camada de domínio.

### 2. **Persistence**

- **Projeto:** `Crud.Infrastructure`
- **Responsabilidade:**
  - Implementação de repositórios e integração com o banco de dados.
  - Configurações do Entity Framework Core.

### 3. **Application**

- **Projetos:**
  - `Crud.Application`: Camada de aplicação, que gerencia os casos de uso.
  - `Crud.Communication`: Definição de DTOs e comunicação entre as camadas.
  - `Crud.Exception`: Tratamento de exceções customizadas.
- **Responsabilidade:**
  - Coordenação entre as camadas de domínio e apresentação.
  - Garantia de que as regras de negócio sejam seguidas corretamente.

### 4. **Presentation**

- **Projeto:** `Crud.Api`
- **Responsabilidade:**
  - Exposição de endpoints RESTful.
  - Configurações de Swagger e documentação da API.

## Tecnologias Utilizadas

- **C# e .NET Core** para a construção da aplicação.
- **Entity Framework Core** para persistência de dados.
- **Swagger** para documentação e teste dos endpoints da API.
- **Identity** (em desenvolvimento) para gerenciamento de segurança e autenticação.

## Estrutura de Diretórios

Abaixo está a organização dos projetos no sistema:

```
├── Core
│   └── Crud.Domain
├── Persistence
│   └── Crud.Infrastructure
├── Application
│   ├── Crud.Application
│   ├── Crud.Communication
│   └── Crud.Exception
└── Presentation
    └── Crud.Api
```

## Status do Projeto

- **Categorias:** Finalizado.
  - CRUD completo e funcional.
  - Documentação com Swagger.
- **Produtos:** Em desenvolvimento.
  - CRUD completo e funcional.
  - Documentação com Swagger.
- **Segurança:** Em desenvolvimento.
  - Integração com Identity planejada para autenticação e autorização.
