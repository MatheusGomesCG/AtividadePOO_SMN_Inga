using case3.Enum;

namespace case3.Models;

public class Boleto(decimal valor) : Pagamento(valor)
{
    public override decimal Taxa => 0.01m;
    public override TimeSpan TempoProcessamento => TimeSpan.FromHours(48);
    public override TipoPagamentoEnum Tipo => TipoPagamentoEnum.Boleto;
}
