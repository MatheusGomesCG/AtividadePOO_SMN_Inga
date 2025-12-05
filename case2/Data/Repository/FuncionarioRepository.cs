using case2.Interface;
using case2.Model;
using case2.Repository;

namespace case2.Data.Repository;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly DbContext _dbContext;
    public FuncionarioRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void AdicionarFuncionario(Funcionario funcionario)
    {
        _dbContext.FuncionariosRepository.Add(funcionario);
    }

    public Funcionario ObterFuncionarioPorId(int id)
    {
        return _dbContext.FuncionariosRepository.FirstOrDefault(f => f.Id == id);
    }

    public List<Funcionario> ObterFuncionarios()
    {
        return _dbContext.FuncionariosRepository
            .OrderByDescending(s => s.CalcularSalarioLiquido())
            .ToList();
    }
}
