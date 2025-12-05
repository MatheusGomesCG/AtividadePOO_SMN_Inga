using case3.Enum;

namespace case3.Models;

public class Boleto : Pagamento
{
    public override decimal Taxa => 0.01m;

    public override TimeSpan TempoProcessamento => TimeSpan.FromHours(48);

    public override TipoPagamentoEnum Tipo => TipoPagamentoEnum.Boleto;
    public Boleto(decimal valor) : base(valor)
    {
    }
}