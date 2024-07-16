using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Query.GetProdutoEstoque.Response;
using MediatR;

namespace GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Query.GetProdutoEstoque.Request;

public sealed record GetProdutoEstoqueByLojaIdRequest(Guid LojaId) : IRequest<IEnumerable<ProdutoEstoqueResponse>> { };
