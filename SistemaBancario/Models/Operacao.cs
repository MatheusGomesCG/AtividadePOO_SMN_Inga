using SistemaBancario.Enums;

namespace SistemaBancario.Models;

public class Operacao(TipoOperacaoEnum tipo, decimal valor, bool sucesso)
{
    public DateTime Data { get; set; } = DateTime.Now;
    public TipoOperacaoEnum Tipo { get; set; } = tipo;
    public decimal Valor { get; set; } = valor;
    public bool Sucesso { get; } = sucesso;

    public override string ToString() =>
     $"Data: {Data}, Tipo: {Tipo}, Valor: {Valor:C}, Status: " + (Sucesso ? "Sucesso" : "Falha");

}
