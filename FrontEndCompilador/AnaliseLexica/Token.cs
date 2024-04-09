using FrontEndCompilador.Enumeradores;

namespace FrontEndCompilador.AnaliseLexica
{
    public class Token
    {
        public EnumToken TipoToken { get; }
        public object? Atributo { get; }

        public Token(EnumToken tipoToken, object? atributo = null)
        {
            TipoToken = tipoToken;
            Atributo = atributo; 
        }

        public EnumSimbolosGramatica? ObterSimboloDaGramaticaEquivalente()
        {
            if (TipoToken == EnumToken.OperadorRelacional)
            {
                switch (Atributo)
                {
                    case "EQ":
                        return EnumSimbolosGramatica.OperadorRelacionalEq;
                    case "NE":
                        return EnumSimbolosGramatica.OperadorRelacionalNe;
                    case "LT":
                        return EnumSimbolosGramatica.OperadorRelacionalLt;
                    case "GT":
                        return EnumSimbolosGramatica.OperadorRelacionalGt;
                    case "LE":
                        return EnumSimbolosGramatica.OperadorRelacionalLe;
                    case "GE":
                        return EnumSimbolosGramatica.OperadorRelacionalGe;
                }
            }

            var listaEnumerador = ((EnumSimbolosGramatica[])Enum.GetValues(typeof(EnumSimbolosGramatica))).Where(x => x.EhTerminal());
            return listaEnumerador.FirstOrDefault(x => TipoToken.ToString() == x.ToString());
        }
    }
}
