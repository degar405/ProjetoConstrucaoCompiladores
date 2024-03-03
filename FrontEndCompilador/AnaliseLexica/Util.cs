using FrontEndCompilador.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndCompilador.AnaliseLexica
{
    public class Util
    {
        public Dictionary<string, EnumToken> PalavraChaveToken = new()
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
    }
}