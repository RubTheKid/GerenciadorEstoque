using GerenciadorEstoque.Application.ProdutoAggregate.Command.AddProduto.Request;
using GerenciadorEstoque.Application.ProdutoAggregate.Command.AddProduto.Response;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Validations;
using MediatR;


namespace GerenciadorEstoque.Application.ProdutoAggregate.Command.AddProduto;

public class AddProdutoHandler : IRequestHandler<AddProdutoRequest, AddProdutoResponse>
{
    private readonly IProdutoRepository _repository;

    public AddProdutoHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<AddProdutoResponse> Handle(AddProdutoRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        var preco = new Preco(request.Preco);

        var produto = new Produto
        (
            request.Nome,
            request.Descricao,
            request.Gtin,
            preco,
            request.EstoqueMinimo
        );


        await _repository.Create(produto);

        return new AddProdutoResponse
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Gtin = produto.Gtin,
            Descricao = produto.Descricao,
            EstoqueMinimo = produto.EstoqueMinimo,
            Preco = produto.Preco.Valor
        };
    }
}
