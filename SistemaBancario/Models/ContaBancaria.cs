using System.Text;
using SistemaBancario.Enum;

namespace SistemaBancario.Models;

public class ContaBancaria
{
    public int Id { get; }
    public int NumeroConta { get; }
    public decimal Saldo { get; private set; }
    public Titular Titular { get; }
    public List<HistoricoConta> Historico { get; } = new List<HistoricoConta>();

    public ContaBancaria(int id, int numeroConta, Titular titular)
    {
        Id = id;
        NumeroConta = numeroConta;
        Titular = titular;
        Saldo = 0;
    }

    public void Depositar(decimal valor)
    {
        var movimentacao = TipoMovimentacaoEnum.Deposito;
        var sucesso = !VerificarValorNegativo(valor);
        Historico.Add(new HistoricoConta(Id, movimentacao, valor, sucesso));

        if (VerificarValorNegativo(valor))
        {
            Console.WriteLine($"O Valor: {valor:C} é inválido para depósito.");
            return;
        }

        Saldo += valor;
    }

    public void Sacar(decimal valor)
    {
        var movimentacao = TipoMovimentacaoEnum.Saque;
        var sucesso = !VerificarValorNegativo(valor) && !VerificarValorMaiorQueSaldo(valor);
        Historico.Add(new HistoricoConta(Id, movimentacao, valor, sucesso));

        if (VerificarValorNegativo(valor))
        {
            Console.WriteLine($"O Valor: {valor:C} é inválido para saque.");
            return;
        }

        if (VerificarValorMaiorQueSaldo(valor))
        {
            Console.WriteLine($"O Valor: {valor:C} é maior que o saldo disponível: {Saldo:C}.");
            return;
        }
        
        Saldo -= valor;
    }

    public void ExtratoHistorico()
    {
        StringBuilder sb = new();
        sb.AppendLine($"Extrato Completo do cliente: {Titular.Nome}");

        if(!Historico.Any())
            sb.AppendLine("Não existe movimentação na conta bancária");
        else
        {
            var historicosOrdenados = Historico.ToList();
            foreach(var historico in OrdenarPorValorDecrescente(historicosOrdenados))
            {
                var sucesso = historico.Sucesso ? "Sim" : "Não";
                sb.AppendLine($"Tipo: {historico.TipoMovimentacao}");
                sb.AppendLine($"Valor: {historico.Valor:C}");
                sb.AppendLine($"Sucesso: {sucesso}\n");
            }
        }

        Console.WriteLine(sb.ToString());
    }

    public void ExtratoAgrupado()
    {
        StringBuilder sb = new();
        sb.AppendLine($"Extrato Consolidado do cliente: {Titular.Nome}");

        if(!Historico.Any())
            sb.AppendLine("Não existe movimentação na conta bancária");
        else
        {
            var historicoConsolidado = AgruparHistoricoConsolidado(Historico.ToList());
            foreach(var historico in historicoConsolidado)
            {
                sb.AppendLine($"Tipo: {historico.TipoMovimentacao}");
                sb.AppendLine($"Valor Total: {historico.Valor:C}");
                sb.AppendLine();
            }
        }

        Console.WriteLine(sb.ToString());
    }

    private List<HistoricoConta> AgruparHistoricoConsolidado(List<HistoricoConta> historicoContas)
    {
        return historicoContas
            .Where(h => h.Sucesso)
            .GroupBy(h => h.TipoMovimentacao)
            .Select(g => new HistoricoConta(
                g.First().IdContaBancaria,
                g.Key,
                g.Sum(h => h.Valor),
                true))
            .ToList();
    }

    private List<HistoricoConta> OrdenarPorValorDecrescente(List<HistoricoConta> historicoContas) => historicoContas.OrderByDescending(h => h.Valor).ToList();
    private bool VerificarValorNegativo(decimal valor) => valor < 0;
    private bool VerificarValorMaiorQueSaldo(decimal valor) => valor > Saldo;
}
