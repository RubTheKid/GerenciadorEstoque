using System.Text.RegularExpressions;

namespace GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;

public class Endereco
{


    public string Logradouro { get; set; }
    public string EnderecoNumero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Cep { get; set; }

    public Endereco(string logradouro, string enderecoNumero, string complemento, string bairro, string cidade, string estado, string cep)
    {
        Logradouro = logradouro;
        EnderecoNumero = enderecoNumero;
        Complemento = complemento;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
        Cep = cep;


        ValidarCep();
    }

    public void ValidarCep()
    {
        if (!Regex.IsMatch(Cep, @"^\d{5}-\d{3}$") || Cep.Replace("-", "").Length != 8)
        {
            throw new ArgumentException("CEP Inválido");
        }
    }
}
