using FrontEndCompilador.Enumeradores;

namespace FrontEndCompilador.AnaliseLexica
{
    public static class Util
    {
        public static readonly Dictionary<string, EnumToken> PalavrasChaveToken = new()
        {
            {"programa", EnumToken.Programa },
            {"int", EnumToken.TipoInt },
            {"char", EnumToken.TipoChar },
            {"float", EnumToken.TipoFloat },
            {"se", EnumToken.Se },
            {"entao", EnumToken.Entao },
            {"senao", EnumToken.Senao },
            {"enquanto", EnumToken.Enquanto },
            {"faca", EnumToken.Faca },
            {"repita", EnumToken.Repita },
            {"ate", EnumToken.Ate }
        };

        public static bool ConverterNotacaoCientificaFloat(this string lexema, out float valor)
        {
            valor = 0f;
            string[] fragmentosLexema = lexema.Split(['e', 'E']);
            if (fragmentosLexema.Length != 2)
                return false;

            if (!float.TryParse(fragmentosLexema[0].Replace('.', ','), out float valorBase))
                return false;

            if (!int.TryParse(fragmentosLexema[1], out int valorExpoente))
                return false;
            
            valor = (float)(valorBase * Math.Pow(10, valorExpoente));
            return true;
        }
    }
}