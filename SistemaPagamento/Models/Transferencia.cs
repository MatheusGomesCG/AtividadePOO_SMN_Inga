using SistemaPagamento.Enums;

namespace SistemaPagamento.Models;

public class Transferencia(decimal valorTotal) : Pagamento(valorTotal)
{
    public override decimal Taxa => 0;
    public override TimeSpan TempoProcessamento => TimeSpan.FromHours(1);
    public override MetodoPagamentoEnum MetodoPagamento => MetodoPagamentoEnum.Transferencia;
}
