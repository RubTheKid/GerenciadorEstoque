namespace GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Validations;

public class Preco
{
    public decimal Valor { get; private set; }

    public Preco(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O valor do produto deve ser maior que zero.");
        }

        Valor = valor;
    }

    public Preco AlterarPreco(decimal novoValor)
    {
        if (novoValor <= 0)
        {
            throw new ArgumentException("O valor do produto deve ser maior que zero.");
        }
        return new Preco(novoValor);
    }
}
