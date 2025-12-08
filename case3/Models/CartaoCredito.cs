using case3.Enum;

namespace case3.Models;

public class CartaoCredito(decimal valor) : Pagamento(valor)
{
    public override decimal Taxa => 0.025m;
    public override TimeSpan TempoProcessamento => TimeSpan.FromHours(24);
    public override TipoPagamentoEnum Tipo => TipoPagamentoEnum.CartaoCredito;
}
