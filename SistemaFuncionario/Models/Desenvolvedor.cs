using SistemaFuncionario.Enums;

namespace SistemaFuncionario.Models;

public class Desenvolvedor(string nome, string cpf, DateTime dataAdmissao) : Funcionario(nome, cpf, dataAdmissao)
{
    public override decimal TaxaBonus => 0.15m;
    public override TipoFuncionarioEnum TipoFuncionario => TipoFuncionarioEnum.Desenvolvedor;
}
