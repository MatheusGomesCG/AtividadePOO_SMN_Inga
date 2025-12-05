using case3.Enum;

namespace case3.Models;

public class CartaoCredito : Pagamento
{
    public override decimal Taxa => 0.025m;

    public override TimeSpan TempoProcessamento => TimeSpan.FromHours(24);

    public override TipoPagamentoEnum Tipo => TipoPagamentoEnum.CartaoCredito;
    public CartaoCredito(decimal valor) : base(valor)
    {
    }
}
