using case3.Enum;

namespace case3.Models;

public class Transferencia : Pagamento
{
    public override decimal Taxa => 0m;

    public override TimeSpan TempoProcessamento => TimeSpan.FromHours(1);

    public override TipoPagamentoEnum Tipo => TipoPagamentoEnum.Transferencia;
    
    public Transferencia(decimal valor) : base(valor)
    {
    }
}
