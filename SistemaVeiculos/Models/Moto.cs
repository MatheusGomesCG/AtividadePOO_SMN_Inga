using SistemaVeiculos.Enums;

namespace SistemaVeiculos.Models;

public class Moto(double cilindradas) : Veiculo
{
    public double Cilindradas { get; } = cilindradas;

    public override TipoVeiculoEnum TipoVeiculo => TipoVeiculoEnum.Moto;

    public override double CalcularConsumoCombustivel() => 40000 / Cilindradas;

    public override string ObterDescricao() => $"Cilindradas: {Cilindradas} cc";
}
