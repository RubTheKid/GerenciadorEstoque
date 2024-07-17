namespace GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;

public class TelefoneLoja
{

    public string CodigoArea { get; set; }
    public string Numero { get; set; }

    public string Telefone => CodigoArea + string.Empty + Numero;


    private TelefoneLoja() { }

    public TelefoneLoja(string codigoArea, string numero)
    {
        CodigoArea = codigoArea;
        Numero = numero;
        Validar();
    }

    public void Validar()
    {
        if (CodigoArea.Length != 2 || !int.TryParse(CodigoArea, out _))
        {
            throw new ArgumentException("Código de área inválido.");
        }
        if ((Numero.Length != 8 && Numero.Length != 9) || !int.TryParse(Numero, out _))
        {
            throw new ArgumentException("Número de telefone inválido.");
        }
    }

}
