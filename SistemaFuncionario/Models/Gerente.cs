using SistemaFuncionario.Enums;

namespace SistemaFuncionario.Models;

public class Gerente(string nome, string cpf, DateTime dataAdmissao) : Funcionario(nome, cpf, dataAdmissao)
{
    public override decimal TaxaBonus => 0.2m;
    public override TipoFuncionarioEnum TipoFuncionario => TipoFuncionarioEnum.Gerente;
}
