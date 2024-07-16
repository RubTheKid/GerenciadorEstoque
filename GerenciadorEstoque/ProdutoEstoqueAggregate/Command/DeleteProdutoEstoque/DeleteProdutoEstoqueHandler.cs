using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.DeleteProdutoEstoque.Request;
using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.DeleteProdutoEstoque.Response;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate.Interfaces;
using MediatR;

namespace GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.DeleteProdutoEstoque;

public class DeleteProdutoEstoqueHandler : IRequestHandler<DeleteProdutoEstoqueRequest, DeleteProdutoEstoqueResponse>
{
    private readonly IProdutoEstoqueRepository _repository;

    public DeleteProdutoEstoqueHandler(IProdutoEstoqueRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteProdutoEstoqueResponse> Handle(DeleteProdutoEstoqueRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var produtoEstoque = await _repository.GetById(request.lojaId, request.produtoId);

        if (produtoEstoque == null)
        {
            throw new Exception("Ocorreu um erro ao processar a solicitação.");
        }

        await _repository.Delete(request.lojaId, request.produtoId);

        return new DeleteProdutoEstoqueResponse
        {
            LojaId = produtoEstoque.LojaId,
            ProdutoId = produtoEstoque.ProdutoId
        };
    }
}
