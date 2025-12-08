using case4.Enum;

namespace case4.Models;

public class Carro(string nome, string marca, int ano, int numeroPortas) : Veiculo(nome, marca, ano)
{
    public int NumeroPortas { get; } = numeroPortas;
    public override TipoVeiculoEnum TipoVeiculo => TipoVeiculoEnum.Carro;

    public override decimal CalcularConsumoCombustivel() => 16 - NumeroPortas;
    
    public override List<string> IsValid()
    {
        var erros = base.IsValid();

        if (NumeroPortas <= 0)
            erros.Add("O número de portas do carro deve ser maior que zero.");

        return erros;
    }
}
