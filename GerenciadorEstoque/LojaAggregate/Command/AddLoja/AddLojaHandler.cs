using GerenciadorEstoque.Application.LojaAggregate.Command.AddLoja.Request;
using GerenciadorEstoque.Application.LojaAggregate.Command.AddLoja.Response;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Interfaces;
using MediatR;

namespace GerenciadorEstoque.Application.LojaAggregate.Command.AddLoja;

public class AddLojaHandler : IRequestHandler<AddLojaRequest, AddLojaResponse>
{
    private readonly ILojaRepository _repository;

    public AddLojaHandler(ILojaRepository repository)
    {
        _repository = repository;
    }

    public async Task<AddLojaResponse> Handle(AddLojaRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var loja = new Loja
        (
                request.Nome,
                request.Endereco,
                request.Codigo,
                request.Telefone
        );

        await _repository.Create(loja);

        return new AddLojaResponse
        {
            Id = loja.Id,
            Nome = loja.Nome,
            Telefone = loja.Telefone,
            Endereco = loja.Endereco,
            Codigo = loja.Codigo
        };
    }
}