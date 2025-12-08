using System.Collections.Generic;
using System.Text;

namespace case4.Models;

public class Frota
{
    public List<Veiculo> FrotaVeiculos { get; }

    public Frota()
    {
        FrotaVeiculos = new List<Veiculo>();
    }

    public void AdicionarVeiculo(Veiculo veiculo)
    {
        FrotaVeiculos.Add(veiculo);
    }

    public string ObterRelatorioFrota()
    {
        StringBuilder sb = new StringBuilder();

        if (FrotaVeiculos.Count == 0)
        {
            sb.AppendLine("A frota está vazia.");
            return sb.ToString();
        }

        sb.AppendLine("Relatório da Frota:");
        var veiculoAgrupado = FrotaVeiculos.GroupBy(v => v.TipoVeiculo)
            .ToDictionary(g => g.Key, g => g.ToList());

        foreach (var veiculo in veiculoAgrupado)
        {
            sb.AppendLine($"\nTipo de Veículo: {veiculo.Key}");
            foreach (var v in veiculo.Value)
            {
                sb.AppendLine($"Veículo: {v.Nome}");
                sb.AppendLine($"Marca: {v.Marca}");
                sb.AppendLine($"Ano: {v.Ano}");
                sb.AppendLine($"Consumo de Combustível: {v.CalcularConsumoCombustivel():F2} km/l");
            }
        }
        return sb.ToString();
    }
}
