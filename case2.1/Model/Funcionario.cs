using System;
using System.Text;
using System.Text.RegularExpressions;
using case2._1.Enum;
using Internal;

namespace case2._1.Model;

public abstract class Funcionario
{
    public int Id { get; }
    public string Nome { get; }
    public string CPF { get; }
    public decimal SalarioBase { get; } = 1518.00m;
    public abstract TipoFuncionario Tipo { get; }
    public DateTime DataAdmissao { get; }
    public abstract decimal TaxaBonus { get; }
    public decimal TaxaInss { get; } = 0.08m;

    public List<Pagamento> Pagamentos { get; } = new List<Pagamento>();

    public Funcionario(int id, string nome, string cpf, DateTime dataAdmissao)
    {
        Id = id;
        Nome = nome;
        CPF = cpf;
        DataAdmissao = dataAdmissao;
    }

    public List<string> IsValid()
    {
        var erros = new List<string>();
        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("Nome não pode ser vazio.");
        if (!Regex.IsMatch(CPF, @"^(\d{3}\.?){2}.?\d{3}-?\d{2}$"))
            erros.Add("CPF inválido.");
        if (DataAdmissao > DateTime.Now)
            erros.Add("Data de admissão não pode ser no futuro.");
        return erros;
    }

    public decimal CalcularBonus() => SalarioBase * TaxaBonus;

    public decimal CalcularSalarioLiquido()
    {
        decimal bonus = CalcularBonus();
        if (bonus < 0)
        {
            Console.WriteLine("Bonus nao pode ser negativo.");
            return;
        }
        decimal salarioLiquido = CalcularSalarioBruto() - CalcularDescontoINSS();
        return salarioLiquido;
    }

    public decimal CalcularDescontoINSS() => CalcularSalarioBruto() * TaxaInss;

    public decimal CalcularSalarioBruto() => SalarioBase + CalcularBonus();

}
