using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using case1.Enum;

namespace case1.Model;

public class Conta

{
    private decimal _saldo;
    public string Titular { get; }
    public string CPF { get; }

    public List<Movimentacao> Movimentacoes { get; }

    public Conta(string titular, string cpf)
    {
        if (string.IsNullOrWhiteSpace(titular))
        {
            Console.WriteLine("Titular não pode ser vazio.");
            return;
        }
        if (!CPFValido(cpf))
        {
            Console.WriteLine("CPF inválido.");
            return;
        }
        Titular = titular;
        CPF = cpf;
        _saldo = 0;
        Movimentacoes = new List<Movimentacao>();
    }

    private bool CPFValido(string cpf)
    {
        string cpfNumero = @"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$";
        return Regex.IsMatch(cpf, cpfNumero);
    }


    public decimal Saldo()
    {
        return _saldo;
    }

    public void Depositar(decimal valor)
    {
        if (!PodeRealizar(TipoMovimentacao.Deposito, valor))
        {
            return;
        }
        _saldo += valor;
        Movimentacoes.Add(new Movimentacao(TipoMovimentacao.Deposito, valor, true));
        Console.WriteLine($"Depósito de {valor} realizado com sucesso.");
    }

    public void Sacar(decimal valor)
    {
        if (!PodeRealizar(TipoMovimentacao.Saque, valor))
        {
            return;
        }
        _saldo -= valor;
        Movimentacoes.Add(new Movimentacao(TipoMovimentacao.Saque, valor, true));
        Console.WriteLine($"Saque de {valor} realizado com sucesso.");
    }

    private bool PodeRealizar(TipoMovimentacao tipo, decimal valor)
    {
        if (tipo == TipoMovimentacao.Saque && valor > _saldo && valor > 0)
        {
            Console.WriteLine("Saldo insuficiente para realizar o saque.");
            Movimentacoes.Add(new Movimentacao(tipo, valor, false));
            return false;
        }
        if (tipo == TipoMovimentacao.Deposito && valor <= 0)
        {
            Console.WriteLine("Valor de depósito inválido.");
            Movimentacoes.Add(new Movimentacao(tipo, valor, false));
            return false;
        }
        return true;
    }
    public string ExibirExtrato()
    {
        var extrato = Movimentacoes.OrderByDescending(m => m.Valor).ToList();
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Extrato da Conta:");
        foreach (var movimentacao in extrato)
        {
            sb.AppendLine(movimentacao.ToString());
        }
        return sb.ToString();
    }

    public string ExtratoPorTipo()
    {
        var movimentacoesPorTipo = Movimentacoes
            .GroupBy(m => m.Tipo)
            .ToDictionary(g => g.Key, g => g.ToList());

        var sb = new StringBuilder();
        sb.AppendLine("Extrato agrupado");
        foreach (var tipo in movimentacoesPorTipo.Keys)
        {
            var tipoNome = tipo == TipoMovimentacao.Deposito ? "Depósitos" : "Saques";
            var somaTipo = movimentacoesPorTipo[tipo].Sum(m => m.Valor);
            sb.AppendLine($"\n{tipoNome} - Total: {somaTipo:C}");
            foreach (var movimentacao in movimentacoesPorTipo[tipo])
            {
                sb.AppendLine(movimentacao.ToString());
            }
        }


        return sb.ToString();
    }
}
