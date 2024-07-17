using GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja.Response;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;
using MediatR;

namespace GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja.Request;

public sealed record UpdateLojaRequest : IRequest<UpdateLojaResponse>
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public Endereco Endereco { get; set; }
    public CodigoLoja Codigo { get; set; }
    public TelefoneLoja Telefone { get; set; }
}
