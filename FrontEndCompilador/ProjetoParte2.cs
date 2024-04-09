using FrontEndCompilador.AnaliseLexica;
using FrontEndCompilador.AnaliseSintatica;
using FrontEndCompilador.Enumeradores;

namespace FrontEndCompilador
{
    public static class ProjetoParte2
    {
        public static void ExecutaProjeto()
        {
            Console.WriteLine("Análise Sintática.");
            Console.WriteLine("Forneça o caminho do código-fonte.");
            string caminhoCodigoFonte = Console.ReadLine() ?? string.Empty;

            Console.WriteLine();
            Console.WriteLine("Início da execução do programa.");
            Console.WriteLine();

            using (AnalisadorSintatico analisadorSintatico = new(caminhoCodigoFonte))
            {
                bool resultado = analisadorSintatico.AnalisarCodigoFonte();
                if (resultado)
                    Console.WriteLine("Código-fonte está adequado à sintaxe da linguagem.");
            }
        }
    }
}
