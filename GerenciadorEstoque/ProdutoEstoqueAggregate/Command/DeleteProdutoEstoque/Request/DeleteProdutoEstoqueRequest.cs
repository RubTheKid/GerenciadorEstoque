using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.DeleteProdutoEstoque.Response;
using MediatR;

namespace GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.DeleteProdutoEstoque.Request;

public sealed record DeleteProdutoEstoqueRequest(Guid lojaId, Guid produtoId) : IRequest<DeleteProdutoEstoqueResponse> { };
