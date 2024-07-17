using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;
using GerenciadorEstoque.Domain.Core;

namespace GerenciadorEstoque.Domain.Aggregates.LojaAggregate;

public class Loja : BaseEntity
{

    public string Nome { get; private set; }
    public CodigoLoja Codigo { get; private set; }
    public Endereco Endereco { get; private set; }
    public TelefoneLoja Telefone { get; private set; }

    private Loja() { }


    public Loja(string nome, CodigoLoja codigo, Endereco endereco, TelefoneLoja telefone)
    {
        Nome = nome;
        Codigo = codigo;
        Endereco = endereco;
        Telefone = telefone;
    }

    public void AtualizarLoja(string nome, CodigoLoja codigo, Endereco endereco, TelefoneLoja telefone)
    {
        Nome = nome;
        Codigo = codigo;
        Endereco = endereco;
        Telefone = telefone;
    }
}