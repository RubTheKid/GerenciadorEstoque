using GerenciadorEstoque.Application.LojaAggregate.Query.GetLoja.Response;
using MediatR;

namespace GerenciadorEstoque.Application.LojaAggregate.Query.GetLoja.Request;

public sealed record GetLojaByCodigoRequest(string codigo) : IRequest<GetLojaResponse> { };
