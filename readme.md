# GerenciadorEstoque

## Estrutura do Projeto

- **GerenciadorEstoque.Core** - Contém a lógica da autenticação/autorização com JWT.
- **GerenciadorEstoque.Infra** - Armazenamento da lógica de acesso ao banco de dados e repositórios das entidades.
- **GerenciadorEstoque.Domain** - Contém a lógica básica do projeto, incluindo as entidades e interfaces dos repositórios.
- **GerenciadorEstoque.Api** - API para gerenciamento de estoques, lojas e produtos.
- **GerenciadorEstoque.Presentation** - Aplicação MVC para a interação usuário-API.

## Configuração

1. Certifique-se de que o SDK .NET 8 está instalado, assim como o Microsoft SQL Server.

2. Aplique as migrações:

    ```sh
    dotnet ef database update --context AppDbContext --project ./GerenciadorEstoque.Infra/ --startup-project ./GerenciadorEstoque.Api/
    dotnet ef database update --context AuthDbContext --project ./Auth/ --startup-project ./GerenciadorEstoque.Api/
    ```

## Execução

1. Certifique-se que a inicialização está definida para múltiplos projetos, sendo eles:
    - GerenciadorEstoque.Presentation
    - GerenciadorEstoque.Api

2. Já foi configurado um usuário base para testes, sendo ele "superadmin" e senha "Senha123!".

3. Use o usuário acima para realizar login e acessar métodos protegidos por autenticação.

## Sobre o Desafio

O desafio visa a criação de uma aplicação web, sendo uma API e um MVC para o front-end.

As entidades solicitadas eram:
- Produto
- ItemEstoque
- Loja

Minha proposta foi uma modificação dessa relação, pois seria muito mais interessante uma relação N-N entre produto e loja. Por conta disso, mantive uma relação de uma loja ter N produtos.

### Requisitos Solicitados

- CRUD Lojas
- CRUD Produtos
- CRUD Estoque

Ao meu ver, essa proposta de ter endpoints CRUD para toda aplicação gera código desnecessário, pois muitas ações podem ser realizadas apenas pelos repositórios das entidades, sem necessariamente serem realizadas por endpoints.

### Tecnologias Utilizadas

- .NET Core MVC como estrutura
- EF Core para manipulação de dados
- SQL Server
- Tratamento de erros para entradas inválidas (não implementado por falta de tempo)
- API para comunicação com telas

## Diferenciais

Vale a pena destacar que não foi utilizado o AutoMapper nesse projeto. Minha opção por não utilizar AutoMapper vem de muita frustração pela dificuldade de configurar o mapeamento de entidades, e a perda de performance que ele causa.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.