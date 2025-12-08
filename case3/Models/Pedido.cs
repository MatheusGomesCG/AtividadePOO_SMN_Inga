using System.Text;

namespace case3.Models;

public class Pedido
{
    public List<ItemPedido> ListaItem { get; } = new List<ItemPedido>();
    public string NumeroPedido { get; }
    public DateTime DataPedido { get; } = DateTime.Now;
    public Pagamento Pagamento { get; private set; }

    public Pedido(string numeroPedido)
    {
        NumeroPedido = numeroPedido;
    }

    public void AdicionarItem(ItemPedido item)
    {
        if (item == null)
        {
            Console.WriteLine("Item do pedido não pode ser nulo.");
            return;
        }
        ListaItem.Add(item);
    }

    public decimal CalcularTotalPedido() => ListaItem.Sum(item => item.Preco * item.Quantidade);

    public void DefinirPagamento(Pagamento pagamento)
    {
        if (pagamento == null)
        {
            Console.WriteLine("Pagamento não pode ser nulo.");
            return;
        }
        Pagamento = pagamento;
    }

    public string FinalizarCompra(Pagamento MetodoPagamento)
    {
        StringBuilder sb = new StringBuilder();
        if (MetodoPagamento == null)
        {
            sb.AppendLine("Metodo de pagamento nao foi definido.");
            return sb.ToString();
        }
        if (!ListaItem.Any())
        {
            sb.AppendLine("Nenhum item no pedido para finalizar a compra.");
            return sb.ToString();
        }
        MetodoPagamento.FinalizarPagamento();

        decimal valorTotal = CalcularTotalPedido();

        sb.AppendLine("Detalhes do Pedido:");
        sb.AppendLine($"Pedido: {NumeroPedido}");
        sb.AppendLine($"Data: {DataPedido:dd/MM/yyyy}");
        sb.AppendLine("\nItens do Pedido:");

        foreach (var item in ListaItem)
        {
            sb.AppendLine($"{item.Nome}: {item.Quantidade} - {item.Preco:C} = {(item.Preco * item.Quantidade):C}");
        }

        sb.AppendLine(new string('-', 30));
        sb.AppendLine($"Subtotal: {valorTotal:C}\n");
        sb.AppendLine(new string('-', 30));
        sb.AppendLine(MetodoPagamento.RelatorioFinalizacao());
        return sb.ToString();
    }
}
