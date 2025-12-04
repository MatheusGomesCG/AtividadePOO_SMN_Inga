using SistemaBancario.Enum;

namespace SistemaBancario.Models;

public class HistoricoConta
{
    public int IdContaBancaria { get; }
    public TipoMovimentacaoEnum TipoMovimentacao { get; }
    public decimal Valor { get; }
    public bool Sucesso { get; }

    public HistoricoConta(int idContaBancaria, TipoMovimentacaoEnum tipoMovimentacao, decimal valor, bool sucesso)
    {
        IdContaBancaria = idContaBancaria;
        TipoMovimentacao = tipoMovimentacao;
        Valor = valor;
        Sucesso = sucesso;
    }
}
