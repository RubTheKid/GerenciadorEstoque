using GerenciadorEstoque.Application.LojaAggregate.Query.GetAll.Response;
using MediatR;

namespace GerenciadorEstoque.Application.LojaAggregate.Query.GetAll.Request;

public sealed record GetAllLojasRequest() : IRequest<IEnumerable<GetAllLojasResponse>> { };
