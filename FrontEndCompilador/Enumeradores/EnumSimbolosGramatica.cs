namespace FrontEndCompilador.Enumeradores
{
    public enum EnumSimbolosGramatica
    {
        // TERMINAIS:
        Programa,
        AbreParenteses,
        FechaParenteses,
        Identificador,
        AbreBloco, // /*
        FechaBloco, // */
        TipoInt,
        TipoChar,
        TipoFloat,
        AtribuicaoTipo, // ->
        Virgula,
        PontoVirgula,
        Se,
        Entao,
        Senao,
        Comentario, // %comentario%
        Enquanto,
        Faca,
        Repita,
        Ate,
        AtribuicaoValor, // <-
        OperadorRelacionalEq,
        OperadorRelacionalNe,
        OperadorRelacionalLt,
        OperadorRelacionalGt,
        OperadorRelacionalLe,
        OperadorRelacionalGe,
        Soma, // +
        Subtracao, // -
        Multiplicacao, // *
        Divisao, // /
        Exponenciacao, // ^
        Separadores,
        ConstanteInt,
        ConstanteChar, // ''
        ConstanteFloat,
        // NÃO-TERMINAIS:
        CodigoPrograma,
        InicioCodigo,
        Bloco,
        DeclaracaoVariavel,
        Tipo,
        ListaIdentificador,
        SequenciaComandos,
        ListaComando,
        Comando,
        ComandoSe,
        ComandoSenao,
        ComandoBloco,
        Condicao,
        Relop,
        Expressao,
        Expressaol,
        Termo,
        Termol,
        Expoente,
        Expoentel,
        Fator,
        Operando,
        Constante
    }

    public static class ExtensoesEnumSimbolosGramatica
    {
        public static bool EhTerminal(this EnumSimbolosGramatica simbolo){
            return simbolo < EnumSimbolosGramatica.CodigoPrograma;
        }
    }
}
