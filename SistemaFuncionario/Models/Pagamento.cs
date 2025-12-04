using System.Text;

namespace SistemaFuncionario.Models;

public class Pagamento(decimal valor, DateTime dataPagamento, Funcionario funcionario)
{
    public int IdFuncionario { get; } = funcionario.Id;
    public decimal Valor { get; } = valor;
    public DateTime DataPagamento { get; } = dataPagamento;
    public Funcionario Funcionario { get; } = funcionario;

    public string Relatorio()
    {
        StringBuilder sb = new();
        sb.AppendLine($"Relatório de Pagamento - {DataPagamento.Month:D2}/{DataPagamento.Year}");
        sb.AppendLine($"Nome: {Funcionario.Nome}");
        sb.AppendLine($"CPF: {Funcionario.CPF}");
        sb.AppendLine($"Cargo: {Funcionario.TipoFuncionario}");
        sb.AppendLine($"Salário Liquído: {Funcionario.CalcularSalarioLiquido():C}");
        sb.AppendLine($"Data geração do relatório: {DateTime.Now:dd/MM/yyyy}");

        return sb.ToString();
    }
}
