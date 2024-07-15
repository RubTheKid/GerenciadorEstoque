using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Validations;
using GerenciadorEstoque.Domain.Core;

namespace GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;

public class Produto : BaseEntity
{
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public string Gtin { get; private set; }
    public Preco Preco { get; private set; }
    public int EstoqueMinimo { get; private set; }

    private Produto() { }

    public Produto(string nome, string descricao, string gtin, Preco preco, int estoqueMinimo)
    {
        Nome = nome ?? throw new ArgumentNullException(nameof(nome));
        Descricao = descricao;
        Gtin = gtin;
        Preco = preco;
        EstoqueMinimo = estoqueMinimo;
    }

    public void AlterarPreco(decimal novoValor)
    {
        Preco = Preco.AlterarPreco(novoValor);
    }

}
