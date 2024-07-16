using GerenciadorEstoque.Application.ProdutoAggregate.Command.RemoveProduto.Request;
using GerenciadorEstoque.Application.ProdutoAggregate.Command.RemoveProduto.Response;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Interfaces;
using MediatR;

namespace GerenciadorEstoque.Application.ProdutoAggregate.Command.RemoveProduto;

public class RemoveProdutoHandler : IRequestHandler<RemoveProdutoRequest, RemoveProdutoResponse>
{
    private readonly IProdutoRepository _repository;

    public RemoveProdutoHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<RemoveProdutoResponse> Handle(RemoveProdutoRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var produto = await _repository.GetById(request.Id);

        if (produto == null)
        {
            throw new Exception("Produto não encontrado");
        }

        await _repository.Delete(request.Id);

        return new RemoveProdutoResponse
        {
            Id = produto.Id,
            isDeleted = produto.IsDeleted,
            DateDeleted = produto.DateDeleted
        };
    }
}
