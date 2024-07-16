
using GerenciadorEstoque.Application.LojaAggregate.Query.GetLoja.Response;
using MediatR;

namespace GerenciadorEstoque.Application.LojaAggregate.Query.GetLoja.Request;
public sealed record GetLojaByIdRequest(Guid id) : IRequest<GetLojaResponse> { };
