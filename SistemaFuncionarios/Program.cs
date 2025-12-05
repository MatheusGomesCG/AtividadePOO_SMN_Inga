using SistemaFuncionarios.Models;

var empresa = new Empresa();

var gerente = new Gerente("João", "123.456.789-00", 3000.00m, new DateTime(2022, 1, 1));
var desenvolvedor = new Desenvolvedor("Maria", "987.654.321-11", 2500.00m, new DateTime(2023, 5, 10));
var estagiario = new Estagiario("José", "111.222.333-44", 1518.00m, DateTime.Now.AddMonths(-4));
var estagiarioInvalido = new Estagiario("Pedro", "444.555.666-77", 1500.00m, DateTime.Now.AddMonths(1));

var funcionarios = new List<Funcionario> { gerente, desenvolvedor, estagiario, estagiarioInvalido };

foreach (var funcionario in funcionarios)
{
    if (funcionario.IsValid().Count < 1)
    {
        empresa.AdicionarFuncionario(funcionario);
        Console.WriteLine($"{funcionario.Nome} adicionado à empresa.");
    }
    else
    {
        Console.WriteLine($"Erro ao adicionar {funcionario.Nome}:");
        foreach (var erro in funcionario.IsValid())
        {
            Console.WriteLine($"- {erro}");
        }
    }
    Console.WriteLine();
}

var mesReferencia = DateTime.Now.Month;
var anoReferencia = DateTime.Now.Year;

Console.WriteLine(empresa.GerarRelatorioFolhaPagamento(mesReferencia, anoReferencia));
