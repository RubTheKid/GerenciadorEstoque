using GerenciadorEstoque.Application.ProdutoAggregate.Query.GetAllProdutos.Response;
using MediatR;

namespace GerenciadorEstoque.Application.ProdutoAggregate.Query.GetAllProdutos.Request;

public sealed record GetAllProdutosRequest() : IRequest<IEnumerable<GetAllProdutosResponse>> { };
