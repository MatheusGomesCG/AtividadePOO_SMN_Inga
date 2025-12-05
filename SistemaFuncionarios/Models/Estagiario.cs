using SistemaFuncionarios.Enums;

namespace SistemaFuncionarios.Models;

public class Estagiario(string nome, string cpf, decimal salarioBase, DateTime dataAdmissao) : Funcionario(nome, cpf, salarioBase, dataAdmissao)
{
    private int PeriodoProbatorioEmMeses { get; } = 3;

    public override TipoFuncionarioEnum Cargo => TipoFuncionarioEnum.Estagiario;

    public override decimal CalcularBonus()
    {
        var mesesDeEmpresa = (DateTime.Now - DataAdmissao).Days / 30;
        return mesesDeEmpresa > PeriodoProbatorioEmMeses ? SalarioBase * 0.05m : 0;
    }

    public override List<string> IsValid()
    {
        var erros = new List<string>();
        if (SalarioBase < 1518.00m)
            erros.Add("Salário base não pode ser menor que o salário mínimo (R$ 1.518,00)");

        if (DataAdmissao > DateTime.Now)
            erros.Add("Data de admissão não pode ser posterior à data atual");

        if (CalcularBonus() < 0)
            erros.Add("Bônus não pode ser negativo");

        return erros;
    }
}
