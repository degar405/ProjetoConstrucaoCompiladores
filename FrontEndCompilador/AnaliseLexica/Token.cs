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
    }
}
