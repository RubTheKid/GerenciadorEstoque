using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.AddProdutoEstoque.Request;
using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.AddProdutoEstoque.Response;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate.Interfaces;
using MediatR;

namespace GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.AddProdutoEstoque;

public class AddProdutoEstoqueHandler : IRequestHandler<AddProdutoEstoqueRequest, AddProdutoEstoqueResponse>
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly ILojaRepository _lojaRepository;
    private readonly IProdutoEstoqueRepository _produtoEstoqueRepository;

    public AddProdutoEstoqueHandler(IProdutoRepository produtoRepository, ILojaRepository lojaRepository, IProdutoEstoqueRepository produtoEstoqueRepository)
    {
        _produtoRepository = produtoRepository;
        _lojaRepository = lojaRepository;
        _produtoEstoqueRepository = produtoEstoqueRepository;
    }

    public async Task<AddProdutoEstoqueResponse> Handle(AddProdutoEstoqueRequest request, CancellationToken cancellationToken)
    {
        var produto = await _produtoRepository.GetById(request.ProdutoId);
        var loja = await _lojaRepository.GetById(request.LojaId);

        if (produto == null || loja == null)
        {
            throw new ArgumentNullException(produto == null ? nameof(produto) : nameof(loja));
        }

        var produtoEstoque = new ProdutoEstoque(produto, loja, request.Estoque);

        await _produtoEstoqueRepository.Create(produtoEstoque);

        var response = new AddProdutoEstoqueResponse
        {
            ProdutoId = produtoEstoque.ProdutoId,
            LojaId = produtoEstoque.LojaId,
            Estoque = produtoEstoque.Estoque
        };

        return response;
    }
}
