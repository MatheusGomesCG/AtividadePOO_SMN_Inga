using SistemaBancario.Models;

// Criar titular
var titular = new Titular("João Silva", "123.456.789-10");

if (!titular.IsValid())
{
    Console.WriteLine("Titular inválido!");
    return;
}

// Criar conta bancária
var conta = new ContaBancaria(1, 12345, titular);

Console.WriteLine("=== TESTE DO SISTEMA BANCÁRIO ===\n");

// Fazer depósitos
Console.WriteLine("--- Depósitos ---");
conta.Depositar(1000);
Console.WriteLine($"Saldo atual: {conta.Saldo:C}\n");

conta.Depositar(500);
Console.WriteLine($"Saldo atual: {conta.Saldo:C}\n");

conta.Depositar(250);
Console.WriteLine($"Saldo atual: {conta.Saldo:C}\n");

// Tentar depósito inválido
conta.Depositar(-100);
Console.WriteLine();

// Fazer saques
Console.WriteLine("--- Saques ---");
conta.Sacar(300);
Console.WriteLine($"Saldo atual: {conta.Saldo:C}\n");

conta.Sacar(200);
Console.WriteLine($"Saldo atual: {conta.Saldo:C}\n");

// Tentar saque inválido
conta.Sacar(-50);
Console.WriteLine();

// Tentar saque maior que o saldo
conta.Sacar(5000);
Console.WriteLine();

Console.WriteLine($"Saldo final: {conta.Saldo:C}\n");

// Exibir extrato completo
Console.WriteLine("\n=== EXTRATO HISTÓRICO (ordenado por valor) ===");
conta.ExtratoHistorico();

// Exibir extrato consolidado
Console.WriteLine("\n=== EXTRATO CONSOLIDADO (agrupado por tipo) ===");
conta.ExtratoAgrupado();
