namespace SistemaPagamento.Models;

using SistemaPagamento.Enums;

public class CartaoCredito : Pagamento
{
    public override TimeSpan TempoProcessamento => TimeSpan.FromHours(24);

    public CartaoCredito()
    {
        Nome = TipoPagamentoEnum.Credito.ToString();
        Taxa = 0.025m;
    }
}
