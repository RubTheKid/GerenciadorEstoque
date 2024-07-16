using GerenciadorEstoque.Domain.Aggregates.LojaAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;

namespace GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate;

public class ProdutoEstoque
{
    public Guid LojaId { get; private set; }
    public Guid ProdutoId { get; private set; }
    public Produto Produto { get; private set; }
    public Loja Loja { get; private set; }
    public int Estoque { get; private set; }

    private ProdutoEstoque() { }

    public ProdutoEstoque(Produto produto, Loja loja, int estoque)
    {
        Produto = produto ?? throw new ArgumentNullException(nameof(produto));
        Loja = loja ?? throw new ArgumentNullException(nameof(loja));
        ProdutoId = produto.Id;
        LojaId = loja.Id;
        Estoque = estoque >= 0 && estoque <= 9999999 ? estoque : throw new ArgumentException("O estoque deve ser no mínimo 0 e no máximo 9.999.999.");
    }

    public void AlterarQuantidade(int novoEstoque)
    {
        if (novoEstoque < 0 || novoEstoque > 9999999)
        {
            throw new ArgumentException("O estoque deve estar entre 0 e 9.999.999.");
        }
        Estoque = novoEstoque;
    }
}
