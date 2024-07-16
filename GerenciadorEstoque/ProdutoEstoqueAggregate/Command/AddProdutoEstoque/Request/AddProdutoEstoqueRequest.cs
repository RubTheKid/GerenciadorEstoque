using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.AddProdutoEstoque.Response;
using MediatR;

namespace GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.AddProdutoEstoque.Request;

public sealed record AddProdutoEstoqueRequest(Guid ProdutoId, Guid LojaId, int Estoque) : IRequest<AddProdutoEstoqueResponse> { };