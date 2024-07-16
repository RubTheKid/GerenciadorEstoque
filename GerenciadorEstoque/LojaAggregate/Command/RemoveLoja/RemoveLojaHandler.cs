using GerenciadorEstoque.Application.LojaAggregate.Command.RemoveLoja.Request;
using GerenciadorEstoque.Application.LojaAggregate.Command.RemoveLoja.Response;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Interfaces;
using MediatR;

namespace GerenciadorEstoque.Application.LojaAggregate.Command.RemoveLoja;

public class RemoveLojaHandler : IRequestHandler<RemoveLojaRequest, RemoveLojaResponse>
{
    private readonly ILojaRepository _repository;

    public RemoveLojaHandler(ILojaRepository repository)
    {
        _repository = repository;
    }

    public async Task<RemoveLojaResponse> Handle(RemoveLojaRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var loja = await _repository.GetById(request.Id);

        if (loja == null)
        {
            throw new Exception("Loja não encontrada");
        }

        await _repository.Delete(request.Id);

        return new RemoveLojaResponse
        {
            Id = request.Id,
            IsDeleted = loja.IsDeleted,

        };
    }
}
