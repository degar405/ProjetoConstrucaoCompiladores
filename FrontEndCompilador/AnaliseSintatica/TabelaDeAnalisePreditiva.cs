using FrontEndCompilador.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndCompilador.AnaliseSintatica
{
    public class TabelaDeAnalisePreditiva
    {
        private readonly List<RegistroDeAnalisePreditiva> registros;

        public TabelaDeAnalisePreditiva()
        {
            registros = [
                new(EnumSimbolosGramatica.CodigoPrograma, EnumSimbolosGramatica.Programa, 1),
                new(EnumSimbolosGramatica.InicioCodigo, EnumSimbolosGramatica.Programa, 2)
            ];
        }

        public int? ObterIdProducao(EnumSimbolosGramatica simboloNaoTerminal, EnumSimbolosGramatica simboloTerminal)
        {
            return registros.FirstOrDefault(x => x.SimboloNaoTerminal == simboloNaoTerminal && x.SimboloTerminal == simboloTerminal)?.IdProducao;
        }
    }

    public class RegistroDeAnalisePreditiva
    {
        public EnumSimbolosGramatica SimboloNaoTerminal { get; set; }
        public EnumSimbolosGramatica SimboloTerminal { get; set; }
        public int IdProducao { get; set; }

        public RegistroDeAnalisePreditiva(EnumSimbolosGramatica simboloNaoTerminal, EnumSimbolosGramatica simboloTerminal, int idProducao)
        {
            SimboloNaoTerminal = simboloNaoTerminal;
            SimboloTerminal = simboloTerminal;
            IdProducao = idProducao;
        }
    }
}
