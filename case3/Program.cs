using case3.Models;

namespace case3;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Sistema de Pedidos e Pagamentos ===\n");

        // Teste 1: Criar pedido com PIX (desconto de 0.5%)
        Console.WriteLine("--- Teste 1: Pedido com PIX ---");
        var pedido1 = new Pedido("PED-001");
        pedido1.AdicionarItem(new ItemPedido("Notebook", 3500.00m, 1));
        pedido1.AdicionarItem(new ItemPedido("Mouse", 80.00m, 2));
        pedido1.AdicionarItem(new ItemPedido("Teclado", 250.00m, 1));

        decimal totalPedido1 = pedido1.CalcularTotalPedido();
        var pagamentoPix = new PIX(totalPedido1);
        pedido1.DefinirPagamento(pagamentoPix);

        Console.WriteLine(pedido1.FinalizarCompra(pagamentoPix));
        Console.WriteLine(new string('=', 50) + "\n");

        // Teste 2: Criar pedido com Boleto (taxa de 1%)
        Console.WriteLine("--- Teste 2: Pedido com Boleto ---");
        var pedido2 = new Pedido("PED-002");
        pedido2.AdicionarItem(new ItemPedido("Smartphone", 1800.00m, 1));
        pedido2.AdicionarItem(new ItemPedido("Capinha", 45.00m, 2));
        pedido2.AdicionarItem(new ItemPedido("Película", 20.00m, 2));

        decimal totalPedido2 = pedido2.CalcularTotalPedido();
        var pagamentoBoleto = new Boleto(totalPedido2);
        pedido2.DefinirPagamento(pagamentoBoleto);

        Console.WriteLine(pedido2.FinalizarCompra(pagamentoBoleto));
        Console.WriteLine(new string('=', 50) + "\n");

        // Teste 3: Criar pedido com Cartão de Crédito (taxa de 2.5%)
        Console.WriteLine("--- Teste 3: Pedido com Cartão de Crédito ---");
        var pedido3 = new Pedido("PED-003");
        pedido3.AdicionarItem(new ItemPedido("Smart TV 55\"", 2500.00m, 1));
        pedido3.AdicionarItem(new ItemPedido("Suporte de Parede", 120.00m, 1));
        pedido3.AdicionarItem(new ItemPedido("Cabo HDMI", 35.00m, 2));

        decimal totalPedido3 = pedido3.CalcularTotalPedido();
        var pagamentoCartao = new CartaoCredito(totalPedido3);
        pedido3.DefinirPagamento(pagamentoCartao);

        Console.WriteLine(pedido3.FinalizarCompra(pagamentoCartao));
        Console.WriteLine(new string('=', 50) + "\n");

        // Teste 4: Criar pedido com Transferência (sem taxa)
        Console.WriteLine("--- Teste 4: Pedido com Transferência ---");
        var pedido4 = new Pedido("PED-004");
        pedido4.AdicionarItem(new ItemPedido("Fone Bluetooth", 280.00m, 1));
        pedido4.AdicionarItem(new ItemPedido("Carregador Portátil", 150.00m, 1));

        decimal totalPedido4 = pedido4.CalcularTotalPedido();
        var pagamentoTransferencia = new Transferencia(totalPedido4);
        pedido4.DefinirPagamento(pagamentoTransferencia);

        Console.WriteLine(pedido4.FinalizarCompra(pagamentoTransferencia));
        Console.WriteLine(new string('=', 50) + "\n");

        // Teste 5: Comparação de métodos de pagamento para o mesmo valor
        Console.WriteLine("--- Teste 5: Comparação de Métodos de Pagamento ---");
        decimal valorBase = 1000.00m;
        Console.WriteLine($"Valor Base do Pedido: {valorBase:C}\n");

        var pixComparacao = new PIX(valorBase);
        var boletoComparacao = new Boleto(valorBase);
        var cartaoComparacao = new CartaoCredito(valorBase);
        var transferenciaComparacao = new Transferencia(valorBase);

        Console.WriteLine($"PIX (desconto de 0.5%):");
        Console.WriteLine($"  Taxa: {pixComparacao.Taxa:P}");
        Console.WriteLine($"  Valor Final: {pixComparacao.CalcularValorComTaxa(valorBase):C}");
        Console.WriteLine($"  Tempo de Processamento: {pixComparacao.TempoProcessamento.TotalSeconds}s\n");

        Console.WriteLine($"Boleto (taxa de 1%):");
        Console.WriteLine($"  Taxa: {boletoComparacao.Taxa:P}");
        Console.WriteLine($"  Valor Final: {boletoComparacao.CalcularValorComTaxa(valorBase):C}");
        Console.WriteLine($"  Tempo de Processamento: {boletoComparacao.TempoProcessamento.TotalHours}h\n");

        Console.WriteLine($"Cartão de Crédito (taxa de 2.5%):");
        Console.WriteLine($"  Taxa: {cartaoComparacao.Taxa:P}");
        Console.WriteLine($"  Valor Final: {cartaoComparacao.CalcularValorComTaxa(valorBase):C}");
        Console.WriteLine($"  Tempo de Processamento: {cartaoComparacao.TempoProcessamento.TotalHours}h\n");

        Console.WriteLine($"Transferência (sem taxa):");
        Console.WriteLine($"  Taxa: {transferenciaComparacao.Taxa:P}");
        Console.WriteLine($"  Valor Final: {transferenciaComparacao.CalcularValorComTaxa(valorBase):C}");
        Console.WriteLine($"  Tempo de Processamento: {transferenciaComparacao.TempoProcessamento.TotalHours}h\n");

        Console.WriteLine(new string('=', 50) + "\n");

        // Teste 6: Validação - Tentar finalizar pedido sem itens
        Console.WriteLine("--- Teste 6: Validação - Pedido Sem Itens ---");
        var pedidoVazio = new Pedido("PED-005");
        var pagamentoVazio = new PIX(0);
        Console.WriteLine(pedidoVazio.FinalizarCompra(pagamentoVazio));
        Console.WriteLine(new string('=', 50) + "\n");

        // Teste 7: Validação - Tentar finalizar pedido sem método de pagamento
        Console.WriteLine("--- Teste 7: Validação - Sem Método de Pagamento ---");
        var pedidoSemPagamento = new Pedido("PED-006");
        pedidoSemPagamento.AdicionarItem(new ItemPedido("Produto Teste", 100.00m, 1));
        Console.WriteLine(pedidoSemPagamento.FinalizarCompra(null));
        Console.WriteLine(new string('=', 50) + "\n");

        // Teste 8: Validação - Adicionar item nulo
        Console.WriteLine("--- Teste 8: Validação - Item Nulo ---");
        var pedidoItemNulo = new Pedido("PED-007");
        pedidoItemNulo.AdicionarItem(null);
        Console.WriteLine("Item nulo não foi adicionado ao pedido.\n");
        Console.WriteLine(new string('=', 50) + "\n");

        // Teste 9: Pedido com múltiplos itens da mesma categoria
        Console.WriteLine("--- Teste 9: Pedido com Múltiplos Itens ---");
        var pedido9 = new Pedido("PED-009");
        pedido9.AdicionarItem(new ItemPedido("Livro - C#", 89.90m, 3));
        pedido9.AdicionarItem(new ItemPedido("Livro - Python", 95.00m, 2));
        pedido9.AdicionarItem(new ItemPedido("Livro - JavaScript", 79.90m, 4));
        pedido9.AdicionarItem(new ItemPedido("Livro - Java", 105.00m, 1));

        decimal totalPedido9 = pedido9.CalcularTotalPedido();
        Console.WriteLine($"Total de itens: {pedido9.ListaItem.Count}");
        Console.WriteLine($"Quantidade total de produtos: {pedido9.ListaItem.Sum(i => i.Quantidade)}");
        Console.WriteLine($"Valor total: {totalPedido9:C}\n");

        var pagamentoPedido9 = new PIX(totalPedido9);
        pedido9.FinalizarCompra(pagamentoPedido9);
        Console.WriteLine(new string('=', 50) + "\n");

        // Teste 10: Resumo final
        Console.WriteLine("--- Teste 10: Resumo de Todos os Pedidos ---");
        var todosPedidos = new List<Pedido> { pedido1, pedido2, pedido3, pedido4, pedido9 };
        decimal totalGeral = 0;

        foreach (var pedido in todosPedidos)
        {
            if (pedido.ListaItem.Count > 0 && pedido.Pagamento != null)
            {
                decimal total = pedido.CalcularTotalPedido();
                decimal totalComTaxa = pedido.Pagamento.CalcularValorComTaxa(total);
                totalGeral += totalComTaxa;
                Console.WriteLine($"{pedido.NumeroPedido} - {pedido.Pagamento.Tipo} - Subtotal: {total:C} - Total com Taxa: {totalComTaxa:C}");
            }
        }
        Console.WriteLine($"\nValor Total de Todas as Vendas: {totalGeral:C}");

        Console.WriteLine("\n=== Fim dos Testes ===");
    }
}
