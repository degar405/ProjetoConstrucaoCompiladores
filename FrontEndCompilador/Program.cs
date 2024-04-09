using FrontEndCompilador;

while (true)
{
    Console.WriteLine("Escolha opção 1 para utilizar apenas a Análise Léxica, opção 2 para utilizar a Análise Sintática e 0 para sair.");
    string opcaoUsuario = Console.ReadLine() ?? string.Empty;
    Console.WriteLine();

    if (opcaoUsuario == "0")
        break;
    if (opcaoUsuario == "1")
        ProjetoParte1.ExecutaProjeto();
    else if (opcaoUsuario == "2")
        ProjetoParte2.ExecutaProjeto();
    else
        Console.WriteLine("Por favor, escolha uma opção válida.");

    Console.WriteLine();
}

Console.WriteLine("Programa finalizado.");