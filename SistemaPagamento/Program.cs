using SistemaPagamento.Models;

namespace SistemaPagamento;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== SISTEMA DE PAGAMENTO ===\n");

        var cartao = new CartaoCredito(valorTotal: 1000.00m);
        cartao.FinalizarPagamento();
        cartao.Extrato();
        Console.WriteLine();

        var pix = new Pix(valorTotal: 500.00m);
        pix.Extrato();
        Console.WriteLine();

        var boleto = new Boleto(valorTotal: 750.00m);
        boleto.FinalizarPagamento();
        boleto.Extrato();
        Console.WriteLine();

        var transferencia = new Transferencia(valorTotal: 2000.00m);
        transferencia.Extrato();
        Console.WriteLine();

        Console.WriteLine("=== TESTES CONCLUÍDOS ===");
    }
}
