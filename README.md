SistemaDeReservas
=================

API desenvolvida em .NET para gerenciamento de reservas, com foco em aprendizado de acesso a dados utilizando **Dapper**.

O projeto tem como objetivo praticar consultas SQL diretas, controle de conexões e manipulação de dados com alta performance, sem utilizar Entity Framework.

* * * * *

Objetivo do Projeto
-------------------

Este projeto foi desenvolvido com fins de estudo para:

-   Aprender o uso do **Dapper**

-   Trabalhar com SQL Server utilizando queries manuais

-   Entender melhor o controle de conexões e execução de comandos

-   Comparar abordagem Dapper vs Entity Framework

-   Praticar construção de APIs REST em .NET

* * * * *

Tecnologias Utilizadas
----------------------

-   .NET

-   ASP.NET Core Web API

-   Dapper

-   SQL Server

-   C#

-   ADO.NET

* * * * *

Conceitos Praticados
--------------------

-   Execução de queries com `QueryAsync`

-   Execução de comandos com `ExecuteAsync`

-   Mapeamento manual de objetos

-   Uso de parâmetros para evitar SQL Injection

-   Controle explícito de conexão com banco

-   Organização básica de camadas

* * * * *

Estrutura do Projeto
--------------------

SistemaDeReservas\
│\
├── Controllers\
├── Models\
├── Repositories\
├── Data\
├── Program.cs\
└── appsettings.json

*(A estrutura pode variar conforme evolução do projeto.)*

* * * * *

Configuração do Banco de Dados
------------------------------

Exemplo de estrutura básica para tabela de reservas:

CREATE TABLE Reservas (\
    Id INT IDENTITY(1,1) PRIMARY KEY,\
    NomeCliente VARCHAR(100) NOT NULL,\
    DataReserva DATETIME NOT NULL,\
    NumeroPessoas INT NOT NULL,\
    CriadoEm DATETIME NOT NULL\
);

* * * * *

Configuração da Connection String
---------------------------------

No arquivo `appsettings.json`:

{\
  "ConnectionStrings": {\
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=SistemaReservasDB;Trusted_Connection=True;TrustServerCertificate=True;"\
  }\
}

* * * * *

Executando o Projeto
--------------------

1.  Restaurar dependências:

dotnet restore

1.  Executar aplicação:

dotnet run

A API estará disponível em:

https://localhost:xxxx

* * * * *

Endpoints Principais (Exemplo)
------------------------------

-   `GET /reservas` → Lista todas as reservas

-   `GET /reservas/{id}` → Busca reserva por ID

-   `POST /reservas` → Cria nova reserva

-   `PUT /reservas/{id}` → Atualiza reserva

-   `DELETE /reservas/{id}` → Remove reserva

* * * * *

Por que Dapper?
---------------

Dapper é um micro-ORM que:

-   É mais performático que ORMs tradicionais

-   Permite controle total sobre o SQL

-   Reduz abstrações desnecessárias

-   É ideal para cenários onde performance é prioridade

Este projeto foi criado para entender quando faz sentido utilizar Dapper ao invés de Entity Framework.

* * * * *

Melhorias Futuras
-----------------

-   Implementar validações de negócio

-   Adicionar controle de conflitos de horário

-   Implementar paginação

-   Criar testes automatizados

-   Implementar autenticação

-   Evoluir para arquitetura mais estruturada

* * * * *

Observações
-----------

-   Projeto voltado exclusivamente para aprendizado.

-   Não possui validações avançadas.

-   Não possui autenticação/autorização.

-   Foco principal está no acesso a dados com Dapper.

* * * * *

Autor
-----

Desenvolvido por Vorceek\
Projeto de estudo focado em Dapper e manipulação direta de SQL em APIs .NET.
