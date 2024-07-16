using GerenciadorEstoque.Application.ProdutoAggregate.Command.RemoveProduto.Response;
using MediatR;

namespace GerenciadorEstoque.Application.ProdutoAggregate.Command.RemoveProduto.Request;

public sealed record RemoveProdutoRequest : IRequest<RemoveProdutoResponse>
{
    public Guid Id { get; set; }
}
