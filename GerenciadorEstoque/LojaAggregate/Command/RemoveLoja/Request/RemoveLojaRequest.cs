using GerenciadorEstoque.Application.LojaAggregate.Command.RemoveLoja.Response;
using MediatR;

namespace GerenciadorEstoque.Application.LojaAggregate.Command.RemoveLoja.Request
{
    public sealed record RemoveLojaRequest : IRequest<RemoveLojaResponse>
    {
        public Guid Id { get; set; }
    }
}
