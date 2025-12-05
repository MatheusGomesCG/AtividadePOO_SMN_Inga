using SistemaPagamento.Enums;

namespace SistemaPagamento.Models;

public class Pix : Pagamento
{
    public override TimeSpan TempoProcessamento => TimeSpan.FromSeconds(10);

    public Pix()
    {
        Nome = TipoPagamentoEnum.Pix.ToString();
        Taxa = -0.005m;
    }
}
