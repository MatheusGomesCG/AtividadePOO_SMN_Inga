using SistemaVeiculos.Models;

var frota = new List<Veiculo>
{
    new Carro(4),
    new Moto(500),
    new Caminhao(12000),
    new Carro(2),
    new Moto(125),
    new Caminhao(5500)
};

var relatorioGenerator = new Relatorio();
var relatorio = relatorioGenerator.GerarRelatorioDeFrotas(frota);

Console.WriteLine(relatorio);
