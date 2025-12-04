using SistemaBancario.Enums;

namespace SistemaBancario.Models;

public class Conta(string titular, string cpf, decimal saldoInicial = 0)
{
    public string Titular { get; } = titular;
    public decimal Saldo { get; private set; } = saldoInicial;
    public string Cpf { get; } = cpf;

    protected List<Operacao> Historico = [];

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do depósito deve ser maior que zero.");
            Historico.Add(new Operacao(TipoOperacaoEnum.Deposito, valor, false));
            return;
        }

        Historico.Add(new Operacao(TipoOperacaoEnum.Deposito, valor, true));
        Saldo += valor;

        Console.WriteLine($"Depósito de {valor} realizado. Saldo atual: {Saldo:C}");
    }

    public void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do saque deve ser maior que zero.");
            Historico.Add(new Operacao(TipoOperacaoEnum.Saque, valor, false));
            return;
        }

        if (valor > Saldo)
        {
            Console.WriteLine("O valor do saque é maior que o saldo disponível.");
            Historico.Add(new Operacao(TipoOperacaoEnum.Saque, valor, false));
            return;
        }

        Historico.Add(new Operacao(TipoOperacaoEnum.Saque, valor, true));
        Saldo -= valor;

        Console.WriteLine($"Saque de {valor} realizado. Saldo atual: {Saldo:C}");
    }

    public List<string> IsValid()
    {
        var erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Titular))
            erros.Add("O titular não pode ser vazio.");

        if (string.IsNullOrWhiteSpace(Cpf) || Cpf.Length != 11)
            erros.Add("O CPF não pode ser vazio e precisa conter 11 caracteres.");

        if (Saldo < 0)
            erros.Add("O saldo inicial não pode ser negativo.");

        return erros;
    }

    public void ExibirHistorico()
    {
        foreach (var operacao in Historico)
            Console.WriteLine(operacao);
    }

    public void ExibirExtratoOrdenado()
    {
        Console.WriteLine("  Extrato Bancário ");
        var operacoesSucesso = Historico.Where(o => o.Sucesso)
                                        .OrderByDescending(o => o.Valor);

        foreach (var operacao in operacoesSucesso)
            Console.WriteLine($"Tipo: {operacao.Tipo}, Valor: {operacao.Valor:C}");
    }

    public void ExibirExtratoConsolidado()
    {
        Console.WriteLine("  Extrato Consolidado ");
        var operacoesConsolidadas = Historico.Where(o => o.Sucesso)
                                        .GroupBy(o => o.Tipo)
                                        .Select(g => new
                                        {
                                            Tipo = g.Key,
                                            ValorTotal = g.Sum(o => o.Valor)
                                        });

        foreach (var operacao in operacoesConsolidadas)
            Console.WriteLine($"Tipo: {operacao.Tipo}, Valor Total: {operacao.ValorTotal:C}");

    }
}
