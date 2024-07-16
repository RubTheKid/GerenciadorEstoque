using GerenciadorEstoque.Application.ProdutoAggregate.Query.GetAllProdutos.Request;
using GerenciadorEstoque.Application.ProdutoAggregate.Query.GetAllProdutos.Response;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Interfaces;
using MediatR;

namespace GerenciadorEstoque.Application.ProdutoAggregate.Query.GetAllProdutos;

public class GetAllProdutosHandler : IRequestHandler<GetAllProdutosRequest, IEnumerable<GetAllProdutosResponse>>
{
    private readonly IProdutoRepository _repository;

    public GetAllProdutosHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<GetAllProdutosResponse>> Handle(GetAllProdutosRequest request, CancellationToken cancellationToken)
    {
        var allProdutos = await _repository.GetAll();

        var response = allProdutos.Select(x => new GetAllProdutosResponse
        {
            Id = x.Id,
            Nome = x.Nome,
            Gtin = x.Gtin,
            Descricao = x.Descricao,
            Preco = x.Preco,
            EstoqueMinimo = x.EstoqueMinimo,
        });

        return response;
    }
}
