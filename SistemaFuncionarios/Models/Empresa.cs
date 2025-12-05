using System.Text;

namespace SistemaFuncionarios.Models;

public class Empresa
{
    private readonly List<Funcionario> _funcionarios = new();

    public void AdicionarFuncionario(Funcionario funcionario) => _funcionarios.Add(funcionario);

    public string GerarRelatorioFolhaPagamento(int mes, int ano)
    {
        var relatorio = new StringBuilder();
        relatorio.AppendLine($" Relatório de Folha de Pagamento - {mes}/{ano}");
        relatorio.AppendLine($"Gerado em: {DateTime.Now:dd/MM/yyyy}");

        var funcionariosOrdenados = _funcionarios.OrderByDescending(f => f.CalcularSalarioLiquido());

        foreach (var funcionario in funcionariosOrdenados)
        {
            relatorio.AppendLine($"Nome: {funcionario.Nome}");
            relatorio.AppendLine($"CPF: {funcionario.Cpf}");
            relatorio.AppendLine($"Cargo: {funcionario.Cargo}");
            relatorio.AppendLine($"Salário Bruto: {funcionario.SalarioBase:C}");
            relatorio.AppendLine($"Descontos (INSS): {funcionario.SalarioBase * Funcionario.TaxaInss:C}");
            relatorio.AppendLine($"Salário Líquido: {funcionario.CalcularSalarioLiquido():C}");
            Console.WriteLine();
        }

        return relatorio.ToString();
    }
}