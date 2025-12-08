using case4.Enum;

namespace case4.Models;

public class Carro : Veiculo
{
    public int NumeroPortas { get; }
    public override TipoVeiculoEnum TipoVeiculo => TipoVeiculoEnum.Carro;
    public Carro(string nome, string marca, int ano, int numeroPortas) : base(nome, marca, ano)
    {
        NumeroPortas = numeroPortas;
    }
    public override decimal CalcularConsumoCombustivel()
    {
        return 16 - NumeroPortas;
    }
    public override (List<string>, bool) IsValid()
    {
        (List<string> erros, bool isValid) = base.IsValid();
        if (NumeroPortas <= 0)
            erros.Add("O número de portas do carro deve ser maior que zero.");
        return (erros, erros.Count == 0);
    }
}
