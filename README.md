# GG Bar | API de Gerenciamento

## 📌 Sobre o projeto

O **GG Bar** é uma **API para gerenciamento de um bar/restaurante**, criada com foco em estudo e prática de arquitetura, boas práticas e **TDD (Test-Driven Development)**.  
Com ela, é possível **cadastrar e administrar pratos/bebidas**, além de **criar pedidos e gerenciar os itens desses pedidos**, fornecendo uma base sólida para evoluir um sistema completo de atendimento e operação.

> Projeto desenvolvido **sem fins lucrativos**, com objetivo educacional.

## 🎯 Para que serve

A API centraliza as principais rotinas de operação, como:

- **Catálogo de produtos**: cadastro/consulta/edição/remoção de **pratos e bebidas**  
  - Observação: no sistema, **bebidas e pratos são tratados como a mesma entidade (Prato)**.
- **Gestão de pedidos**:
  - criação de pedidos
  - adição de itens em pedidos existentes
  - consulta de detalhes e listagem de pedidos
  - remoção de pedidos
- **Base para controle de dados do bar**, incluindo entidades como:
  - Fornecedores, Clientes, Despesas, Categorias, Produtos, Pratos, Pedidos e relacionamento `PedidoPrato`

## 🧱 Principais tecnologias e ferramentas utilizadas

- **ASP.NET Core 8.0** — construção da API
- **Entity Framework Core 9.0** — ORM e migrations
- **SQL Server** — banco de dados relacional
- **Swagger / OpenAPI** — documentação automática e teste de endpoints
- **Docker + Docker Compose** — execução da API e do banco via containers
- **FluentValidation** — validação de modelos
- **AutoMapper** — mapeamento objeto-objeto
- **Testes (TDD)** — projeto orientado a testes (há projetos de testes unitários e de integração)

## 🧪 Testes

O projeto foi estruturado com abordagem **TDD**, com separação de testes (ex.: testes comuns/validação e testes de integração), para garantir confiabilidade e facilitar manutenção/evolução.

## 🐳 Como rodar (resumo)

- **Recomendado:** via **Docker Compose** (sobe API + SQL Server e aplica migrations automaticamente).
- Alternativamente, é possível executar localmente com **.NET 8 SDK** e um **SQL Server** configurado.

## 📄 Licença

MIT.
