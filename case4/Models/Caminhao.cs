using case4.Enum;

namespace case4.Models;

public class Caminhao : Veiculo
{
    public int CapacidadeCarga { get; }
    public override TipoVeiculoEnum TipoVeiculo => TipoVeiculoEnum.Caminhao;
    
    public Caminhao(string nome, string marca, int ano, int capacidadeCarga) : base(nome, marca, ano)
    {
        CapacidadeCarga = capacidadeCarga;
    }

    public override decimal CalcularConsumoCombustivel()
    {
        return 5 / (CapacidadeCarga / 1000m);
    }

    public override (List<string>, bool) IsValid()
    {
        (List<string> erros, bool isValid) = base.IsValid();
        if (CapacidadeCarga <= 0)
            erros.Add("A capacidade de carga do caminhão deve ser maior que zero.");
        return (erros, erros.Count == 0);
    }
}
