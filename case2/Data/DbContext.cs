using case2.Model;

namespace case2.Repository;

public class DbContext
{
    public List<Funcionario> FuncionariosRepository { get; } = new List<Funcionario>();
}
