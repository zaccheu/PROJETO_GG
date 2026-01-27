# GG Bar - API de Gerenciamento

Sistema completo de gerenciamento de pedidos, pratos e bebidas para bar, desenvolvido em ASP.NET Core 8.0 com arquitetura orientada a TDD (Test-Driven Development).

## 🚀 Tecnologias Utilizadas

- **ASP.NET Core 8.0** - Framework web
- **Entity Framework Core 9.0** - ORM para acesso a dados
- **SQL Server** - Banco de dados relacional
- **AutoMapper** - Mapeamento objeto-objeto
- **FluentValidation** - Validação de modelos
- **Swagger/OpenAPI** - Documentação automática da API
- **Docker** - Containerização

## 📋 Pré-requisitos

### Execução Local (sem Docker)
- .NET 8.0 SDK ou superior ([Download](https://dotnet.microsoft.com/download))
- SQL Server (LocalDB, Express ou Developer Edition)
- Visual Studio 2022 ou VS Code (opcional)

### Execução com Docker
- Docker Desktop ([Download](https://www.docker.com/products/docker-desktop))
- Docker Compose (geralmente incluído no Docker Desktop)

## 🔧 Configuração

### 1. Clonar o Repositório

```bash
git clone https://github.com/zaccheu/PROJETO_GG.git
cd PROJETO_GG
git checkout ArquiteturaOrientadaTDD
```

### 2. Configurar Connection String (Apenas para execução local)

Edite o arquivo `GG.Api/appsettings.Development.json` e ajuste a connection string para seu SQL Server:

```json
{
  "ConnectionStrings": {
    "MeuDbContext": "Server=localhost,1433;Database=GGBar;User Id=sa;Password=SuaSenha;TrustServerCertificate=True;MultipleActiveResultSets=true"
  }
}
```

## 🎯 Executando o Projeto

### Opção 1: Com Docker (Recomendado)

#### Iniciar o Projeto

```bash
# Na raiz do projeto
docker-compose up --build
```

Isso irá:
1. Criar um container com SQL Server
2. Criar um container com a API
3. Aplicar as migrations automaticamente
4. Iniciar a aplicação

#### Acessar a Aplicação

- **API**: http://localhost:5000
- **Swagger UI**: http://localhost:5000 (interface de documentação)
- **SQL Server**: localhost:1433
  - Usuário: `sa`
  - Senha: `YourStrong@Passw0rd`

#### Parar o Projeto

```bash
docker-compose down
```

#### Parar e Remover Volumes (limpar banco de dados)

```bash
docker-compose down -v
```

### Opção 2: Execução Local (sem Docker)

#### 1. Restaurar Pacotes

```bash
dotnet restore
```

#### 2. Aplicar Migrations

```bash
dotnet ef database update --project GG.Infrastructure --startup-project GG.Api
```

#### 3. Executar a Aplicação

```bash
cd GG.Api
dotnet run
```

#### Acessar a Aplicação

- **API**: http://localhost:5000 ou https://localhost:5001
- **Swagger UI**: http://localhost:5000 ou https://localhost:5001

## 📚 Documentação da API

A documentação completa da API está disponível através do Swagger UI. Acesse a URL raiz da aplicação após iniciar o projeto.

### Endpoints Principais

#### Pratos/Bebidas

- `POST /api/pratos` - Criar novo prato/bebida
- `GET /api/pratos` - Listar todos os pratos/bebidas
- `GET /api/pratos/{id}` - Obter prato/bebida específico
- `PUT /api/pratos/{id}` - Atualizar prato/bebida
- `DELETE /api/pratos/{id}` - Remover prato/bebida

#### Pedidos

- `POST /api/pedidos` - Criar novo pedido
- `GET /api/pedidos` - Listar todos os pedidos
- `GET /api/pedidos/{id}` - Obter detalhes de um pedido
- `POST /api/pedidos/{id}/itens` - Adicionar itens a um pedido existente
- `DELETE /api/pedidos/{id}` - Remover pedido

### Exemplos de Requisições

#### Criar Prato

```json
POST /api/pratos
{
  "nome": "Cerveja Heineken",
  "preco": 12.50
}
```

#### Criar Pedido

```json
POST /api/pedidos
{
  "data": "2026-01-07T18:00:00",
  "idCliente": null,
  "itens": [
    {
      "idPrato": 1,
      "quantidade": 2
    },
    {
      "idPrato": 3,
      "quantidade": 1
    }
  ]
}
```

#### Adicionar Itens a um Pedido

```json
POST /api/pedidos/1/itens
{
  "itens": [
    {
      "idPrato": 2,
      "quantidade": 3
    }
  ]
}
```

## 🗄️ Estrutura do Banco de Dados

### Tabelas Principais

- **Pratos** - Catálogo de pratos e bebidas
- **Pedidos** - Pedidos realizados
- **PedidoPrato** - Itens de cada pedido (tabela de relacionamento)
- **Produtos** - Estoque de produtos/ingredientes
- **Categorias** - Categorias de produtos
- **Despesas** - Controle de despesas
- **Clientes** - Cadastro de clientes
- **Fornecedores** - Cadastro de fornecedores

## 🧪 Testes

O projeto segue a metodologia TDD (Test-Driven Development).

### Executar Testes

```bash
# Testes unitários
dotnet test GG.Comum.Tests

# Testes de validação
dotnet test Validator.Tests

# Todos os testes
dotnet test
```

## 📁 Estrutura do Projeto

```
PROJETO_GG/
├── GG.Api/                    # Camada de apresentação (Controllers)
├── GG.Application/            # Camada de aplicação (Use Cases)
│   ├── UseCases/
│   │   ├── Pedidos/
│   │   ├── Pratos/
│   │   └── ...
│   └── AutoMapper/
├── GG.Communication/          # DTOs (Requests e Responses)
│   ├── Requests/
│   └── Responses/
├── GG.Domain/                 # Entidades e interfaces
│   ├── Entity/
│   └── Repositories/
├── GG.Exception/              # Exceções personalizadas
├── GG.Infrastructure/         # Implementação de repositórios e DbContext
│   ├── DataAccess/
│   └── Migrations/
├── GG.Comum.Tests/            # Testes unitários
├── Validator.Tests/           # Testes de validação
├── Dockerfile                 # Configuração Docker da API
├── docker-compose.yml         # Orquestração de containers
└── README.md
```

## 🔨 Comandos Úteis

### Entity Framework

```bash
# Adicionar nova migration
dotnet ef migrations add NomeDaMigration --project GG.Infrastructure --startup-project GG.Api

# Aplicar migrations
dotnet ef database update --project GG.Infrastructure --startup-project GG.Api

# Reverter migration
dotnet ef migrations remove --project GG.Infrastructure --startup-project GG.Api

# Gerar script SQL
dotnet ef migrations script --project GG.Infrastructure --startup-project GG.Api
```

### Docker

```bash
# Construir imagens
docker-compose build

# Iniciar serviços
docker-compose up

# Iniciar em background
docker-compose up -d

# Ver logs
docker-compose logs -f

# Parar serviços
docker-compose down

# Limpar tudo (incluindo volumes)
docker-compose down -v

# Reconstruir e iniciar
docker-compose up --build
```

## 🐛 Troubleshooting

### Problema: Erro de conexão com SQL Server no Docker

**Solução**: Aguarde alguns segundos após iniciar o container. O SQL Server demora para inicializar completamente. O healthcheck do docker-compose já cuida disso.

### Problema: Porta 1433 ou 5000 já está em uso

**Solução**: Altere as portas no `docker-compose.yml`:

```yaml
ports:
  - "1434:1433"  # SQL Server
  # ou
  - "5002:8080"  # API
```

### Problema: Migrations não aplicadas

**Solução manual**:

```bash
# Com Docker
docker-compose exec gg.api dotnet ef database update

# Sem Docker
dotnet ef database update --project GG.Infrastructure --startup-project GG.Api
```

### Problema: Erro de autenticação no SQL Server

**Solução**: Verifique se a senha no docker-compose.yml e no appsettings.json estão iguais: `YourStrong@Passw0rd`

## 👥 Contribuindo

1. Faça fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/MinhaFeature`)
3. Commit suas mudanças (`git commit -m 'Adiciona MinhaFeature'`)
4. Push para a branch (`git push origin feature/MinhaFeature`)
5. Abra um Pull Request

## 📝 Notas Importantes

- **Bebidas = Pratos**: No sistema, bebidas e pratos são tratados como a mesma entidade (Prato)
- **Segurança**: Esta é uma versão de desenvolvimento. Não há autenticação implementada
- **Senha do SQL Server**: Altere a senha padrão em ambiente de produção
- **Connection String**: Use variáveis de ambiente em produção

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.

## 📞 Suporte

Para dúvidas ou problemas, abra uma issue no GitHub ou entre em contato com a equipe de desenvolvimento.

---

**Desenvolvido com ❤️ pela equipe GG Bar**
