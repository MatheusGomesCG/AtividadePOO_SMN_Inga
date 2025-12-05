using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using case2._1.Enum;

namespace case2._1.Model
{
    public class Estagiario : Funcionario
    {

        public Estagiario(int id, string nome, string cpf, DateTime dataAdmissao) : base(id, nome, cpf, dataAdmissao)
        {
        }

        public override TipoFuncionario Tipo => TipoFuncionario.Estagiario;

        public override decimal TaxaBonus => DataAdmissao < DateTime.Now.AddMonths(-3) ? 0.05m : 0.0m;

        public override decimal CalcularBonus()
        {
            return SalarioBase * TaxaBonus;
        }
    }
}