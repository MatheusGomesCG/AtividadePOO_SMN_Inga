using SistemaVeiculos.Enums;

namespace SistemaVeiculos.Models;

public class Caminhao(double cargaMaximaEmQuilos) : Veiculo
{
    public double CargaMaximaEmQuilos { get; } = cargaMaximaEmQuilos;

    public override TipoVeiculoEnum TipoVeiculo => TipoVeiculoEnum.Caminhao;

    public override double CalcularConsumoCombustivel() => 5 / (CargaMaximaEmQuilos / 1000.00);

    public override string ObterDescricao() => $"Carga Máxima: {CargaMaximaEmQuilos} kg";
}
