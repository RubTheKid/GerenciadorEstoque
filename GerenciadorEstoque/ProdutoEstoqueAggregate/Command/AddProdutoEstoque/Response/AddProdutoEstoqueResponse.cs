namespace GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.AddProdutoEstoque.Response;

public sealed record AddProdutoEstoqueResponse
{
    public Guid Id { get; set; }
    public Guid ProdutoId { get; set; }
    public Guid LojaId { get; set; }
    public int Estoque { get; set; }
}
