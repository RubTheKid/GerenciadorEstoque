using GerenciadorEstoque.Application.ProdutoAggregate.Query.GetProduto.Request;
using GerenciadorEstoque.Application.ProdutoAggregate.Query.GetProduto.Response;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Interfaces;
using MediatR;

namespace GerenciadorEstoque.Application.ProdutoAggregate.Query.GetProduto;

public class GetProdutoHandler : IRequestHandler<GetProdutoByIdRequest, GetProdutoResponse>,
                                 IRequestHandler<GetProdutoByGtinRequest, GetProdutoResponse>
{
    private readonly IProdutoRepository _repository;

    public GetProdutoHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetProdutoResponse> Handle(GetProdutoByIdRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var produto = await _repository.GetById(request.id);

        if (produto == null)
        {
            return null;
        }

        var response = new GetProdutoResponse
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            EstoqueMinimo = produto.EstoqueMinimo,
            Preco = produto.Preco,
            Gtin = produto.Gtin,
        };

        return response;
    }

    public async Task<GetProdutoResponse> Handle(GetProdutoByGtinRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var produto = await _repository.GetByGtin(request.gtin);

        if (produto == null)
        {
            return null;
        }

        var response = new GetProdutoResponse
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            EstoqueMinimo = produto.EstoqueMinimo,
            Preco = produto.Preco,
            Gtin = produto.Gtin,
        };

        return response;
    }


}
