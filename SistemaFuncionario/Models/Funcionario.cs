using System.Text;
using System.Text.RegularExpressions;
using SistemaFuncionario.Enums;

namespace SistemaFuncionario.Models;

public abstract class Funcionario(string nome, string cpf, DateTime dataAdmissao)
{
    public int Id { get; }
    public string Nome { get; } = nome;
    public string CPF { get; } = cpf;
    public abstract TipoFuncionarioEnum TipoFuncionario { get; }
    public abstract decimal TaxaBonus { get; }
    public decimal SalarioBase { get; } = 1518m;
    public DateTime DataAdmissao { get; } = dataAdmissao;
    public decimal TaxaInss { get; } = 0.08m;
    public List<Pagamento> Pagamentos { get; } = new();

    public bool IsValid()
    {
        if (string.IsNullOrWhiteSpace(Nome))
        {
            Console.WriteLine("O nome do funcionário não pode ser vazio.");
            return false;
        }

        if (!Regex.IsMatch(CPF, @"^(\d{3}\.){2}\d{3}-\d{2}$"))
        {
            Console.WriteLine("O CPF deve possuir um formato válido.");
            return false;
        }

        if (DataAdmissao > DateTime.Now)
        {
            Console.WriteLine("A data de admissão não pode ser no futuro.");
            return false;
        }

        return true;
    }

    public decimal CalcularSalarioLiquido() => SalarioBase + CalcularValorBonus() - CalcularDescontoInss();

    public decimal CalcularValorBonus() => SalarioBase * TaxaBonus;

    public decimal CalcularDescontoInss() => CalcularValorBonus() * TaxaInss;

    public void AdicionarPagamento(Pagamento pagamento) => Pagamentos.Add(pagamento);
}
