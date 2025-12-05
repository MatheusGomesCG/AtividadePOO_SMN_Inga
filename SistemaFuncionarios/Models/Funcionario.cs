using SistemaFuncionarios.Enums;

namespace SistemaFuncionarios.Models;

public abstract class Funcionario(string nome, string cpf, decimal salarioBase, DateTime dataAdmissao)
{
    public const decimal TaxaInss = 0.08m;

    public string Nome { get; } = nome;
    public string Cpf { get; } = cpf;
    public decimal SalarioBase { get; } = salarioBase;
    public DateTime DataAdmissao { get; } = dataAdmissao;
    public abstract TipoFuncionarioEnum Cargo { get; }
    public abstract List<string> IsValid();
    public abstract decimal CalcularBonus();
    public decimal CalcularSalarioLiquido()
    {
        var bonus = CalcularBonus();
        var inss = SalarioBase * TaxaInss;
        return SalarioBase + bonus - inss;
    }
}
