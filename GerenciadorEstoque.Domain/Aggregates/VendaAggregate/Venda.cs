using GerenciadorEstoque.Domain.Aggregates.LojaAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;
using GerenciadorEstoque.Domain.Aggregates.VendaProdutoAggregate;
using GerenciadorEstoque.Domain.Core;

namespace GerenciadorEstoque.Domain.Aggregates.VendaAggregate;

public class Venda : BaseEntity
{
    public Guid LojaId { get; private set; }
    public Loja Loja { get; private set; }
    public int Codigo { get; private set; }
    public DateTime DataVenda { get; private set; }

    private readonly List<VendaProduto> _vendaProdutos;
    public IReadOnlyCollection<VendaProduto> VendaProdutos => _vendaProdutos;

    private Venda()
    {
        _vendaProdutos = new List<VendaProduto>();
    }

    public Venda(Guid lojaId, Loja loja, int codigo)
    {
        LojaId = lojaId;
        Loja = loja ?? throw new ArgumentNullException(nameof(loja));
        DataVenda = DateTime.UtcNow;
        Codigo = codigo;
        _vendaProdutos = new List<VendaProduto>();
    }

    public void AdicionarProduto(Guid produtoId, Produto produto, int quantidade)
    {
        var vendaProduto = new VendaProduto(Id, produtoId, produto, quantidade);
        _vendaProdutos.Add(vendaProduto);
    }
}