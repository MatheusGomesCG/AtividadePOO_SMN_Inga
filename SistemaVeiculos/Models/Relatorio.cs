using System.Text;

namespace SistemaVeiculos.Models;

public class Relatorio
{
    public string GerarRelatorioDeFrotas(List<Veiculo> veiculos)
    {
        var relatorio = new StringBuilder();
        relatorio.AppendLine("  Relatório de Frota ");

        foreach (var veiculo in veiculos)
        {
            relatorio.AppendLine($"Tipo: {veiculo.TipoVeiculo}");
            relatorio.AppendLine($"Consumo: {veiculo.CalcularConsumoCombustivel():F2} km/L");

            relatorio.AppendLine(veiculo.ObterDescricao());
        }

        return relatorio.ToString();
    }
}
