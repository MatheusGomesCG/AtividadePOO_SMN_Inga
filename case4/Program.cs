using case4.Models;

namespace case4;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Sistema de Gerenciamento de Frota de Veículos ===\n");

        // Criar uma frota
        Frota frota = new Frota();

        // Teste 1: Criar e adicionar carros à frota
        Console.WriteLine("--- Teste 1: Adicionar Carros ---");
        var carro1 = new Carro("Civic", "Honda", 2023, 4);
        var carro2 = new Carro("Corolla", "Toyota", 2022, 4);
        var carro3 = new Carro("HB20", "Hyundai", 2024, 2);

        AdicionarVeiculoComValidacao(frota, carro1);
        AdicionarVeiculoComValidacao(frota, carro2);
        AdicionarVeiculoComValidacao(frota, carro3);
        Console.WriteLine();

        // Teste 2: Criar e adicionar motos à frota
        Console.WriteLine("--- Teste 2: Adicionar Motos ---");
        var moto1 = new Moto("CB 500", "Honda", 2023, 500);
        var moto2 = new Moto("Ninja 300", "Kawasaki", 2022, 300);
        var moto3 = new Moto("CG 160", "Honda", 2024, 160);

        AdicionarVeiculoComValidacao(frota, moto1);
        AdicionarVeiculoComValidacao(frota, moto2);
        AdicionarVeiculoComValidacao(frota, moto3);
        Console.WriteLine();

        // Teste 3: Criar e adicionar caminhões à frota
        Console.WriteLine("--- Teste 3: Adicionar Caminhões ---");
        var caminhao1 = new Caminhao("FH 540", "Volvo", 2023, 25000);
        var caminhao2 = new Caminhao("Constellation", "Volkswagen", 2022, 15000);
        var caminhao3 = new Caminhao("Actros", "Mercedes-Benz", 2024, 30000);

        AdicionarVeiculoComValidacao(frota, caminhao1);
        AdicionarVeiculoComValidacao(frota, caminhao2);
        AdicionarVeiculoComValidacao(frota, caminhao3);
        Console.WriteLine();

        // Teste 4: Exibir relatório completo da frota
        Console.WriteLine("--- Teste 4: Relatório Completo da Frota ---");
        Console.WriteLine(frota.ObterRelatorioFrota());
        Console.WriteLine(new string('=', 60) + "\n");

        // Teste 5: Análise detalhada de consumo de combustível
        Console.WriteLine("--- Teste 5: Análise de Consumo de Combustível ---");
        Console.WriteLine("\nCarros:");
        ExibirDetalhesVeiculo(carro1);
        ExibirDetalhesVeiculo(carro2);
        ExibirDetalhesVeiculo(carro3);

        Console.WriteLine("\nMotos:");
        ExibirDetalhesVeiculo(moto1);
        ExibirDetalhesVeiculo(moto2);
        ExibirDetalhesVeiculo(moto3);

        Console.WriteLine("\nCaminhões:");
        ExibirDetalhesVeiculo(caminhao1);
        ExibirDetalhesVeiculo(caminhao2);
        ExibirDetalhesVeiculo(caminhao3);
        Console.WriteLine();

        // Teste 6: Validação - Carro com nome vazio
        Console.WriteLine("--- Teste 6: Validação - Carro com Nome Vazio ---");
        var carroInvalido1 = new Carro("", "Ford", 2023, 4);
        AdicionarVeiculoComValidacao(frota, carroInvalido1);
        Console.WriteLine();

        // Teste 7: Validação - Moto com ano inválido
        Console.WriteLine("--- Teste 7: Validação - Moto com Ano Inválido ---");
        var motoInvalida = new Moto("Titan", "Honda", 2030, 160);
        AdicionarVeiculoComValidacao(frota, motoInvalida);
        Console.WriteLine();

        // Teste 8: Validação - Caminhão com capacidade de carga inválida
        Console.WriteLine("--- Teste 8: Validação - Caminhão com Capacidade Inválida ---");
        var caminhaoInvalido = new Caminhao("Scania R450", "Scania", 2023, -5000);
        AdicionarVeiculoComValidacao(frota, caminhaoInvalido);
        Console.WriteLine();

        // Teste 9: Validação - Carro com número de portas inválido
        Console.WriteLine("--- Teste 9: Validação - Carro com Portas Inválidas ---");
        var carroInvalido2 = new Carro("Gol", "Volkswagen", 2023, 0);
        AdicionarVeiculoComValidacao(frota, carroInvalido2);
        Console.WriteLine();

        // Teste 10: Validação - Múltiplos erros
        Console.WriteLine("--- Teste 10: Validação - Múltiplos Erros ---");
        var veiculoMultiplosErros = new Moto("", "", 1800, -100);
        AdicionarVeiculoComValidacao(frota, veiculoMultiplosErros);
        Console.WriteLine();

        // Teste 11: Estatísticas da frota
        Console.WriteLine("--- Teste 11: Estatísticas da Frota ---");
        ExibirEstatisticasFrota(frota);
        Console.WriteLine();

        // Teste 12: Comparação de eficiência entre veículos
        Console.WriteLine("--- Teste 12: Comparação de Eficiência ---");
        var veiculosParaComparar = new List<Veiculo> { carro1, moto1, caminhao1 };
        CompararEficiencia(veiculosParaComparar);
        Console.WriteLine();

        // Teste 13: Veículos mais e menos eficientes
        Console.WriteLine("--- Teste 13: Veículos Mais e Menos Eficientes ---");
        IdentificarVeiculosExtremos(frota);
        Console.WriteLine();

        // Teste 14: Frota vazia
        Console.WriteLine("--- Teste 14: Relatório de Frota Vazia ---");
        var frotaVazia = new Frota();
        Console.WriteLine(frotaVazia.ObterRelatorioFrota());
        Console.WriteLine();

        Console.WriteLine("=== Fim dos Testes ===");
    }

    static void AdicionarVeiculoComValidacao(Frota frota, Veiculo veiculo)
    {
        var (erros, isValid) = veiculo.IsValid();
        
        if (isValid)
        {
            frota.AdicionarVeiculo(veiculo);
            Console.WriteLine($"✓ {veiculo.TipoVeiculo} adicionado: {veiculo.Nome} - {veiculo.Marca} ({veiculo.Ano})");
        }
        else
        {
            Console.WriteLine($"✗ Falha ao adicionar {veiculo.TipoVeiculo}: {veiculo.Nome}");
            foreach (var erro in erros)
            {
                Console.WriteLine($"  - {erro}");
            }
        }
    }

    static void ExibirDetalhesVeiculo(Veiculo veiculo)
    {
        Console.WriteLine($"  {veiculo.Nome} ({veiculo.Marca} - {veiculo.Ano}):");
        
        if (veiculo is Carro carro)
        {
            Console.WriteLine($"    Portas: {carro.NumeroPortas}");
        }
        else if (veiculo is Moto moto)
        {
            Console.WriteLine($"    Cilindradas: {moto.Cilindradas}cc");
        }
        else if (veiculo is Caminhao caminhao)
        {
            Console.WriteLine($"    Capacidade de Carga: {caminhao.CapacidadeCarga}kg");
        }
        
        Console.WriteLine($"    Consumo: {veiculo.CalcularConsumoCombustivel():F2} km/l");
    }

    static void ExibirEstatisticasFrota(Frota frota)
    {
        var veiculos = frota.FrotaVeiculos;
        
        if (veiculos.Count == 0)
        {
            Console.WriteLine("Frota vazia. Não há estatísticas para exibir.");
            return;
        }

        var totalCarros = veiculos.Count(v => v.TipoVeiculo == case4.Enum.TipoVeiculoEnum.Carro);
        var totalMotos = veiculos.Count(v => v.TipoVeiculo == case4.Enum.TipoVeiculoEnum.Moto);
        var totalCaminhoes = veiculos.Count(v => v.TipoVeiculo == case4.Enum.TipoVeiculoEnum.Caminhao);
        
        Console.WriteLine($"Total de Veículos: {veiculos.Count}");
        Console.WriteLine($"  - Carros: {totalCarros}");
        Console.WriteLine($"  - Motos: {totalMotos}");
        Console.WriteLine($"  - Caminhões: {totalCaminhoes}");
        
        var consumoMedio = veiculos.Average(v => v.CalcularConsumoCombustivel());
        Console.WriteLine($"\nConsumo Médio da Frota: {consumoMedio:F2} km/l");
        
        var anoMaisAntigo = veiculos.Min(v => v.Ano);
        var anoMaisRecente = veiculos.Max(v => v.Ano);
        Console.WriteLine($"Ano mais antigo: {anoMaisAntigo}");
        Console.WriteLine($"Ano mais recente: {anoMaisRecente}");
    }

    static void CompararEficiencia(List<Veiculo> veiculos)
    {
        Console.WriteLine("Comparação de consumo de combustível:");
        var veiculosOrdenados = veiculos.OrderByDescending(v => v.CalcularConsumoCombustivel()).ToList();
        
        for (int i = 0; i < veiculosOrdenados.Count; i++)
        {
            var v = veiculosOrdenados[i];
            Console.WriteLine($"{i + 1}º. {v.TipoVeiculo} - {v.Nome}: {v.CalcularConsumoCombustivel():F2} km/l");
        }
    }

    static void IdentificarVeiculosExtremos(Frota frota)
    {
        var veiculos = frota.FrotaVeiculos;
        
        if (veiculos.Count == 0)
        {
            Console.WriteLine("Frota vazia.");
            return;
        }

        var veiculoMaisEficiente = veiculos.OrderByDescending(v => v.CalcularConsumoCombustivel()).First();
        var veiculoMenosEficiente = veiculos.OrderBy(v => v.CalcularConsumoCombustivel()).First();
        
        Console.WriteLine("Veículo MAIS eficiente:");
        Console.WriteLine($"  {veiculoMaisEficiente.TipoVeiculo} - {veiculoMaisEficiente.Nome} ({veiculoMaisEficiente.Marca})");
        Console.WriteLine($"  Consumo: {veiculoMaisEficiente.CalcularConsumoCombustivel():F2} km/l");
        
        Console.WriteLine("\nVeículo MENOS eficiente:");
        Console.WriteLine($"  {veiculoMenosEficiente.TipoVeiculo} - {veiculoMenosEficiente.Nome} ({veiculoMenosEficiente.Marca})");
        Console.WriteLine($"  Consumo: {veiculoMenosEficiente.CalcularConsumoCombustivel():F2} km/l");
    }
}
