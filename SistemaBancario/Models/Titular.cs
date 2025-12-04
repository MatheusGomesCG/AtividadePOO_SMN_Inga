using System.Text.RegularExpressions;

namespace SistemaBancario.Models;

public class Titular
{
    public string Nome { get; }
    public string Cpf { get; }

    public Titular(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
    }

    public bool IsValid()
    {
        if (string.IsNullOrWhiteSpace(Nome))
        {
            Console.WriteLine("O nome do titular não pode ser vazio.");
            return false;
        }

        if (!Regex.IsMatch(Cpf, @"^(\d{3}\.?){2}\d{3}-?\d{2}$"))
        {
            Console.WriteLine("O CPF do titular é inválido.");
            return false;
        }

        return true;
    }
}
