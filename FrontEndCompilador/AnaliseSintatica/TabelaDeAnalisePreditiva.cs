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
                new(EnumSimbolosGramatica.InicioCodigo, EnumSimbolosGramatica.Programa, 2),
                new(EnumSimbolosGramatica.Bloco, EnumSimbolosGramatica.AbreBloco, 3),
                new(EnumSimbolosGramatica.DeclaracaoVariavel, EnumSimbolosGramatica.TipoChar, 4),
                new(EnumSimbolosGramatica.DeclaracaoVariavel, EnumSimbolosGramatica.TipoFloat, 4),
                new(EnumSimbolosGramatica.DeclaracaoVariavel, EnumSimbolosGramatica.TipoInt, 4),
                new(EnumSimbolosGramatica.DeclaracaoVariavel, EnumSimbolosGramatica.Se, 5),
                new(EnumSimbolosGramatica.DeclaracaoVariavel, EnumSimbolosGramatica.Enquanto, 5),
                new(EnumSimbolosGramatica.DeclaracaoVariavel, EnumSimbolosGramatica.Repita, 5),
                new(EnumSimbolosGramatica.DeclaracaoVariavel, EnumSimbolosGramatica.Identificador, 5),
                new(EnumSimbolosGramatica.Tipo, EnumSimbolosGramatica.TipoChar, 6),
                new(EnumSimbolosGramatica.Tipo, EnumSimbolosGramatica.TipoFloat, 7),
                new(EnumSimbolosGramatica.Tipo, EnumSimbolosGramatica.TipoInt, 8),
                new(EnumSimbolosGramatica.ListaIdentificador, EnumSimbolosGramatica.Virgula, 9),
                new(EnumSimbolosGramatica.ListaIdentificador, EnumSimbolosGramatica.PontoVirgula, 10),
                new(EnumSimbolosGramatica.SequenciaComandos, EnumSimbolosGramatica.Se, 11),
                new(EnumSimbolosGramatica.SequenciaComandos, EnumSimbolosGramatica.Enquanto, 11),
                new(EnumSimbolosGramatica.SequenciaComandos, EnumSimbolosGramatica.Repita, 11),
                new(EnumSimbolosGramatica.SequenciaComandos, EnumSimbolosGramatica.Identificador, 11),
                new(EnumSimbolosGramatica.ListaComando, EnumSimbolosGramatica.Se, 12),
                new(EnumSimbolosGramatica.ListaComando, EnumSimbolosGramatica.Enquanto, 12),
                new(EnumSimbolosGramatica.ListaComando, EnumSimbolosGramatica.Repita, 12),
                new(EnumSimbolosGramatica.ListaComando, EnumSimbolosGramatica.Identificador, 12),
                new(EnumSimbolosGramatica.ListaComando, EnumSimbolosGramatica.FechaBloco, 13),
                new(EnumSimbolosGramatica.ComandoBloco, EnumSimbolosGramatica.Se, 14),
                new(EnumSimbolosGramatica.ComandoBloco, EnumSimbolosGramatica.Enquanto, 14),
                new(EnumSimbolosGramatica.ComandoBloco, EnumSimbolosGramatica.Repita, 14),
                new(EnumSimbolosGramatica.ComandoBloco, EnumSimbolosGramatica.Identificador, 14),
                new(EnumSimbolosGramatica.ComandoBloco, EnumSimbolosGramatica.AbreBloco, 15),
                new(EnumSimbolosGramatica.Comando, EnumSimbolosGramatica.Se, 16),
                new(EnumSimbolosGramatica.Comando, EnumSimbolosGramatica.Enquanto, 17),
                new(EnumSimbolosGramatica.Comando, EnumSimbolosGramatica.Repita, 18),
                new(EnumSimbolosGramatica.Comando, EnumSimbolosGramatica.Identificador, 19),
                new(EnumSimbolosGramatica.ComandoSe, EnumSimbolosGramatica.Se, 20),
                new(EnumSimbolosGramatica.ComandoSenao, EnumSimbolosGramatica.Senao, 21),
                new(EnumSimbolosGramatica.ComandoSenao, EnumSimbolosGramatica.Se, 22),
                new(EnumSimbolosGramatica.ComandoSenao, EnumSimbolosGramatica.Enquanto, 22),
                new(EnumSimbolosGramatica.ComandoSenao, EnumSimbolosGramatica.Repita, 22),
                new(EnumSimbolosGramatica.ComandoSenao, EnumSimbolosGramatica.Identificador, 22),
                new(EnumSimbolosGramatica.ComandoSenao, EnumSimbolosGramatica.Ate, 22),
                new(EnumSimbolosGramatica.ComandoSenao, EnumSimbolosGramatica.Senao, 22),
                new(EnumSimbolosGramatica.Condicao, EnumSimbolosGramatica.Identificador, 23),
                new(EnumSimbolosGramatica.Condicao, EnumSimbolosGramatica.ConstanteInt, 23),
                new(EnumSimbolosGramatica.Condicao, EnumSimbolosGramatica.ConstanteChar, 23),
                new(EnumSimbolosGramatica.Condicao, EnumSimbolosGramatica.ConstanteFloat, 23),
                new(EnumSimbolosGramatica.Relop, EnumSimbolosGramatica.OperadorRelacionalEq, 24),
                new(EnumSimbolosGramatica.Relop, EnumSimbolosGramatica.OperadorRelacionalNe, 25),
                new(EnumSimbolosGramatica.Relop, EnumSimbolosGramatica.OperadorRelacionalLt, 26),
                new(EnumSimbolosGramatica.Relop, EnumSimbolosGramatica.OperadorRelacionalGt, 27),
                new(EnumSimbolosGramatica.Relop, EnumSimbolosGramatica.OperadorRelacionalLe, 28),
                new(EnumSimbolosGramatica.Relop, EnumSimbolosGramatica.OperadorRelacionalGe, 29),
                new(EnumSimbolosGramatica.Expressao, EnumSimbolosGramatica.AbreParenteses, 30),
                new(EnumSimbolosGramatica.Expressao, EnumSimbolosGramatica.ConstanteInt, 30),
                new(EnumSimbolosGramatica.Expressao, EnumSimbolosGramatica.ConstanteFloat, 30),
                new(EnumSimbolosGramatica.Expressao, EnumSimbolosGramatica.ConstanteChar, 30),
                new(EnumSimbolosGramatica.Expressao, EnumSimbolosGramatica.Identificador, 30),
                new(EnumSimbolosGramatica.Expressaol, EnumSimbolosGramatica.Soma, 31),
                new(EnumSimbolosGramatica.Expressaol, EnumSimbolosGramatica.Subtracao, 32),
                new(EnumSimbolosGramatica.Expressaol, EnumSimbolosGramatica.PontoVirgula, 33),
                new(EnumSimbolosGramatica.Expressaol, EnumSimbolosGramatica.FechaParenteses, 33),
                new(EnumSimbolosGramatica.Termo, EnumSimbolosGramatica.AbreParenteses, 34),
                new(EnumSimbolosGramatica.Termo, EnumSimbolosGramatica.ConstanteInt, 34),
                new(EnumSimbolosGramatica.Termo, EnumSimbolosGramatica.ConstanteFloat, 34),
                new(EnumSimbolosGramatica.Termo, EnumSimbolosGramatica.ConstanteChar, 34),
                new(EnumSimbolosGramatica.Termo, EnumSimbolosGramatica.Identificador, 34),
                new(EnumSimbolosGramatica.Termol, EnumSimbolosGramatica.Multiplicacao, 35),
                new(EnumSimbolosGramatica.Termol, EnumSimbolosGramatica.Divisao, 36),
                new(EnumSimbolosGramatica.Termol, EnumSimbolosGramatica.Soma, 37),
                new(EnumSimbolosGramatica.Termol, EnumSimbolosGramatica.Subtracao, 37),
                new(EnumSimbolosGramatica.Termol, EnumSimbolosGramatica.PontoVirgula, 37),
                new(EnumSimbolosGramatica.Termol, EnumSimbolosGramatica.FechaParenteses, 37),
                new(EnumSimbolosGramatica.Expoente, EnumSimbolosGramatica.AbreParenteses, 38),
                new(EnumSimbolosGramatica.Expoente, EnumSimbolosGramatica.ConstanteInt, 38),
                new(EnumSimbolosGramatica.Expoente, EnumSimbolosGramatica.ConstanteFloat, 38),
                new(EnumSimbolosGramatica.Expoente, EnumSimbolosGramatica.ConstanteChar, 38),
                new(EnumSimbolosGramatica.Expoente, EnumSimbolosGramatica.Identificador, 38),
                new(EnumSimbolosGramatica.Expoentel, EnumSimbolosGramatica.Exponenciacao, 39),
                new(EnumSimbolosGramatica.Expoentel, EnumSimbolosGramatica.Divisao, 40),
                new(EnumSimbolosGramatica.Expoentel, EnumSimbolosGramatica.Soma, 40),
                new(EnumSimbolosGramatica.Expoentel, EnumSimbolosGramatica.Subtracao, 40),
                new(EnumSimbolosGramatica.Expoentel, EnumSimbolosGramatica.PontoVirgula, 40),
                new(EnumSimbolosGramatica.Expoentel, EnumSimbolosGramatica.FechaParenteses, 40),
                new(EnumSimbolosGramatica.Fator, EnumSimbolosGramatica.AbreParenteses, 41),
                new(EnumSimbolosGramatica.Fator, EnumSimbolosGramatica.ConstanteInt, 42),
                new(EnumSimbolosGramatica.Fator, EnumSimbolosGramatica.ConstanteFloat, 42),
                new(EnumSimbolosGramatica.Fator, EnumSimbolosGramatica.ConstanteChar, 42),
                new(EnumSimbolosGramatica.Fator, EnumSimbolosGramatica.Identificador, 42),
                new(EnumSimbolosGramatica.Operando, EnumSimbolosGramatica.Identificador, 43),
                new(EnumSimbolosGramatica.Operando, EnumSimbolosGramatica.ConstanteInt, 44),
                new(EnumSimbolosGramatica.Operando, EnumSimbolosGramatica.ConstanteFloat, 44),
                new(EnumSimbolosGramatica.Operando, EnumSimbolosGramatica.ConstanteChar, 44),
                new(EnumSimbolosGramatica.Constante, EnumSimbolosGramatica.ConstanteInt, 45),
                new(EnumSimbolosGramatica.Constante, EnumSimbolosGramatica.ConstanteChar, 46),
                new(EnumSimbolosGramatica.Constante, EnumSimbolosGramatica.ConstanteInt, 47),
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
