using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using case1.Enum;

namespace case1.Model;

public class Conta

{
    public int Id { get; }
    public int NumerConta { get; }
    public decimal Saldo { get; private set; }
    public string Titular { get; }
    public string CPF { get; }

    public List<Movimentacao> Movimentacoes { get; }

    public Conta(int id, int numeroConta, string titular, string cpf)
    {
        Id = id;
        NumerConta = numeroConta;
        Titular = titular;
        CPF = cpf;
        Saldo = 0;
        Movimentacoes = new List<Movimentacao>();
    }

    public bool isValido()
    {
        if (string.IsNullOrWhiteSpace(Titular))
        {
            Console.WriteLine("Titular não pode ser vazio.");
            return false;
        }
        if (!CPFValido(CPF))
        {
            Console.WriteLine("CPF inválido.");
            return false;
        }
        return true;
    }

    private bool CPFValido(string cpf)
    {
        string cpfNumero = @"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$";
        return Regex.IsMatch(cpf, cpfNumero);
    }


    public decimal ExibirSaldo()
    {
        return Saldo;
    }

    public void Depositar(decimal valor)
    {
        var sucesso = PodeRealizar(TipoMovimentacao.Deposito, valor);
        Movimentacoes.Add(new Movimentacao(NumerConta, TipoMovimentacao.Deposito, valor, sucesso));
        if (!sucesso)
            return;

        Saldo += valor;
        Console.WriteLine($"Depósito de {valor} realizado com sucesso.");
    }

    public void Sacar(decimal valor)
    {
        var sucesso = PodeRealizar(TipoMovimentacao.Saque, valor);
        Movimentacoes.Add(new Movimentacao(NumerConta, TipoMovimentacao.Saque, valor, sucesso));
        if (!sucesso)
            return;

        Saldo -= valor;
        Console.WriteLine($"Saque de {valor} realizado com sucesso.");
    }

    private bool PodeRealizar(TipoMovimentacao tipo, decimal valor)
    {
        if (tipo == TipoMovimentacao.Saque && valor > Saldo && valor > 0)
        {
            Console.WriteLine("Saldo insuficiente para realizar o saque.");
            return false;
        }
        if (tipo == TipoMovimentacao.Deposito && valor <= 0)
        {
            Console.WriteLine("Valor de depósito inválido.");
            return false;
        }
        return true;
    }
    public string ExibirExtrato()
    {
        if (!Movimentacoes.Any())
            return "Nenhuma movimentação realizada.";

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
        if (!Movimentacoes.Any())
            return "Nenhuma movimentação realizada.";

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
