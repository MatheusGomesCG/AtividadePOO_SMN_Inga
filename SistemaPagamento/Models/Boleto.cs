using SistemaPagamento.Enums;

namespace SistemaPagamento.Models;

public class Boleto(decimal valorTotal) : Pagamento(valorTotal)
{
    public override decimal Taxa => 0.01m;
    public override TimeSpan TempoProcessamento => TimeSpan.FromHours(48);
    public override MetodoPagamentoEnum MetodoPagamento => MetodoPagamentoEnum.Boleto;
}
