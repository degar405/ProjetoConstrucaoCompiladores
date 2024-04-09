using FrontEndCompilador.Enumeradores;
using System.Text.RegularExpressions;

namespace FrontEndCompilador.AnaliseLexica
{
    public class AnalisadorLexico : IDisposable
    {
        private TabelaDeSimbolos _tabelaDeSimbolos;
        private TratamentoDeErro _tratamentoDeErro;
        private StreamReader _stream;
        private int _linha = 1;
        private int _coluna = 0;
        private bool _ultimoCharLidoQuebraDeLinha = false;
        private char _char;

        private bool _tratarLookahead = false;


        public AnalisadorLexico(TabelaDeSimbolos tabelaDeSimbolos, TratamentoDeErro tratamentoDeErro, string caminhoArquivo)
        {
            _tabelaDeSimbolos = tabelaDeSimbolos;
            _tratamentoDeErro = tratamentoDeErro;
            _stream = new StreamReader(caminhoArquivo);
        }

        public Token? ObtemProximoToken()
        {
            int estado = 0;
            char charAtual;
            string lexema = String.Empty;
            Simbolo? simbolo;
            bool sucessoConversao;
            while (true)
            {
                switch (estado)
                {
                    case 0:
                        charAtual = ObtemChar();

                        if (charAtual == ')')
                            estado = 1;
                        else if (charAtual == '(')
                            estado = 2;
                        else if (Regex.IsMatch(charAtual.ToString(), @"[A-Za-z_]"))
                        {
                            estado = 3;
                            lexema += charAtual;
                        }
                        else if (charAtual == '/')
                            estado = 5;
                        else if (charAtual == '*')
                            estado = 8;
                        else if (charAtual == '-')
                            estado = 11;
                        else if (charAtual == ',')
                            estado = 14;
                        else if (charAtual == ';')
                            estado = 15;
                        else if (charAtual == '%')
                            estado = 16;
                        else if (charAtual == '<')
                            estado = 18;
                        else if (charAtual == '=')
                            estado = 23;
                        else if (charAtual == '>')
                            estado = 24;
                        else if (charAtual == '+')
                            estado = 27;
                        else if (charAtual == '^')
                            estado = 28;
                        else if (Regex.IsMatch(charAtual.ToString(), @"[\s\t\n]"))
                            estado = 29;
                        else if (charAtual == '\'')
                            estado = 31;
                        else if (Regex.IsMatch(charAtual.ToString(), @"[0-9]"))
                        {
                            estado = 34;
                            lexema += charAtual;
                        }
                        else if (charAtual == '\uffff')
                            return null;
                        else
                            estado = -1;
                        break;
                    case 1:
                        return new Token(EnumToken.FechaParenteses);
                    case 2:
                        return new Token(EnumToken.AbreParenteses);
                    case 3:
                        charAtual = ObtemChar();
                        if (!Regex.IsMatch(charAtual.ToString(), @"[A-Za-z0-9_]"))
                            estado = 4;
                        else
                            lexema += charAtual;
                        break;
                    case 4:
                        _tratarLookahead = true;

                        bool ehPalavraChave = Util.PalavrasChaveToken.TryGetValue(lexema, out EnumToken tipoToken);
                        if (ehPalavraChave)
                            return new Token(tipoToken);

                        simbolo = _tabelaDeSimbolos.ConsultaSimbolo(EnumToken.Identificador, lexema);
                        if (simbolo == null)
                            simbolo = _tabelaDeSimbolos.InsereSimbolo(EnumToken.Identificador, lexema);
                        return new Token(EnumToken.Identificador, simbolo.Id);
                    case 5:
                        charAtual = ObtemChar();
                        if (charAtual == '*')
                            estado = 6;
                        else
                            estado = 7;
                        break;
                    case 6:
                        return new Token(EnumToken.AbreBloco);
                    case 7:
                        _tratarLookahead = true;
                        return new Token(EnumToken.Divisao);
                    case 8:
                        charAtual = ObtemChar();
                        if (charAtual == '/')
                            estado = 9;
                        else
                            estado = 10;
                        break;
                    case 9:
                        return new Token(EnumToken.FechaBloco);
                    case 10:
                        _tratarLookahead = true;
                        return new Token(EnumToken.Multiplicacao);
                    case 11:
                        charAtual = ObtemChar();
                        if (charAtual == '>')
                            estado = 12;
                        else
                            estado = 13;
                        break;
                    case 12:
                        return new Token(EnumToken.AtribuicaoTipo);
                    case 13:
                        _tratarLookahead = true;
                        return new Token(EnumToken.Subtracao);
                    case 14:
                        return new Token(EnumToken.Virgula);
                    case 15:
                        return new Token(EnumToken.PontoVirgula);
                    case 16:
                        charAtual = ObtemChar();
                        if (charAtual == '%')
                            estado = 17;
                        break;
                    case 17:
                        return ObtemProximoToken();
                    case 18:
                        charAtual = ObtemChar();
                        if (charAtual == '-')
                            estado = 19;
                        else if (charAtual == '=')
                            estado = 20;
                        else if (charAtual == '>')
                            estado = 21;
                        else
                            estado = 22;
                        break;
                    case 19:
                        return new Token(EnumToken.AtribuicaoValor);
                    case 20:
                        return new Token(EnumToken.OperadorRelacional, "LE");
                    case 21:
                        return new Token(EnumToken.OperadorRelacional, "NE");
                    case 22:
                        _tratarLookahead = true;
                        return new Token(EnumToken.OperadorRelacional, "LT");
                    case 23:
                        return new Token(EnumToken.OperadorRelacional, "EQ");
                    case 24:
                        charAtual = ObtemChar();
                        if (charAtual == '=')
                            estado = 25;
                        else
                            estado = 26;
                        break;
                    case 25:
                        return new Token(EnumToken.OperadorRelacional, "GE");
                    case 26:
                        _tratarLookahead = true;
                        return new Token(EnumToken.OperadorRelacional, "GT");
                    case 27:
                        return new Token(EnumToken.Soma);
                    case 28:
                        return new Token(EnumToken.Exponenciacao);
                    case 29:
                        charAtual = ObtemChar();
                        if (!Regex.IsMatch(charAtual.ToString(), @"[\s\t\n]"))
                            estado = 30;
                        break;
                    case 30:
                        _tratarLookahead = true;
                        return ObtemProximoToken();
                    case 31:
                        charAtual = ObtemChar();
                        lexema = charAtual.ToString();
                        estado = 32;
                        break;
                    case 32:
                        charAtual = ObtemChar();
                        if (charAtual == '\'')
                            estado = 33;
                        else
                            estado = -1;
                        break;
                    case 33:
                        simbolo = _tabelaDeSimbolos.ConsultaSimbolo(EnumToken.ConstanteChar, lexema);
                        if (simbolo == null)
                            simbolo = _tabelaDeSimbolos.InsereSimbolo(EnumToken.ConstanteChar, lexema, lexema[0], "char");
                        return new Token(EnumToken.ConstanteChar, simbolo.Id);
                    case 34:
                        charAtual = ObtemChar();
                        if (Regex.IsMatch(charAtual.ToString(), @"[0-9]"))
                        {
                            lexema += charAtual;
                        }
                        else if (charAtual == '.')
                        {
                            lexema += charAtual;
                            estado = 36;
                        }
                        else
                            estado = 35;
                        break;
                    case 35:
                        _tratarLookahead = true;
                        sucessoConversao = uint.TryParse(lexema, out uint valorInteiro);
                        if (!sucessoConversao || valorInteiro > 32767) 
                        {
                            estado = -1;
                            break;
                        }
                        simbolo = _tabelaDeSimbolos.ConsultaSimbolo(EnumToken.ConstanteInt, lexema, valorInteiro);
                        if (simbolo == null)
                            simbolo = _tabelaDeSimbolos.InsereSimbolo(EnumToken.ConstanteInt, lexema, valorInteiro, "uint");
                        return new Token(EnumToken.ConstanteInt, simbolo.Id);
                    case 36:
                        charAtual = ObtemChar();
                        if (Regex.IsMatch(charAtual.ToString(), @"[0-9]"))
                        {
                            lexema += charAtual;
                            estado = 37;
                        }
                        else
                        {
                            estado = -1;
                        }
                        break;
                    case 37:
                        charAtual = ObtemChar();
                        if (Regex.IsMatch(charAtual.ToString(), @"[0-9]"))
                        {
                            lexema += charAtual;
                        }
                        else if (charAtual == 'E')
                        {
                            lexema += charAtual;
                            estado = 39;
                        }
                        else
                            estado = 38;
                        break;
                    case 38:
                        _tratarLookahead = true;
                        sucessoConversao = float.TryParse(lexema.Replace('.', ','), out float valorFloat);
                        if (!sucessoConversao)
                        {
                            estado = -1;
                            break;
                        }
                        simbolo = _tabelaDeSimbolos.ConsultaSimbolo(EnumToken.ConstanteFloat, lexema, valorFloat);
                        if (simbolo == null)
                            simbolo = _tabelaDeSimbolos.InsereSimbolo(EnumToken.ConstanteFloat, lexema, valorFloat, "float");
                        return new Token(EnumToken.ConstanteFloat, simbolo.Id);
                    case 39:
                        charAtual = ObtemChar();
                        if (Regex.IsMatch(charAtual.ToString(), @"[0-9]"))
                        {
                            lexema += charAtual;
                            estado = 41;
                        }
                        else if (Regex.IsMatch(charAtual.ToString(), @"[+-]"))
                        {
                            lexema += charAtual;
                            estado = 40;
                        }
                        else
                            estado = -1;
                        break;
                    case 40:
                        charAtual = ObtemChar();
                        if (Regex.IsMatch(charAtual.ToString(), @"[0-9]"))
                        {
                            lexema += charAtual;
                            estado = 41;
                        }
                        else
                            estado = -1;
                        break;
                    case 41:
                        charAtual = ObtemChar();
                        if (Regex.IsMatch(charAtual.ToString(), @"[0-9]"))
                        {
                            lexema += charAtual;
                        }
                        else
                            estado = 42;
                        break;
                    case 42:
                        _tratarLookahead = true;
                        sucessoConversao = lexema.ConverterNotacaoCientificaFloat(out float valorFloatNC);
                        if (!sucessoConversao)
                        {
                            estado = -1;
                            break;
                        }
                        simbolo = _tabelaDeSimbolos.ConsultaSimbolo(EnumToken.ConstanteFloat, lexema, valorFloatNC);
                        if (simbolo == null)
                            simbolo = _tabelaDeSimbolos.InsereSimbolo(EnumToken.ConstanteFloat, lexema, valorFloatNC, "float");
                        return new Token(EnumToken.ConstanteFloat, simbolo.Id);
                    default:
                        _tratamentoDeErro.AcusarErro($"Erro léxico encontrado no arquivo. Referência: linha {_linha} coluna {_coluna}.");
                        return null;
                }
            }
        }

        public int ObterLinhaAtual() => _linha;

        private char ObtemChar()
        {
            if (_tratarLookahead)
            {
                _tratarLookahead = false;
                return _char;
            }

            _char = (char)_stream.Read();
            if (_ultimoCharLidoQuebraDeLinha)
            {
                _ultimoCharLidoQuebraDeLinha = false;
                _linha++;
                _coluna = 1;
            }
            else
            {
                _coluna++;
            }

            if (_char == '\n')
            {
                _ultimoCharLidoQuebraDeLinha = true;
            }

            return _char;
        }

        public void Dispose()
        {
            _stream.Dispose();
        }
    }
}
