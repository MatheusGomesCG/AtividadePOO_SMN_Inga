using case1.Enum;

namespace case1.Model;

public class Movimentacao
{
    public TipoMovimentacao Tipo { get; }

    public decimal Valor { get; }
    public DateTime Data { get; }
    public bool EfetuadaComSucesso { get; }

    public Movimentacao(TipoMovimentacao tipo, decimal valor, bool efetuadaComSucesso)
    {
        Tipo = tipo;
        Valor = valor;
        Data = DateTime.Now;
        EfetuadaComSucesso = efetuadaComSucesso;
    }

    public override string ToString()
    {
        var tipo = Tipo == TipoMovimentacao.Deposito ? "Depósito" : "Saque";
        var efetuadaComSucesso = EfetuadaComSucesso ? "Sim" : "Não";
        return $"Tipo: {tipo}, Valor: {Valor:C}, Data: {Data:dd/MM/yyyy}, Sucesso: {efetuadaComSucesso}";
    }
}
