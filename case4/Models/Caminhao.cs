using case4.Enum;

namespace case4.Models;

public class Caminhao(string nome, string marca, int ano, int capacidadeCarga) : Veiculo(nome, marca, ano)
{
    public int CapacidadeCarga { get; } = capacidadeCarga;
    public override TipoVeiculoEnum TipoVeiculo => TipoVeiculoEnum.Caminhao;

    public override decimal CalcularConsumoCombustivel() => 5 / (CapacidadeCarga / 1000m);

    public override List<string> IsValid()
    {
        var erros = base.IsValid();

        if (CapacidadeCarga <= 0)
            erros.Add("A capacidade de carga do caminhão deve ser maior que zero.");

        return erros;
    }
}
