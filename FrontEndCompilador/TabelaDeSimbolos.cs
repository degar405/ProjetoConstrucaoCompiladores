using FrontEndCompilador.Enumeradores;

namespace FrontEndCompilador
{
    public class Simbolo
    {
        public uint Id { get; }
        public EnumToken TipoToken { get; }
        public string Lexema { get; }
        public object? Valor { get; }
        public string? Tipo { get; }

        public Simbolo(EnumToken tipoToken, string lexema, object? valor, string? tipo, uint id)
        {
            Id = id;
            TipoToken = tipoToken;
            Lexema = lexema;
            Valor = valor;
            Tipo = tipo;
        }

        public override string ToString()
        {
            return $"ID: {Id}; Token: {TipoToken}; Atributo: {Lexema}; Valor: {Valor}; Tipo: {Tipo}";
        }
    }

    public class TabelaDeSimbolos
    {
        private List<Simbolo> Tabela = new();
        private uint ProximoId = 1;

        public void InsereSimbolo(EnumToken tipoToken, string lexema, object? valor, string? tipo)
        {
            Tabela.Add(new Simbolo(tipoToken, lexema, valor, tipo, ProximoId));
            ProximoId++;
        }

        public Simbolo? ConsultaSimbolo(EnumToken tipoToken, string? lexema, object? valor = null)
        {
            return Tabela.FirstOrDefault(simbolo => simbolo.TipoToken == tipoToken && (simbolo.Lexema == lexema || simbolo.Valor == valor));
        }

        public Simbolo ConsultaSimbolo(uint id)
        {
            return Tabela.First(simbolo => simbolo.Id == id);
        }

        public void ImprimeTabela()
        {
            foreach (Simbolo simbolo in Tabela)
            {
                Console.WriteLine(simbolo);
            }
        }
    }
}
