using GerenciadorEstoque.Application.LojaAggregate.Query.GetAll.Request;
using GerenciadorEstoque.Application.LojaAggregate.Query.GetAll.Response;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Interfaces;
using MediatR;

namespace GerenciadorEstoque.Application.LojaAggregate.Query.GetAll;

public class GetAllLojasHandler : IRequestHandler<GetAllLojasRequest, IEnumerable<GetAllLojasResponse>>
{
    private readonly ILojaRepository _repository;

    public GetAllLojasHandler(ILojaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<GetAllLojasResponse>> Handle(GetAllLojasRequest request, CancellationToken cancellationToken)
    {
        var lojas = await _repository.GetAll();

        var response = lojas.Select(x => new GetAllLojasResponse
        {
            Id = x.Id,
            Nome = x.Nome,
            Endereco = x.Endereco,
            Telefone = x.Telefone,
            Codigo = x.Codigo,
        });
        return response;
    }
}
