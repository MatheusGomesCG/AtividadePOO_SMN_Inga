namespace SistemaPagamento.Interfaces;

public interface IPagamento
{
    decimal CalcularValorComTaxa();
    void FinalizarPagamento();
}
