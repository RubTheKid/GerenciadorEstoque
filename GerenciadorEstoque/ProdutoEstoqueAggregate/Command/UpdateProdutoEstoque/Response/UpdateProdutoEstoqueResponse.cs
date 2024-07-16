namespace GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.UpdateProdutoEstoque.Response;

public sealed record UpdateProdutoEstoqueResponse
{
    public Guid ProdutoId { get; set; }
    public Guid LojaId { get; set; }
    public int Estoque { get; set; }
}
