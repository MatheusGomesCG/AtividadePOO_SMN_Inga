using System.Text;
using case3.Enum;
using case3.Interface;

namespace case3.Models;

public abstract class Pagamento : IPagamento
{
    public abstract decimal Taxa { get; }
    public abstract TimeSpan TempoProcessamento { get; }
    public abstract TipoPagamentoEnum Tipo { get; }
    public PagamentoStatusEnum Status { get; private set; } = PagamentoStatusEnum.Pendente;
    public decimal Valor { get; }

    public Pagamento(decimal valor)
    {
        Valor = valor;
    }
    public decimal CalcularValorComTaxa(decimal valor) => valor + (valor * Taxa);

    public void FinalizarPagamento() => Status = PagamentoStatusEnum.Finalizado;

    public string RelatorioFinalizacao()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Pagamento finalizado com sucesso!");
        sb.AppendLine($"Tipo de Pagamento: {Tipo}");
        sb.AppendLine($"Valor Original: {Valor:C}");
        sb.AppendLine($"Taxa Aplicada: {Taxa:P2}");
        sb.AppendLine($"Valor com Taxa: {CalcularValorComTaxa(Valor):C}");
        sb.AppendLine($"Tempo de Processamento: {TempoProcessamentoString()}");
        return sb.ToString();
    }

    private string TempoProcessamentoString()
    {
        return TempoProcessamento.TotalHours >= 24
            ? $"{TempoProcessamento.Days} dias {TempoProcessamento.Hours}:{TempoProcessamento.Minutes}:{TempoProcessamento.Seconds}"
            : $"{TempoProcessamento.Hours}:{TempoProcessamento.Minutes}:{TempoProcessamento.Seconds}";
    }
}
