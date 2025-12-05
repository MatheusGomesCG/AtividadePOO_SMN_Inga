using case2.Model;

namespace case2.Interface;

public interface IFuncionarioService
{
    void AdicionarFuncionario(Funcionario funcionario);
    List<Funcionario> ObterFuncionarios();
    Funcionario ObterFuncionarioPorId(int id);

}
