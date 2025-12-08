using System.Text;
using case4.Enum;

namespace case4.Models;

public abstract class Veiculo(string nome, string marca, int ano)
{
    public string Nome { get; } = nome;
    public string Marca { get; } = marca;
    public int Ano { get; } = ano;
    public abstract TipoVeiculoEnum TipoVeiculo { get; }

    public virtual (List<string>, bool) IsValid()
    {
        List<string> erros = new List<string>();
        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O nome do veículo não pode ser vazio.");
        if (string.IsNullOrWhiteSpace(Marca))
            erros.Add("A marca do veículo não pode ser vazia.");
        if (Ano < 1886 || Ano > DateTime.Now.Year)
            erros.Add("O ano do veículo é inválido.");
        return (erros, erros.Count == 0);
    }
    public abstract decimal CalcularConsumoCombustivel();
}
