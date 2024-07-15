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

    public Loja(string nome, Endereco endereco, CodigoLoja codigo, TelefoneLoja telefone)
    {
        Nome = !string.IsNullOrWhiteSpace(nome) ? nome : throw new ArgumentException("Nome é obrigatório.");
        Endereco = endereco ?? throw new ArgumentNullException(nameof(endereco));
        Codigo = codigo ?? throw new ArgumentNullException(nameof(codigo));
        Telefone = telefone ?? throw new ArgumentNullException(nameof(telefone));
    }

    public void AlterarNome(string novoNome)
    {
        Nome = !string.IsNullOrWhiteSpace(novoNome) ? novoNome : throw new ArgumentException("Nome é obrigatório.");
    }

    public void AlterarEndereco(Endereco novoEndereco)
    {
        Endereco = novoEndereco ?? throw new ArgumentNullException(nameof(novoEndereco));
    }

    public void AlterarCodigo(CodigoLoja novoCodigo)
    {
        Codigo = novoCodigo ?? throw new ArgumentNullException(nameof(novoCodigo));
    }

    public void AlterarTelefone(TelefoneLoja novoTelefone)
    {
        Telefone = novoTelefone ?? throw new ArgumentNullException(nameof(novoTelefone));
    }

}