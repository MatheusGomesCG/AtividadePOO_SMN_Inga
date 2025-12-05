using case2._1.Enum;

namespace case2._1.Model;

public class Gerente : Funcionario
{
    public Gerente(int id, string nome, string cpf, DateTime dataAdmissao) : base(id, nome, cpf, dataAdmissao)
    {
    }

    public override TipoFuncionario Tipo => TipoFuncionario.Gerente;

    public override decimal TaxaBonus => 0.20m;

    public override decimal CalcularBonus()
    {
        return SalarioBase * TaxaBonus;
    }
}
