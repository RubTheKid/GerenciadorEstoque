namespace GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Query.GetProdutoEstoque.Response;

public sealed record ProdutoEstoqueResponse
{
    public Guid ProdutoId { get; set; }
    public Guid LojaId { get; set; }
    public int Estoque { get; set; }
    public string ProdutoNome { get; set; }
    public string LojaNome { get; set; }
}
