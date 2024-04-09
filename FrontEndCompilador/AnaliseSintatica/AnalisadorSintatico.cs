using FrontEndCompilador.AnaliseLexica;
using FrontEndCompilador.Enumeradores;

namespace FrontEndCompilador.AnaliseSintatica
{
    public class AnalisadorSintatico : IDisposable
    {
        private readonly Stack<EnumSimbolosGramatica> pilhaDeSimbolos;
        private readonly TabelaDeSimbolos tabelaDeSimbolos;
        private readonly TratamentoDeErro tratamentoDeErro;
        private readonly AnalisadorLexico analisadorLexico;
        private readonly TabelaDeAnalisePreditiva tabelaDeAnalisePreditiva;
        private readonly TabelaDeProducoes tabelaDeProducoes;
        private bool? codigoFonteValido = null;

        public AnalisadorSintatico(string caminhoArquivo)
        {
            pilhaDeSimbolos = new();
            tabelaDeSimbolos = new();
            tratamentoDeErro = new();
            tabelaDeAnalisePreditiva = new();
            tabelaDeProducoes = new();
            analisadorLexico = new(tabelaDeSimbolos, tratamentoDeErro, caminhoArquivo);
        }

        public bool AnalisarCodigoFonte()
        {
            if (codigoFonteValido != null)
                return codigoFonteValido ?? false;

            codigoFonteValido = false;
            var simboloInicial = EnumSimbolosGramatica.CodigoPrograma;
            pilhaDeSimbolos.Push(simboloInicial);

            var proximoToken = analisadorLexico.ObtemProximoToken();
            while (pilhaDeSimbolos.Count > 0)
            {
                if (proximoToken == null && !tratamentoDeErro.ExisteErro) // $
                {
                    tratamentoDeErro.AcusarErro("Erro sintático.");
                    return false;
                }
                if (proximoToken == null && tratamentoDeErro.ExisteErro) // erro léxico
                {
                    return false;
                }

                var simboloProximoToken = proximoToken?.ObterSimboloDaGramaticaEquivalente();
                if (simboloProximoToken == null)
                {
                    tratamentoDeErro.AcusarErro("Erro sistêmico.");
                    return false;
                }

                var topo = pilhaDeSimbolos.Peek();
                if (topo.EhTerminal())
                {
                    if (simboloProximoToken != topo)
                    {
                        tratamentoDeErro.AcusarErro("Erro sintático.");
                        return false;
                    }

                    pilhaDeSimbolos.Pop();
                    proximoToken = analisadorLexico.ObtemProximoToken();
                }
                else
                {
                    var idProducao = tabelaDeAnalisePreditiva.ObterIdProducao(topo, (EnumSimbolosGramatica)simboloProximoToken);
                    var producao = tabelaDeProducoes.ObterProducao(idProducao ?? 0);

                    if (producao == null)
                    {
                        tratamentoDeErro.AcusarErro("Erro sintático.");
                        return false;
                    }

                    pilhaDeSimbolos.Pop();
                    pilhaDeSimbolos.IncorporarProducao(producao);
                }
            }

            // verificar se string acabou

            codigoFonteValido = true;
            return true;
        }

        public void Dispose()
        {
            analisadorLexico.Dispose();
        }
    }
}
