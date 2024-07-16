using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.UpdateProdutoEstoque.Response;
using MediatR;

namespace GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.UpdateProdutoEstoque.Request;

public sealed record UpdateProdutoEstoqueRequest(Guid LojaId, Guid ProdutoId, int NovoEstoque) : IRequest<UpdateProdutoEstoqueResponse> { };