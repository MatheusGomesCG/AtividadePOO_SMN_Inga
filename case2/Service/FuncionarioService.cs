using case2.Interface;
using case2.Model;
using case2.Repository;

namespace case2.Service;

public class FuncionarioService : IFuncionarioService
{
    private readonly IFuncionarioRepository _funcionarioRepository;


    public FuncionarioService(IFuncionarioRepository funcionarioRepository)
    {
        _funcionarioRepository = funcionarioRepository;
    }

    public void AdicionarFuncionario(Funcionario funcionario)
    {
        if (!funcionario.IsValid())
        {
            Console.WriteLine("Dados do funcionário inválidos.");
            return;
        }
        _funcionarioRepository.AdicionarFuncionario(funcionario);
    }

    public Funcionario ObterFuncionarioPorId(int id)
    {
        if (id <= 0)
        {
            Console.WriteLine("ID inválido.");
            return null;
        }
        return _funcionarioRepository.ObterFuncionarioPorId(id);
    }

    public List<Funcionario> ObterFuncionarios()
    {
        var funcionarios = _funcionarioRepository.ObterFuncionarios();
        if (!funcionarios.Any())
        {
            Console.WriteLine("Nenhum funcionário cadastrado.");
        }
        return funcionarios;
    }
}