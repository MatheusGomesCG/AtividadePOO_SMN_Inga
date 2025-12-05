using SistemaBancario.Models;

namespace SistemaBancario;

class Program
{
    static void Main()
    {
        Console.Clear();

        var conta = new Conta("teste", "11111111111");

        var erros = conta.IsValid();

        if (erros.Any())
        {
            foreach (var erro in erros)
                Console.WriteLine(erro);

            return;
        }

        conta.Depositar(100);
        conta.Sacar(50);
        conta.Depositar(200);
        conta.Sacar(300);
        conta.Depositar(500);
        conta.Sacar(150);

        Console.WriteLine("HISTORICO");
        conta.ExibirHistorico();
        Console.WriteLine("EXTRATO ORDENADO");
        conta.ExibirExtratoOrdenado();
        Console.WriteLine("EXTRATO CONSOLIDADO");
        conta.ExibirExtratoConsolidado();
    }
}
