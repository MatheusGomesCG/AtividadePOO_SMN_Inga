using case3.Enum;

namespace case3.Models;

public class PIX(decimal valor) : Pagamento(valor)
{
    public override decimal Taxa => -0.005m;
    public override TimeSpan TempoProcessamento => TimeSpan.FromSeconds(10);
    public override TipoPagamentoEnum Tipo => TipoPagamentoEnum.Pix;
}
