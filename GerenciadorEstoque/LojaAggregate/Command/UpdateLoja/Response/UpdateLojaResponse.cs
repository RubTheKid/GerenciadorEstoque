using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;

namespace GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja.Response;

public sealed record UpdateLojaResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public CodigoLoja Codigo { get; set; }
    public Endereco Endereco { get; set; }
    public TelefoneLoja Telefone { get; set; }
}
