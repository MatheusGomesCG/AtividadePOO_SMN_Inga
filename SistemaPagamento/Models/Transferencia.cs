using SistemaPagamento.Enums;

namespace SistemaPagamento.Models;

public class Transferencia : Pagamento
{
    public override TimeSpan TempoProcessamento => TimeSpan.FromMinutes(60);

    public Transferencia()
    {
        Nome = TipoPagamentoEnum.Transferencia.ToString();
        Taxa = 0.0m;
    }

    public override decimal CalcularValorComTaxa(decimal valor) => valor;
}
