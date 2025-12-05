namespace SistemaPagamento.Models;

using SistemaPagamento.Interfaces;

public class Pedido(string numeroPedido, decimal valorOriginal)
{
    public string NumeroPedido { get; } = numeroPedido;
    public decimal ValorOriginal { get; } = valorOriginal;
    public IPagamento MetodoPagamento { get; set; }

    public void FinalizarPagamento()
    {
        if (MetodoPagamento == null)
            return;

        decimal valorComTaxas = MetodoPagamento.CalcularValorComTaxa(ValorOriginal);
        TimeSpan tempo = MetodoPagamento.TempoProcessamento;

        Console.WriteLine($"\n   FINALIZAÇÃO DO PEDIDO ");
        Console.WriteLine($"Pedido: {NumeroPedido}");
        Console.WriteLine($"Valor Original: R$ {ValorOriginal:F2}");
        Console.WriteLine($"Valor Final: R$ {valorComTaxas:F2}");
        Console.WriteLine($"Método: {MetodoPagamento.Nome}");
        Console.WriteLine($"Tempo de Processamento: {FormatarTempo(tempo)}");
        Console.WriteLine($"Status: Concluída");
    }

    private static string FormatarTempo(TimeSpan tempo)
    {
        if (tempo.TotalSeconds < 60)
            return $"{(int)tempo.TotalSeconds} segundos";
        if (tempo.TotalMinutes < 60)
            return $"{(int)tempo.TotalMinutes} minuto(s)";
        if (tempo.TotalHours < 24)
            return $"{(int)tempo.TotalHours} hora(s)";
        return $"{(int)tempo.TotalDays} dia(s)";
    }
}
