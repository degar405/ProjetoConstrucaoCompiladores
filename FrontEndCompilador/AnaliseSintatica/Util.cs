using FrontEndCompilador.Enumeradores;

namespace FrontEndCompilador.AnaliseSintatica
{
    public static class Util
    {
        public static void IncorporarProducao(this Stack<EnumSimbolosGramatica> pilha, List<EnumSimbolosGramatica> producao)
        {
            Stack<EnumSimbolosGramatica> pilhaProducao = new(producao);

            while (pilhaProducao.Count > 0)
                pilha.Push(pilhaProducao.Pop());
        }
    }
}
