using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Query.GetProdutoEstoque.Request;
using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Query.GetProdutoEstoque.Response;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate.Interfaces;
using MediatR;

namespace GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Query;

public class ProdutoEstoqueHandler : IRequestHandler<GetProdutoEstoqueByLojaIdRequest, IEnumerable<ProdutoEstoqueResponse>>,
                                     IRequestHandler<GetProdutoEstoqueByProdutoIdRequest, IEnumerable<ProdutoEstoqueResponse>>,
                                     IRequestHandler<GetProdutoEstoqueByLojaIdAndProdutoIdRequest, IEnumerable<ProdutoEstoqueResponse>>
{
    private readonly IProdutoEstoqueRepository _repository;

    public ProdutoEstoqueHandler(IProdutoEstoqueRepository repository)
    {
        _repository = repository;
    }


    public async Task<IEnumerable<ProdutoEstoqueResponse>> Handle(GetProdutoEstoqueByLojaIdRequest request, CancellationToken cancellationToken)
    {
        var produtosEstoque = await _repository.GetByLojaId(request.LojaId);

        return produtosEstoque.Select(pe => new ProdutoEstoqueResponse
        {
            ProdutoId = pe.ProdutoId,
            LojaId = pe.LojaId,
            Estoque = pe.Estoque,
            ProdutoNome = pe.Produto.Nome,
            LojaNome = pe.Loja.Nome,
            Preco = pe.Produto.Preco,
            Descricao = pe.Produto.Descricao,
            EstoqueMinimo = pe.Produto.EstoqueMinimo,
        });
    }

    public async Task<IEnumerable<ProdutoEstoqueResponse>> Handle(GetProdutoEstoqueByProdutoIdRequest request, CancellationToken cancellationToken)
    {
        var produtosEstoque = await _repository.GetByProdutoId(request.ProdutoId);

        return produtosEstoque.Select(pe => new ProdutoEstoqueResponse
        {
            ProdutoId = pe.ProdutoId,
            LojaId = pe.LojaId,
            Estoque = pe.Estoque,
            ProdutoNome = pe.Produto.Nome,
            LojaNome = pe.Loja.Nome

        });
    }

    public async Task<IEnumerable<ProdutoEstoqueResponse>> Handle(GetProdutoEstoqueByLojaIdAndProdutoIdRequest request, CancellationToken cancellationToken)
    {
        var produtosEstoque = await _repository.GetByLojaIdAndProdutoId(request.LojaId, request.ProdutoId);

        return produtosEstoque.Select(pe => new ProdutoEstoqueResponse
        {
            ProdutoId = pe.ProdutoId,
            LojaId = pe.LojaId,
            Estoque = pe.Estoque,
            ProdutoNome = pe.Produto.Nome,
            LojaNome = pe.Loja.Nome
        });
    }
}
