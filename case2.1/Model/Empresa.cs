using System.Collections.Generic;

namespace case2._1.Model;

public class Empresa
{
    public List<Funcionario> Funcionarios { get; }

    public void AdicionarFuncionario(Funcionario funcionario)
    {
        var funcionarioValido = funcionario.IsValid();

        if (funcionarioValido.Any())
        {
            foreach (var erro in funcionarioValido)
            {
                Console.WriteLine($"{erro}");
            }
            return;
        }
        Funcionarios.Add(funcionario);
    }

    public Funcionario ObterFuncionarioPorId(int id)
    {
        if (id <= 0)
        {
            Console.WriteLine("ID inválido.");
            return null;
        }
        return Funcionarios.FirstOrDefault(f => f.Id == id);
    }

    public List<Funcionario> ObterFuncionarios()
    {
        var funcionarios = FuncionariosOrdenadosPorSalario();
        if (!funcionarios.Any())
        {
            Console.WriteLine("Nenhum funcionário cadastrado.");
        }
        return funcionarios;
    }
    private List<Funcionario> FuncionariosOrdenadosPorSalario() =>Funcionarios.OrderByDescending(f => f.CalcularSalarioLiquido()).ToList();

}
