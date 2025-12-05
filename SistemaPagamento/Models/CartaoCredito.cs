using SistemaPagamento.Enums;

namespace SistemaPagamento.Models;

public class CartaoCredito(decimal valorTotal) : Pagamento(valorTotal)
{
    public override decimal Taxa => 0.025m;
    public override TimeSpan TempoProcessamento => TimeSpan.FromHours(24);
    public override MetodoPagamentoEnum MetodoPagamento => MetodoPagamentoEnum.CartaoCredito;
}
