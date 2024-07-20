# GerenciadorEstoque

## Estrutura do Projeto

- **GerenciadorEstoque.Core** - Cont�m a l�gica da autentica��o/autoriza��o com JWT.
- **GerenciadorEstoque.Infra** - Armazenamento da l�gica de acesso ao banco de dados e reposit�rios das entidades.
- **GerenciadorEstoque.Domain** - Cont�m a l�gica b�sica do projeto, incluindo as entidades e interfaces dos reposit�rios.
- **GerenciadorEstoque.Api** - API para gerenciamento de estoques, lojas e produtos.
- **GerenciadorEstoque.Presentation** - Aplica��o MVC para a intera��o usu�rio-API.

## Configura��o

1. Certifique-se de que o SDK .NET 8 est� instalado, assim como o Microsoft SQL Server.

2. Aplique as migra��es:

    ```sh
    dotnet ef database update --context AppDbContext --project ./GerenciadorEstoque.Infra/ --startup-project ./GerenciadorEstoque.Api/
    dotnet ef database update --context AuthDbContext --project ./Auth/ --startup-project ./GerenciadorEstoque.Api/
    ```

## Execu��o

1. Certifique-se que a inicializa��o est� definida para m�ltiplos projetos, sendo eles:
    - GerenciadorEstoque.Presentation
    - GerenciadorEstoque.Api

2. J� foi configurado um usu�rio base para testes, sendo ele "superadmin" e senha "Senha123!".

3. Use o usu�rio acima para realizar login e acessar m�todos protegidos por autentica��o.

## Sobre o Desafio

O desafio visa a cria��o de uma aplica��o web, sendo uma API e um MVC para o front-end.

As entidades solicitadas eram:
- Produto
- ItemEstoque
- Loja

Minha proposta foi uma modifica��o dessa rela��o, pois seria muito mais interessante uma rela��o N-N entre produto e loja. Por conta disso, mantive uma rela��o de uma loja ter N produtos.

### Requisitos Solicitados

- CRUD Lojas
- CRUD Produtos
- CRUD Estoque

Ao meu ver, essa proposta de ter endpoints CRUD para toda aplica��o gera c�digo desnecess�rio, pois muitas a��es podem ser realizadas apenas pelos reposit�rios das entidades, sem necessariamente serem realizadas por endpoints.

### Tecnologias Utilizadas

- .NET Core MVC como estrutura
- EF Core para manipula��o de dados
- SQL Server
- Tratamento de erros para entradas inv�lidas (n�o implementado por falta de tempo)
- API para comunica��o com telas

## Diferenciais

Vale a pena destacar que n�o foi utilizado o AutoMapper nesse projeto. Minha op��o por n�o utilizar AutoMapper vem de muita frustra��o pela dificuldade de configurar o mapeamento de entidades, e a perda de performance que ele causa.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.