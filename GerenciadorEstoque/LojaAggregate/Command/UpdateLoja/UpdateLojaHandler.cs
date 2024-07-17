using GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja.Request;
using GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja.Response;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Interfaces;
using MediatR;

namespace GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja;

public class UpdateLojaHandler : IRequestHandler<UpdateLojaRequest, UpdateLojaResponse>
{
    private readonly ILojaRepository _repository;

    public UpdateLojaHandler(ILojaRepository repository)
    {
        _repository = repository;
    }


    public async Task<UpdateLojaResponse> Handle(UpdateLojaRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var lojaCadastrada = await _repository.GetById(request.Id);

        if (lojaCadastrada != null)
        {
            lojaCadastrada.AtualizarLoja(request.Nome, request.Codigo, request.Endereco, request.Telefone);

            await _repository.Update(lojaCadastrada);
        }

        return new UpdateLojaResponse
        {
            Id = lojaCadastrada.Id,
            Nome = lojaCadastrada.Nome,
            Telefone = lojaCadastrada.Telefone,
            Endereco = lojaCadastrada.Endereco,
            Codigo = lojaCadastrada.Codigo
        };
    }
}
