using SistemaPagamento.Enums;

namespace SistemaPagamento.Models;

public class Boleto : Pagamento
{
    public override TimeSpan TempoProcessamento => TimeSpan.FromHours(48);

    public Boleto()
    {
        Nome = TipoPagamentoEnum.Boleto.ToString();
        Taxa = 0.01m;
    }
}
