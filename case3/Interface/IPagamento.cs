using case3.Enum;

namespace case3.Interface;

public interface IPagamento
{
    decimal Taxa { get; }
    TimeSpan TempoProcessamento { get; }
    TipoPagamentoEnum Tipo { get; }
    decimal Valor { get; }
    decimal CalcularValorComTaxa(decimal valor);
}
