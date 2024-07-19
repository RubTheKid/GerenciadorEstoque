using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;

namespace GerenciadorEstoque.Domain.Aggregates.VendaProdutoAggregate;

public class VendaProduto
{
    public Guid VendaId { get; private set; }
    public Guid ProdutoId { get; private set; }
    public Produto Produto { get; private set; }
    public int Quantidade { get; private set; }

    private VendaProduto() { }

    public VendaProduto(Guid vendaId, Guid produtoId, Produto produto, int quantidade)
    {
        VendaId = vendaId;
        ProdutoId = produtoId;
        Produto = produto;
        Quantidade = quantidade;
    }
}
