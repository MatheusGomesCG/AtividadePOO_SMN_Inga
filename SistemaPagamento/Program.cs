using SistemaPagamento.Models;

namespace SistemaPagamento;

class Program
{
    static void Main()
    {
        Console.WriteLine("SISTEMA DE PAGAMENTOS\n");

        ProcessarPagamento("PED001", 100.00m, new CartaoCredito());
        ProcessarPagamento("PED002", 250.50m, new Pix());
        ProcessarPagamento("PED003", 500.00m, new Boleto());
        ProcessarPagamento("PED004", 1000.00m, new Transferencia());
    }

    static void ProcessarPagamento(string numero, decimal valor, Pagamento pagamento)
    {
        var pedido = new Pedido(numero, valor);
        pedido.MetodoPagamento = pagamento;
        pedido.FinalizarPagamento();
    }
}
