using case2.Model;

namespace case2.Interface;

public interface IFuncionarioRepository
{
    void AdicionarFuncionario(Funcionario funcionario);
    Funcionario ObterFuncionarioPorId(int id);
    List<Funcionario> ObterFuncionarios();
}
