using System.Globalization;
using CalculadoraIMC.Models;
using CalculadoraIMC.Services;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Calculadora de IMC ===");

        Console.Write("Digite o nome da pessoa: ");
        string nome = (Console.ReadLine() ?? string.Empty).Trim();
        if (string.IsNullOrWhiteSpace(nome))
            nome = "Pessoa";

        double peso = LerNumeroPositivo("Digite o peso (kg): ");
        double alturaCm = LerNumeroPositivo("Digite a altura (cm): ");
        double altura = alturaCm / 100d;

        if (alturaCm > 300)
        {
            Console.WriteLine("Altura inválida. Informe a altura em centímetros (ex.: 175).");
            return;
        }

        var pessoa = new Pessoa(nome, peso, altura);
        var calculadora = new ServicoCalculadoraIMC();

        double imc = calculadora.Calcular(pessoa);
        string classificacao = calculadora.Classificar(imc);

        Console.WriteLine($"\n{pessoa.Nome}, seu IMC é {imc:F2} ({classificacao}).");
        Console.WriteLine("O IMC é apenas uma estimativa e não substitui uma avaliação profissional de saúde.");
    }

    private static double LerNumeroPositivo(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            string entrada = (Console.ReadLine() ?? string.Empty).Trim();

            bool valido =
                double.TryParse(entrada, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out double valor) ||
                double.TryParse(entrada.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out valor);

            if (valido && double.IsFinite(valor) && valor > 0)
                return valor;

            Console.WriteLine("Valor inválido. Digite um número maior que zero; decimais podem usar vírgula ou ponto.");
        }
    }
}
