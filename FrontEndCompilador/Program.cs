using FrontEndCompilador;
using FrontEndCompilador.AnaliseLexica;
using FrontEndCompilador.AnaliseSintatica;
using FrontEndCompilador.Enumeradores;



Console.WriteLine("Forneça o caminho do código-fonte.");
string caminhoCodigoFonte = Console.ReadLine() ?? string.Empty;
AnalisadorSintatico analisadorSintatico = new(caminhoCodigoFonte);
analisadorSintatico.AnalisarCodigoFonte();

Console.WriteLine("");
Console.WriteLine("Início da execução do programa.");