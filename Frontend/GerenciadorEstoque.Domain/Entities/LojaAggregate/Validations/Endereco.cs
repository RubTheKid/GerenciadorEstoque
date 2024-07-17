using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GerenciadorEstoque.Domain.Entities.LojaAggregate.Validations;

public class Endereco
{
    public string Logradouro { get; private set; }
    public string EnderecoNumero { get; private set; }
    public string Complemento { get; private set; }
    public string Bairro { get; private set; }
    public string Cidade { get; private set; }
    public string Estado { get; private set; }
    public string Cep { get; private set; }

    public Endereco(string logradouro, string enderecoNumero, string complemento, string bairro, string cidade, string estado, string cep)
    {
        Logradouro = !string.IsNullOrWhiteSpace(logradouro) ? logradouro : throw new ArgumentException("Rua é obrigatória.");
        EnderecoNumero = !string.IsNullOrWhiteSpace(enderecoNumero) ? enderecoNumero : throw new ArgumentException("Número é obrigatório.");
        Complemento = complemento;
        Bairro = !string.IsNullOrWhiteSpace(bairro) ? bairro : throw new ArgumentException("Bairro é obrigatório.");
        Cidade = !string.IsNullOrWhiteSpace(cidade) ? cidade : throw new ArgumentException("Cidade é obrigatória.");
        Estado = !string.IsNullOrWhiteSpace(estado) ? estado : throw new ArgumentException("Estado é obrigatório.");
        Cep = !string.IsNullOrWhiteSpace(cep) ? cep : throw new ArgumentException("CEP é obrigatório.");


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
