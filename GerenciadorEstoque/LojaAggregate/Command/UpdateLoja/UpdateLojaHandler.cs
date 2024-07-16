using GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja.Request;
using GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja.Response;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Inferfaces;
using MediatR;

namespace GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja;

public class UpdateLojaHandler :
        IRequestHandler<UpdateNomeRequest, UpdateLojaResponse>,
        IRequestHandler<UpdateEnderecoRequest, UpdateLojaResponse>,
        IRequestHandler<UpdateCodigoRequest, UpdateLojaResponse>,
        IRequestHandler<UpdateTelefoneRequest, UpdateLojaResponse>
{
    private readonly ILojaRepository _repository;

    public UpdateLojaHandler(ILojaRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateLojaResponse> Handle(UpdateNomeRequest request, CancellationToken cancellationToken)
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

        loja.AlterarNome(request.NovoNome);
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

    public async Task<UpdateLojaResponse> Handle(UpdateEnderecoRequest request, CancellationToken cancellationToken)
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

        loja.AlterarEndereco(request.NovoEndereco);
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

    public async Task<UpdateLojaResponse> Handle(UpdateCodigoRequest request, CancellationToken cancellationToken)
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

        loja.AlterarCodigo(request.NovoCodigo);
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

    public async Task<UpdateLojaResponse> Handle(UpdateTelefoneRequest request, CancellationToken cancellationToken)
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

        loja.AlterarTelefone(request.NovoTelefone);
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
