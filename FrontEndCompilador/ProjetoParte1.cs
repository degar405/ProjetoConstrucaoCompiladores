using FrontEndCompilador.AnaliseLexica;
using FrontEndCompilador.Enumeradores;

namespace FrontEndCompilador
{
    public static class ProjetoParte1
    {
        public static void ExecutaProjeto()
        {
            TratamentoDeErro tratamentoDeErro = new();
            TabelaDeSimbolos tabelaDeSimbolos = new();

            Console.WriteLine("Análise Léxica.");
            Console.WriteLine("Forneça o caminho do código-fonte.");
            string caminhoCodigoFonte = Console.ReadLine() ?? string.Empty;
            AnalisadorLexico analisadorLexico = new(tabelaDeSimbolos, tratamentoDeErro, caminhoCodigoFonte);

            Console.WriteLine("");
            Console.WriteLine("Início da execução do programa.");

            while (true)
            {
                Token? token = analisadorLexico.ObtemProximoToken();
                if (token == null)
                {
                    Console.WriteLine("Análise léxica finalizada.");
                    break;
                }

                List<EnumToken> tokensTabelaSimbolos = new() { EnumToken.Identificador, EnumToken.ConstanteInt, EnumToken.ConstanteFloat, EnumToken.ConstanteChar };
                string complementoAtributo = string.Empty;

                if (tokensTabelaSimbolos.Contains(token.TipoToken))
                    complementoAtributo = $" - ID: {(uint)(token.Atributo ?? 0)}";

                if (token.TipoToken == EnumToken.OperadorRelacional)
                    complementoAtributo = $" - {(string)(token.Atributo ?? string.Empty)}";
                Console.WriteLine($"Token devolvido na iteração: {token.TipoToken}{complementoAtributo}.");
            }

            Console.WriteLine();
            Console.WriteLine("Tabela de Símbolos:");

            tabelaDeSimbolos.ImprimeTabela();
        }
    }
}
