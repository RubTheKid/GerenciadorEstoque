using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Query.GetProdutoEstoque.Response;
using MediatR;

namespace GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Query.GetProdutoEstoque.Request;

public sealed record GetProdutoEstoqueByLojaIdAndProdutoIdRequest(Guid LojaId, Guid ProdutoId) : IRequest<IEnumerable<ProdutoEstoqueResponse>> { };
