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

        var loja = await _repository.GetById(request.LojaId);
        if (loja == null)
        {
            throw new Exception("Loja não encontrada");
        }

        if (!string.IsNullOrEmpty(request.NovoNome))
        {
            loja.AlterarNome(request.NovoNome);
        }

        if (request.NovoEndereco != null)
        {
            loja.AlterarEndereco(request.NovoEndereco);
        }

        if (request.NovoCodigo != null)
        {
            loja.AlterarCodigo(request.NovoCodigo);
        }

        if (request.NovoTelefone != null)
        {
            loja.AlterarTelefone(request.NovoTelefone);
        }

        await _repository.Update(loja);

        return new UpdateLojaResponse
        {
            Id = loja.Id,
            Nome = loja.Nome,
            Telefone = loja.Telefone,
            Endereco = loja.Endereco,
            Codigo = loja.Codigo
        };
    }
}
