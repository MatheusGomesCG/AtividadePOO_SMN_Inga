using System.Text;
using SistemaPagamento.Enums;
using SistemaPagamento.Interfaces;

namespace SistemaPagamento.Models;

public abstract class Pagamento(decimal valorTotal) : IPagamento
{
    public abstract decimal Taxa { get; }
    public abstract TimeSpan TempoProcessamento { get; }
    public abstract MetodoPagamentoEnum MetodoPagamento { get; }
    public decimal ValorTotal { get; } = valorTotal;
    public PagamentoStatusEnum Status { get; private set; } = PagamentoStatusEnum.Pendente;

    public decimal CalcularValorComTaxa() => ValorTotal + (ValorTotal * Taxa);

    public void FinalizarPagamento()
    {
        Status = PagamentoStatusEnum.Finalizado;
        StringBuilder sb = new();
        sb.AppendLine("Extrato do Pagamento:");
        sb.AppendLine($"- Método de Pagamento: {MetodoPagamento}");
        sb.AppendLine($"- Valor Final: {CalcularValorComTaxa():C2}");
        sb.AppendLine($"- Tempo de Processamento: {TempoFormatado()}");
        sb.AppendLine($"- Status do Pagamento: {Status}");
        Console.WriteLine(sb.ToString());
    }

    private string TempoFormatado()
    {
        return TempoProcessamento.TotalHours >= 24 
            ? $"{TempoProcessamento.Days} dia(s) {TempoProcessamento.Hours:D2}:{TempoProcessamento.Minutes:D2}:{TempoProcessamento.Seconds:D2}"
            : $"{TempoProcessamento.Hours:D2}:{TempoProcessamento.Minutes:D2}:{TempoProcessamento.Seconds:D2}";
    }
}
