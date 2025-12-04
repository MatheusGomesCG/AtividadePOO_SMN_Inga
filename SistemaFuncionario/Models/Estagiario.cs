using SistemaFuncionario.Enums;

namespace SistemaFuncionario.Models;

public class Estagiario(string nome, string cpf, DateTime dataAdmissao) : Funcionario(nome, cpf, dataAdmissao)
{
    public override decimal TaxaBonus => DataAdmissao < DateTime.Now.AddMonths(-3) ? 0.05m : 0m;
    public override TipoFuncionarioEnum TipoFuncionario => TipoFuncionarioEnum.Estagiario;
}
