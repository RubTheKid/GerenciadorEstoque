using GerenciadorEstoque.Application.ProdutoAggregate.Query.GetProduto.Response;
using MediatR;

namespace GerenciadorEstoque.Application.ProdutoAggregate.Query.GetProduto.Request;

public sealed record GetProdutoByIdRequest(Guid id) : IRequest<GetProdutoResponse> { };
