using FrontEndCompilador;
using FrontEndCompilador.AnaliseLexica;
using FrontEndCompilador.AnaliseSintatica;
using FrontEndCompilador.Enumeradores;

var tabelaProducoes = new TabelaDeProducoes();
var tabelaAnalise = new TabelaDeAnalisePreditiva();

var t = tabelaAnalise.ObterIdProducao(EnumSimbolosGramatica.CodigoPrograma, EnumSimbolosGramatica.Programa);
var teste = tabelaProducoes.ObterProducao(t ?? 0);

var t2 = tabelaAnalise.ObterIdProducao(EnumSimbolosGramatica.Constante, EnumSimbolosGramatica.ConstanteFloat);
var teste2 = tabelaProducoes.ObterProducao(t2 ?? 0);

var x = 10;