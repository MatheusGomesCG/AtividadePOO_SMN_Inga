using case1.Model;

Console.WriteLine("\n=== Operações de depósito ===\n");
var conta = new Conta(1,2,"Carlos Oliveira", "98765432100");

Console.WriteLine("Depositando R$ 1000,00...");
conta.Depositar(1000m);
Console.WriteLine($"Saldo atual: {conta.ExibirSaldo():C}");

Console.WriteLine("Depositando R$ 500,00...");
conta.Depositar(500m);
Console.WriteLine($"Saldo atual: {conta.ExibirSaldo():C}");
Console.WriteLine("Tentando depositar valor negativo (-100,00)...");
conta.Depositar(-100m);
Console.WriteLine($"Saldo atual: {conta.ExibirSaldo():C}\n");

Console.WriteLine("\n=== Operações de saque ===\n");
Console.WriteLine("Sacando R$ 300,00...");
conta.Sacar(300m);
Console.WriteLine($"Saldo atual: {conta.ExibirSaldo():C}");

Console.WriteLine("Sacando R$ 200,00...");
conta.Sacar(200m);
Console.WriteLine($"Saldo atual: {conta.ExibirSaldo():C}");
Console.WriteLine("Tentando sacar R$ 5000,00 (saldo insuficiente)...");
conta.Sacar(5000m);
Console.WriteLine($"Saldo atual: {conta.ExibirSaldo():C}");

Console.WriteLine("Tentando sacar valor negativo (-50,00)...");
conta.Sacar(-50m);
Console.WriteLine($"Saldo atual: {conta.ExibirSaldo():C}\n");
Console.WriteLine("\n=== Extrato ordenado por valor (decrescente) ===\n");
Console.WriteLine($"{conta.ExibirExtrato()}");


Console.WriteLine("\n=== Extrato agrupado por tipo de movimentação ===\n");
Console.WriteLine($"{conta.ExtratoPorTipo()}");
