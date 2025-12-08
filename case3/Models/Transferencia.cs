using case3.Enum;

namespace case3.Models;

public class Transferencia(decimal valor) : Pagamento(valor)
{
    public override decimal Taxa => 0m;
    public override TimeSpan TempoProcessamento => TimeSpan.FromHours(1);
    public override TipoPagamentoEnum Tipo => TipoPagamentoEnum.Transferencia;
}
