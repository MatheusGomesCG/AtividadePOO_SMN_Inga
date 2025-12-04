using System;
using case2.Enum;

namespace case2.Model;

public class Desenvolvedor : Funcionario
{
    public Desenvolvedor(int id, string nome, string cpf, DateTime dataAdmissao) : base(id, nome, cpf, dataAdmissao)
    {
    }

    public override TipoFuncionario Tipo  => TipoFuncionario.Desenvolvedor;
    public override decimal TaxaBonus => 0.10m;
    public override decimal CalcularBonus()
    {
        return SalarioBase * TaxaBonus;
    }
}