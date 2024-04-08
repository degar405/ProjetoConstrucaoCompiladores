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
                new(2, [EnumSimbolosGramatica.Programa, EnumSimbolosGramatica.Identificador, EnumSimbolosGramatica.AbreParenteses, EnumSimbolosGramatica.FechaParenteses])
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
