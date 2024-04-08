using FrontEndCompilador.Enumeradores;

namespace FrontEndCompilador.AnaliseSintatica
{
    public class TabelaDeProducoes
    {
        private readonly List<Producao> producoes;

        public TabelaDeProducoes()
        {
            producoes = new List<Producao>()
            {
                new(1, [EnumSimbolosGramatica.InicioCodigo, EnumSimbolosGramatica.Bloco]),
                new(2, [EnumSimbolosGramatica.Programa, EnumSimbolosGramatica.Identificador, EnumSimbolosGramatica.AbreParenteses, EnumSimbolosGramatica.FechaParenteses]),
                new(3, [EnumSimbolosGramatica.AbreBloco, EnumSimbolosGramatica.DeclaracaoVariavel, EnumSimbolosGramatica.SequenciaComandos, EnumSimbolosGramatica.FechaBloco]),
                new(4, [EnumSimbolosGramatica.Tipo, EnumSimbolosGramatica.AtribuicaoTipo, EnumSimbolosGramatica.Identificador, EnumSimbolosGramatica.ListaIdentificador, EnumSimbolosGramatica.PontoVirgula, EnumSimbolosGramatica.DeclaracaoVariavel]),
                new(5, []),
                new(6, [EnumSimbolosGramatica.TipoChar]),
                new(7, [EnumSimbolosGramatica.TipoFloat]),
                new(8, [EnumSimbolosGramatica.TipoInt]),
                new(9, [EnumSimbolosGramatica.Virgula, EnumSimbolosGramatica.Identificador, EnumSimbolosGramatica.ListaIdentificador]),
                new(10, []),
                new(11, [EnumSimbolosGramatica.Comando, EnumSimbolosGramatica.ListaComando]),
                new(12, [EnumSimbolosGramatica.Comando, EnumSimbolosGramatica.ListaComando]),
                new(13, []),
                new(14, [EnumSimbolosGramatica.Comando]),
                new(15, [EnumSimbolosGramatica.Bloco]),
                new(16, [EnumSimbolosGramatica.ComandoSe]),
                new(17, [EnumSimbolosGramatica.Enquanto, EnumSimbolosGramatica.Condicao, EnumSimbolosGramatica.Faca, EnumSimbolosGramatica.ComandoBloco]),
                new(18, [EnumSimbolosGramatica.Repita, EnumSimbolosGramatica.ComandoBloco, EnumSimbolosGramatica.Ate, EnumSimbolosGramatica.Condicao]),
                new(19, [EnumSimbolosGramatica.Identificador, EnumSimbolosGramatica.AtribuicaoValor, EnumSimbolosGramatica.Expressao]),
                new(20, [EnumSimbolosGramatica.Se, EnumSimbolosGramatica.Condicao, EnumSimbolosGramatica.Entao, EnumSimbolosGramatica.ComandoBloco, EnumSimbolosGramatica.ComandoSenao]),
                new(21, [EnumSimbolosGramatica.Senao, EnumSimbolosGramatica.ComandoBloco]),
                new(22, []),
                new(23, [EnumSimbolosGramatica.Operando, EnumSimbolosGramatica.Relop, EnumSimbolosGramatica.Operando]),
                new(24, [EnumSimbolosGramatica.OperadorRelacionalEq]),
                new(25, [EnumSimbolosGramatica.OperadorRelacionalNe]),
                new(26, [EnumSimbolosGramatica.OperadorRelacionalLt]),
                new(27, [EnumSimbolosGramatica.OperadorRelacionalGt]),
                new(28, [EnumSimbolosGramatica.OperadorRelacionalLe]),
                new(29, [EnumSimbolosGramatica.OperadorRelacionalGe]),
                new(30, [EnumSimbolosGramatica.Termo, EnumSimbolosGramatica.Expressaol]),
                new(31, [EnumSimbolosGramatica.Soma, EnumSimbolosGramatica.Termo, EnumSimbolosGramatica.Expressaol]),
                new(32, [EnumSimbolosGramatica.Subtracao, EnumSimbolosGramatica.Termo, EnumSimbolosGramatica.Expressaol]),
                new(33, []),
                new(34, [EnumSimbolosGramatica.Expoente, EnumSimbolosGramatica.Termol]),
                new(35, [EnumSimbolosGramatica.Multiplicacao, EnumSimbolosGramatica.Expoente, EnumSimbolosGramatica.Termol]),
                new(36, [EnumSimbolosGramatica.Divisao, EnumSimbolosGramatica.Expoente, EnumSimbolosGramatica.Termol]),
                new(37, []),
                new(38, [EnumSimbolosGramatica.Fator, EnumSimbolosGramatica.Expoentel]),
                new(39, [EnumSimbolosGramatica.Exponenciacao, EnumSimbolosGramatica.Fator, EnumSimbolosGramatica.Expoentel]),
                new(40, []),
                new(41, [EnumSimbolosGramatica.Expressao]),
                new(42, [EnumSimbolosGramatica.Operando]),
                new(43, [EnumSimbolosGramatica.Identificador]),
                new(44, [EnumSimbolosGramatica.Constante]),
                new(45, [EnumSimbolosGramatica.ConstanteInt]),
                new(46, [EnumSimbolosGramatica.ConstanteChar]),
                new(47, [EnumSimbolosGramatica.ConstanteFloat]),
            };
        }

        public List<EnumSimbolosGramatica>? ObterProducao(int idProducao)
        {
            return producoes.FirstOrDefault(x => x.Id == idProducao)?.CorpoProducao;
        }
    }

    public class Producao
    {
        public int Id { get; set; }
        public List<EnumSimbolosGramatica> CorpoProducao { get; set; }

        public Producao (int id, List<EnumSimbolosGramatica> corpoProducao)
        {
            Id = id;
            CorpoProducao = corpoProducao;
        }
    }
}
