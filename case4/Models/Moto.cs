using case4.Enum;

namespace case4.Models;

public class Moto : Veiculo
{
    public int Cilindradas { get;}
    public override TipoVeiculoEnum TipoVeiculo => TipoVeiculoEnum.Moto;

    public Moto(string nome, string marca, int ano, int cilindradas) : base(nome, marca, ano)
    {
        Cilindradas = cilindradas;
    }
    public override decimal CalcularConsumoCombustivel()
    {
        return 40000 / Cilindradas;
    }

    public override (List<string>, bool) IsValid()
    {
        (List<string> erros, bool isValid) = base.IsValid();
        if (Cilindradas <= 0)
            erros.Add("As cilindradas da moto devem ser maiores que zero.");
        return (erros, erros.Count == 0);
    }
}
