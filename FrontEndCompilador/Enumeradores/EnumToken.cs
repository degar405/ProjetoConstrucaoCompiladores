namespace FrontEndCompilador.Enumeradores
{
    public enum EnumToken
    {
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
        OperadorRelacional, // EQ, NE, LT, GT, LE, GE
        Soma, // +
        Subtracao, // -
        Multiplicacao, // *
        Divisao, // /
        Exponenciacao, // ^
        Separadores,
        ConstanteInt,
        ConstanteChar, // ''
        ConstanteFloat
    }
}
