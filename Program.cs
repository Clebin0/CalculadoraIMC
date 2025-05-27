using CalculadoraIMC.Models;
using CalculadoraIMC.Services;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Calculadora de IMC ===");

        Console.Write("Digite o nome da pessoa: ");
        string nome = Console.ReadLine() ?? "";

        Console.Write("Digite o peso (kg): ");
        double peso = double.Parse(Console.ReadLine() ?? "0");

        Console.Write("Digite a altura (cm): ");
        double alturaCm = double.Parse(Console.ReadLine() ?? "0");
        double altura = alturaCm / 100;

        var pessoa = new Pessoa(nome, peso, altura);
        var calculadora = new ServicoCalculadoraIMC();

        double imc = calculadora.Calcular(pessoa);
        string classificacao = calculadora.Classificar(imc);

        Console.WriteLine($"\n{pessoa.Nome}, seu IMC é {imc:F2} ({classificacao})");
    }
}
