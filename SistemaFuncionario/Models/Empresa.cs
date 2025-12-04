namespace SistemaFuncionario.Models;

public class Empresa
{
    public List<Funcionario> Funcionarios { get; } = new();

    public void AdicionarFuncionario(Funcionario funcionario)
    {
        if (!funcionario.IsValid())
        {
            Console.WriteLine("Funcionário inválido. Verifique os dados e tente novamente.");
            return;
        }

        Funcionarios.Add(funcionario);
        Console.WriteLine("Funcionário adicionado com sucesso.");
    }

    public void BuscarFuncionarioPorId(int id)
    {
        if (id <= 0)
        {
            Console.WriteLine("ID inválido. Deve ser um número positivo.");
            return;
        }

        var funcionario = Funcionarios.FirstOrDefault(f => f.Id == id);
        if (funcionario == null)
        {
            Console.WriteLine("Funcionário não encontrado.");
            return;
        }
        
        funcionario.Pagamentos.ForEach(p => Console.WriteLine(p.Relatorio()));
    }

    public void ListarFuncionarios()
    {
        var funcionarios = ListarFuncionariosOrdenados();
        if (!funcionarios.Any())
        {
            Console.WriteLine("Nenhum funcionário cadastrado.");
            return;
        }

        foreach (var funcionario in funcionarios)
            funcionario.Pagamentos.ForEach(p => Console.WriteLine(p.Relatorio()));
    }

    private List<Funcionario> ListarFuncionariosOrdenados() => Funcionarios.OrderByDescending(f => f.CalcularSalarioLiquido()).ToList();
}
