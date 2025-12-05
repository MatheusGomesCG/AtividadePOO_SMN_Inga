using case2.Data;
using case2.Data.Repository;
using case2.Interface;
using case2.Model;
using case2.Repository;
using case2.Service;

namespace case2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Sistema de Gerenciamento de Funcionários ===\n");

        // Configurar repositório e serviço
        DbContext dbContext = new DbContext();
        IFuncionarioRepository repository = new FuncionarioRepository(dbContext);
        IFuncionarioService service = new FuncionarioService(repository);

        // Teste 1: Adicionar Gerente
        Console.WriteLine("--- Teste 1: Adicionar Gerente ---");
        var gerente = new Gerente(1, "Maria Silva", "12345678901", DateTime.Now.AddYears(-2));
        service.AdicionarFuncionario(gerente);
        Console.WriteLine($"Gerente adicionado: {gerente.Nome}");
        Console.WriteLine($"Tipo: {gerente.Tipo}");
        Console.WriteLine($"Salário Base: R$ {gerente.SalarioBase:F2}");
        Console.WriteLine($"Bônus: {gerente.Bonus * 100}% = R$ {gerente.CalcularBonus():F2}");
        Console.WriteLine($"Salário Total: R$ {gerente.CalcularSalarioLiquido():F2}\n");

        // Teste 2: Adicionar Desenvolvedor
        Console.WriteLine("--- Teste 2: Adicionar Desenvolvedor ---");
        var desenvolvedor = new Desenvolvedor(2, "João Santos", "98765432100", DateTime.Now.AddYears(-1));
        service.AdicionarFuncionario(desenvolvedor);
        Console.WriteLine($"Desenvolvedor adicionado: {desenvolvedor.Nome}");
        Console.WriteLine($"Tipo: {desenvolvedor.Tipo}");
        Console.WriteLine($"Salário Base: R$ {desenvolvedor.SalarioBase:F2}");
        Console.WriteLine($"Bônus: {desenvolvedor.Bonus * 100}% = R$ {desenvolvedor.CalcularBonus():F2}");
        Console.WriteLine($"Salário Total: R$ {desenvolvedor.CalcularSalarioLiquido():F2}\n");

        // Teste 3: Adicionar Estagiário com menos de 3 meses (sem bônus)
        Console.WriteLine("--- Teste 3: Adicionar Estagiário (menos de 3 meses) ---");
        var estagiarioNovo = new Estagiario(3, "Pedro Costa", "11122233344", DateTime.Now.AddMonths(-2));
        service.AdicionarFuncionario(estagiarioNovo);
        Console.WriteLine($"Estagiário adicionado: {estagiarioNovo.Nome}");
        Console.WriteLine($"Tipo: {estagiarioNovo.Tipo}");
        Console.WriteLine($"Data Admissão: {estagiarioNovo.DataAdmissao:dd/MM/yyyy}");
        Console.WriteLine($"Salário Base: R$ {estagiarioNovo.SalarioBase:F2}");
        Console.WriteLine($"Bônus: {estagiarioNovo.Bonus * 100}% = R$ {estagiarioNovo.CalcularBonus():F2}");
        Console.WriteLine($"Salário Total: R$ {estagiarioNovo.CalcularSalarioLiquido():F2}\n");

        // Teste 4: Adicionar Estagiário com mais de 3 meses (com bônus)
        Console.WriteLine("--- Teste 4: Adicionar Estagiário (mais de 3 meses) ---");
        var estagiarioAntigo = new Estagiario(4, "Ana Oliveira", "55566677788", DateTime.Now.AddMonths(-6));
        service.AdicionarFuncionario(estagiarioAntigo);
        Console.WriteLine($"Estagiário adicionado: {estagiarioAntigo.Nome}");
        Console.WriteLine($"Tipo: {estagiarioAntigo.Tipo}");
        Console.WriteLine($"Data Admissão: {estagiarioAntigo.DataAdmissao:dd/MM/yyyy}");
        Console.WriteLine($"Salário Base: R$ {estagiarioAntigo.SalarioBase:F2}");
        Console.WriteLine($"Bônus: {estagiarioAntigo.Bonus * 100}% = R$ {estagiarioAntigo.CalcularBonus():F2}");
        Console.WriteLine($"Salário Total: R$ {estagiarioAntigo.CalcularSalarioLiquido():F2}\n");

        // Teste 5: Listar todos os funcionários
        Console.WriteLine("--- Teste 5: Listar Todos os Funcionários ---");
        var funcionarios = service.ObterFuncionarios();
        Console.WriteLine($"Total de funcionários: {funcionarios.Count}\n");
        foreach (var func in funcionarios)
        {
            Console.WriteLine($"ID: {func.Id} | Nome: {func.Nome} | Tipo: {func.Tipo} | Salário: R$ {func.CalcularSalarioLiquido():F2}");
        }
        Console.WriteLine();

        // Teste 6: Buscar funcionário por ID
        Console.WriteLine("--- Teste 6: Buscar Funcionário por ID ---");
        var funcionarioEncontrado = service.ObterFuncionarioPorId(2);
        if (funcionarioEncontrado != null)
        {
            Console.WriteLine($"Funcionário encontrado: {funcionarioEncontrado.Nome} ({funcionarioEncontrado.Tipo})");
            Console.WriteLine($"CPF: {funcionarioEncontrado.CPF}");
            Console.WriteLine($"Salário: R$ {funcionarioEncontrado.CalcularSalarioLiquido():F2}\n");
        }

        // Teste 7: Tentativa de adicionar funcionário com dados inválidos
        Console.WriteLine("--- Teste 7: Validação - CPF Inválido ---");
        var funcionarioInvalido = new Gerente(5, "Carlos Lima", "123", DateTime.Now.AddMonths(-1));
        service.AdicionarFuncionario(funcionarioInvalido);
        Console.WriteLine();

        // Teste 8: Tentativa de adicionar funcionário com nome vazio
        Console.WriteLine("--- Teste 8: Validação - Nome Vazio ---");
        var funcionarioNomeVazio = new Desenvolvedor(6, "", "12345678901", DateTime.Now);
        service.AdicionarFuncionario(funcionarioNomeVazio);
        Console.WriteLine();

        // Teste 9: Buscar funcionário com ID inválido
        Console.WriteLine("--- Teste 9: Validação - ID Inválido ---");
        var funcionarioIdInvalido = service.ObterFuncionarioPorId(-1);
        Console.WriteLine();

        // Teste 10: Adicionar pagamentos aos funcionários
        Console.WriteLine("--- Teste 10: Adicionar Pagamentos ---");
        gerente.Pagamentos.Add(new Pagamento(gerente, gerente.CalcularSalarioLiquido(), DateTime.Now.AddMonths(-1)));
        gerente.Pagamentos.Add(new Pagamento(gerente, gerente.CalcularSalarioLiquido(), DateTime.Now));
        Console.WriteLine($"Pagamentos adicionados para {gerente.Nome}:");
        Console.WriteLine($"Total de pagamentos: {gerente.Pagamentos.Count}");
        Console.WriteLine($"Valor total pago: R$ {gerente.Pagamentos.Sum(p => p.Valor):F2}\n");

        Console.WriteLine("=== Fim dos Testes ===");
    }
}
