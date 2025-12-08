using case4.Enum;

namespace case4.Models;

public class Moto(string nome, string marca, int ano, int cilindradas) : Veiculo(nome, marca, ano)
{
    public int Cilindradas { get; } = cilindradas;
    public override TipoVeiculoEnum TipoVeiculo => TipoVeiculoEnum.Moto;

    public override decimal CalcularConsumoCombustivel() => 40000 / Cilindradas;

    public override List<string> IsValid()
    {
        var erros = base.IsValid();

        if (Cilindradas <= 0)
            erros.Add("As cilindradas da moto devem ser maiores que zero.");

        return erros;
    }
}
