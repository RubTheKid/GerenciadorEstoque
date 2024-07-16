using GerenciadorEstoque.Application.LojaAggregate.Command.AddLoja.Response;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;
using MediatR;

namespace GerenciadorEstoque.Application.LojaAggregate.Command.AddLoja.Request;

public class AddLojaRequest : IRequest<AddLojaResponse>
{
    public string Nome { get; set; }
    public CodigoLoja Codigo { get; set; }
    public Endereco Endereco { get; set; }
    public TelefoneLoja Telefone { get; set; }
}
