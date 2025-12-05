namespace case3.Models;

public class ItemPedido
{
    public string Nome { get; }
    public decimal Preco { get; }
    public int Quantidade { get; }
    public ItemPedido(string nome, decimal preco, int quantidade)
    {
        Nome = nome;
        Preco = preco;
        Quantidade = quantidade;
    }
}