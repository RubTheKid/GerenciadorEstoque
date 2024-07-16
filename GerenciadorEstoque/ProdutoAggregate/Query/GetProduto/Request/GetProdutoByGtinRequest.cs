using GerenciadorEstoque.Application.ProdutoAggregate.Query.GetProduto.Response;
using MediatR;

namespace GerenciadorEstoque.Application.ProdutoAggregate.Query.GetProduto.Request;

public sealed record GetProdutoByGtinRequest(string gtin) : IRequest<GetProdutoResponse> { };
