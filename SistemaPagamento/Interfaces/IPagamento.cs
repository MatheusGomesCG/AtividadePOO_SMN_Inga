namespace SistemaPagamento.Interfaces;

public interface IPagamento
{
    string Nome { get; }
    TimeSpan TempoProcessamento { get; }
    decimal CalcularValorComTaxa(decimal valor);
    bool IsValid();
}
