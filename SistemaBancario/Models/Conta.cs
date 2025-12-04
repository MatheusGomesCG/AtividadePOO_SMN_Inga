using SistemaBancario.Enums;

namespace SistemaBancario.Models;

public class Conta(string titular, string cpf)
{
    public string Titular { get; } = titular;
    public decimal Saldo { get; private set; } = 0;
    public string Cpf { get; } = cpf;

    protected List<Operacao> Historico = [];

    public void Depositar(decimal valor)
    {
        if (!ValidarOperacao(valor, TipoOperacaoEnum.Deposito))
            return;

        Historico.Add(new Operacao(TipoOperacaoEnum.Deposito, valor, true));
        Saldo += valor;

        Console.WriteLine($"Depósito de {valor:C} realizado. Saldo atual: {Saldo:C}");
    }


    public void Sacar(decimal valor)
    {
        if (!ValidarOperacao(valor, TipoOperacaoEnum.Saque))
            return;

        Historico.Add(new Operacao(TipoOperacaoEnum.Saque, valor, true));
        Saldo -= valor;

        Console.WriteLine($"Saque de {valor:C} realizado. Saldo atual: {Saldo:C}");
    }

    public List<string> IsValid()
    {
        var erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Titular))
            erros.Add("O titular não pode ser vazio.");

        if (string.IsNullOrWhiteSpace(Cpf) || Cpf.Length != 11)
            erros.Add("O CPF não pode ser vazio e precisa conter 11 caracteres.");

        return erros;
    }

    public void ExibirHistorico()
    {
        if (Historico.Count == 0)
        {
            Console.WriteLine("Nenhuma operação encontrada no histórico.");
            return;
        }

        foreach (var operacao in Historico)
            Console.WriteLine(operacao.ToString());
    }


    public void ExibirExtratoOrdenado()
    {
        Console.WriteLine("  Extrato Bancário ");

        var operacoesSucesso = Historico
            .Where(o => o.Sucesso)
            .OrderByDescending(o => o.Valor)
            .ToList();

        if (operacoesSucesso.Count == 0)
        {
            Console.WriteLine("Nenhuma operação realizada com sucesso.");
            return;
        }

        foreach (var operacao in operacoesSucesso)
            Console.WriteLine($"Tipo: {operacao.Tipo}, Valor: {operacao.Valor:C}");
    }


    public void ExibirExtratoConsolidado()
    {
        Console.WriteLine("  Extrato Consolidado ");

        var operacoesConsolidadas = Historico
            .Where(o => o.Sucesso)
            .GroupBy(o => o.Tipo)
            .Select(g => new
            {
                Tipo = g.Key,
                ValorTotal = g.Sum(o => o.Valor)
            })
            .ToList();

        if (operacoesConsolidadas.Count == 0)
        {
            Console.WriteLine("Nenhuma operação consolidada disponível.");
            return;
        }

        foreach (var operacao in operacoesConsolidadas)
            Console.WriteLine($"Tipo: {operacao.Tipo}, Valor Total: {operacao.ValorTotal:C}");
    }
    private bool ValidarOperacao(decimal valor, TipoOperacaoEnum tipo)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor da operação deve ser maior que zero.");
            Historico.Add(new Operacao(tipo, valor, false));
            return false;
        }

        if (tipo == TipoOperacaoEnum.Saque && valor > Saldo)
        {
            Console.WriteLine("O valor do saque é maior que o saldo disponível.");
            Historico.Add(new Operacao(tipo, valor, false));
            return false;
        }

        return true;
    }

}
