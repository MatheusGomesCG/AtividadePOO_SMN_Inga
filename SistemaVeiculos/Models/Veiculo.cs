using SistemaVeiculos.Enums;

namespace SistemaVeiculos.Models;

public abstract class Veiculo
{
    public abstract TipoVeiculoEnum TipoVeiculo { get; }
    public abstract double CalcularConsumoCombustivel();
    public abstract string ObterDescricao();
}
