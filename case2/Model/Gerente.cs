using case2.Enum;

namespace case2.Model;

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