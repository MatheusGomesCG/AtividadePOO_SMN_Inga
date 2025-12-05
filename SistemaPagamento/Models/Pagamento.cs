namespace SistemaPagamento.Models;

using SistemaPagamento.Interfaces;

public class Pagamento : IPagamento
{
    public string Nome { get; protected set; }
    public decimal Taxa { get; set; }

    public virtual TimeSpan TempoProcessamento => TimeSpan.Zero;

    public virtual decimal CalcularValorComTaxa(decimal valor) => valor + (valor * Taxa);

    public virtual bool IsValid()
    {
        if (string.IsNullOrWhiteSpace(Nome))
        {
            Console.WriteLine("Nome do pagamento não pode ser vazio.");
            return false;
        }
        if (Taxa < 0)
        {
            Console.WriteLine("Taxa do pagamento não pode ser negativa.");
            return false;
        }
        return true;
    }
}
