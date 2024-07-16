using GerenciadorEstoque.Application.LojaAggregate.Query.GetLoja.Request;
using GerenciadorEstoque.Application.LojaAggregate.Query.GetLoja.Response;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Interfaces;
using MediatR;

namespace GerenciadorEstoque.Application.LojaAggregate.Query.GetLoja;

public class GetLojaHandler : IRequestHandler<GetLojaByIdRequest, GetLojaResponse>,
                              IRequestHandler<GetLojaByCodigoRequest, GetLojaResponse>
{
    private readonly ILojaRepository _repository;

    public GetLojaHandler(ILojaRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetLojaResponse> Handle(GetLojaByIdRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var loja = await _repository.GetById(request.id);

        if (loja == null) return null;

        var response = new GetLojaResponse
        {
            Id = loja.Id,
            Nome = loja.Nome,
            Endereco = loja.Endereco,
            Telefone = loja.Telefone,
            Codigo = loja.Codigo
        };

        return response;
    }

    public async Task<GetLojaResponse> Handle(GetLojaByCodigoRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var loja = await _repository.GetByCode(request.codigo);

        if (loja == null) return null;


        var response = new GetLojaResponse
        {
            Id = loja.Id,
            Nome = loja.Nome,
            Endereco = loja.Endereco,
            Telefone = loja.Telefone,
            Codigo = loja.Codigo
        };

        return response;
    }
}
