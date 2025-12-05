using System;
using System.Text;
using System.Text.RegularExpressions;
using case2._1.Enum;

namespace case2._1.Model;

public abstract class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; }
    public string CPF { get; }
    public decimal SalarioBase { get; } = 1518.00m;
    public abstract TipoFuncionario Tipo { get; }
    public DateTime DataAdmissao { get; }
    public abstract decimal TaxaBonus { get;  }
    public decimal TaxaInss { get; } = 0.08m;

    public List<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();

    public Funcionario(int id, string nome, string cpf, DateTime dataAdmissao)
    {
        Id = id;
        Nome = nome;
        CPF = cpf;
        DataAdmissao = dataAdmissao;
    }

    public bool IsValid()
    {
        if (string.IsNullOrWhiteSpace(Nome))
        {
            Console.WriteLine("Nome não pode ser vazio.");
            return false;
        }
        if (!CPFValido(CPF))
        {
            Console.WriteLine("CPF inválido.");
            return false;
        }
        if (DataAdmissao > DateTime.Now)
        {
            Console.WriteLine("Data de admissão não pode ser no futuro.");
            return false;
        }
        return true;
    }

    private static bool CPFValido(string cpf)
    {
        string cpfNumero = @"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$";
        return Regex.IsMatch(cpf, cpfNumero);
    }

    public abstract decimal CalcularBonus();
    public decimal CalcularSalarioLiquido()
    {
        decimal bonus = CalcularBonus();
        if (bonus < 0)
            throw new Exception("Bonus nao pode ser negativo.");
        decimal salarioLiquido = CalcularSalarioBruto() - CalcularDescontoINSS();
        return salarioLiquido;
    }

    public decimal CalcularDescontoINSS()
    {
        return CalcularSalarioBruto() * TaxaInss;
    }

    public decimal CalcularSalarioBruto()
    {
        ;
        return SalarioBase + CalcularBonus();
    }

    
}
