using SistemaPagamento.Enums;

namespace SistemaPagamento.Models;

public class Pix(decimal valorTotal) : Pagamento(valorTotal)
{
    public override decimal Taxa => -0.005m;
    public override TimeSpan TempoProcessamento => TimeSpan.FromSeconds(10);
    public override MetodoPagamentoEnum MetodoPagamento => MetodoPagamentoEnum.Pix;
}
