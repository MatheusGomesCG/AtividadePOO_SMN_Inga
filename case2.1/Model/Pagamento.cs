using System.Text;

namespace case2._1.Model;

public class Pagamento
{
    public int IdFuncionario { get; }
    public Funcionario Funcionario { get; }
    public decimal Valor { get; }
    public DateTime DataPagamento { get; }

    public Pagamento(Funcionario funcionario, decimal valor, DateTime dataPagamento)
    {
        IdFuncionario = funcionario.Id;
        Funcionario = funcionario;
        Valor = valor;
        DataPagamento = dataPagamento;
    }

    public string Relatorio(){
        StringBuilder relatorio = new StringBuilder();
        relatorio.AppendLine($"Nome: {Funcionario.Nome}");
        relatorio.AppendLine($"CPF: {Funcionario.CPF}");
        relatorio.AppendLine($"Cargo: {Funcionario.Tipo}");
        relatorio.AppendLine($"Data de Admissao: {Funcionario.DataAdmissao:dd/MM/yyyy}");
        relatorio.AppendLine($"Salario Liquido: {Funcionario.CalcularSalarioLiquido():C}");
        return relatorio.ToString();
    }
}
