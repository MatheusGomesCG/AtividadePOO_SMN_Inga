using case1.Enum;

namespace case1.Model;

public class Movimentacao
{
    public int IdConta { get; }
    public TipoMovimentacao Tipo { get; }
    public decimal Valor { get; }
    public DateTime Data { get; }
    public bool EfetuadaComSucesso { get; }

    public Movimentacao(int idConta, TipoMovimentacao tipo, decimal valor, bool efetuadaComSucesso)
    {
        IdConta = idConta;
        Tipo = tipo;
        Valor = valor;
        Data = DateTime.Now;
        EfetuadaComSucesso = efetuadaComSucesso;
    }

    public override string ToString()
    {
        var efetuadaComSucesso = EfetuadaComSucesso ? "Sim" : "Não";
        return $"IdConta: {IdConta}, Tipo: {Tipo}, Valor: {Valor:C}, Data: {Data:dd/MM/yyyy}, Sucesso: {efetuadaComSucesso}";
    }
}
