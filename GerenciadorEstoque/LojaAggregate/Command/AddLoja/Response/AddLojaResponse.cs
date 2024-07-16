using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;

namespace GerenciadorEstoque.Application.LojaAggregate.Command.AddLoja.Response;

public sealed record AddLojaResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public CodigoLoja Codigo { get; set; }
    public Endereco Endereco { get; set; }
    public TelefoneLoja Telefone { get; set; }
}
