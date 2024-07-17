namespace GerenciadorEstoque.Presentation.Models;

public class LojaViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public CodigoViewModel Codigo { get; set; }
    public EnderecoViewModel Endereco { get; set; }
    public TelefoneViewModel Telefone { get; set; }
}


public class CodigoViewModel
{
    public string Codigo { get; set; }
}

public class TelefoneViewModel
{
    public string Numero { get; set; }
    public string CodigoArea { get; set; }
    public string Telefone { get; set; }
}

public class EnderecoViewModel
{
    public string Logradouro { get; set; }
    public string EnderecoNumero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Cep { get; set; }
}