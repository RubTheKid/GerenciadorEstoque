using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.UpdateProdutoEstoque.Request;
using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.UpdateProdutoEstoque.Response;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate.Interfaces;
using MediatR;

namespace GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.UpdateProdutoEstoque;

public class UpdateProdutoEstoqueHandler : IRequestHandler<UpdateProdutoEstoqueRequest, UpdateProdutoEstoqueResponse>
{
    private readonly IProdutoEstoqueRepository _repository;

    public UpdateProdutoEstoqueHandler(IProdutoEstoqueRepository produtoEstoqueRepository)
    {
        _repository = produtoEstoqueRepository;
    }

    public async Task<UpdateProdutoEstoqueResponse> Handle(UpdateProdutoEstoqueRequest request, CancellationToken cancellationToken)
    {
        var produtoEstoque = await _repository.GetById(request.LojaId, request.ProdutoId);

        if (produtoEstoque == null)
        {
            throw new ArgumentNullException(nameof(produtoEstoque));
        }

        produtoEstoque.AlterarQuantidade(request.NovoEstoque);

        await _repository.Update(produtoEstoque);

        var response = new UpdateProdutoEstoqueResponse
        {
            ProdutoId = produtoEstoque.ProdutoId,
            LojaId = produtoEstoque.LojaId,
            Estoque = produtoEstoque.Estoque
        };

        return response;
    }
}
