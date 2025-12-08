using SistemaVeiculos.Enums;

namespace SistemaVeiculos.Models;

public class Carro(int numeroDePortas) : Veiculo
{
    public int NumeroDePortas { get; } = numeroDePortas;

    public override TipoVeiculoEnum TipoVeiculo => TipoVeiculoEnum.Carro;

    public override double CalcularConsumoCombustivel() => 16 - NumeroDePortas;

    public override string ObterDescricao() => $"Número de Portas: {NumeroDePortas}";
}
