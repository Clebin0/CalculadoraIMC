using CalculadoraIMC.Models;
using CalculadoraIMC.Utils;

namespace CalculadoraIMC.Services
{
    public class ServicoCalculadoraIMC
    {
        public double Calcular(Pessoa pessoa)
        {
            return pessoa.Peso / (pessoa.Altura * pessoa.Altura);
        }

        public string Classificar(double imc)
        {
            return ClassificadorIMC.Classificar(imc);
        }
    }
}
