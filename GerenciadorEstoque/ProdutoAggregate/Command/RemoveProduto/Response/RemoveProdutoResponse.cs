namespace GerenciadorEstoque.Application.ProdutoAggregate.Command.RemoveProduto.Response;

public sealed record RemoveProdutoResponse
{
    public Guid Id { get; set; }
    public bool isDeleted { get; set; }
    public DateTime? DateDeleted { get; set; }
}
