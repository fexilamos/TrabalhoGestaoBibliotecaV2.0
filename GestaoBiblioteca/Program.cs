using Figgle;
using System;
using GestaoBiblioteca;
using Spectre.Console;

namespace GestaoBiblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BibliotecaSistema bibliotecaSistema = new BibliotecaSistema();
            FuncionarioServico funcionarioServico = new FuncionarioServico();
            UtilizadorServico utilizadorServico = new UtilizadorServico();

            // Livros
            bibliotecaSistema.AdicionarLivro("1984", "George Orwell", 1949, 5);
            bibliotecaSistema.AdicionarLivro("Ensaio sobre a Cegueira", "José Saramago", 1995, 3);
            bibliotecaSistema.AdicionarLivro("Dom Quixote", "Miguel de Cervantes", 1605, 2);
            bibliotecaSistema.AdicionarLivro("O Senhor dos Anéis", "J.R.R. Tolkien", 1954, 4);
            bibliotecaSistema.AdicionarLivro("A Revolução dos Bichos", "George Orwell", 1945, 6);
            bibliotecaSistema.AdicionarLivro("O Primo Basílio", "José Maria de Eça de Queirós", 1878, 2);
            bibliotecaSistema.AdicionarLivro("A Metamorfose", "Franz Kafka", 1915, 3);
            bibliotecaSistema.AdicionarLivro("Cem Anos de Solidão", "Gabriel García Márquez", 1967, 1);
            bibliotecaSistema.AdicionarLivro("O Livro do Desassossego", "Fernando Pessoa", 1982, 2);

            // Utilizadores
            bibliotecaSistema.AdicionarUtilizador("David Bruno", "Rua de Mafamude, 123", "912345678", "DavidBruno", "password");
            bibliotecaSistema.AdicionarUtilizador("Rita Faria", "Av. da Liberdade, 456", "934567890", "RitaFaria", "password");
            bibliotecaSistema.AdicionarUtilizador("João Silva", "Rua da Alegria, 789", "945678901", "JoãoSilva", "password");

            // Funcionário
            bibliotecaSistema.AdicionarFuncionario("Ana Costa", "Travessa do Sol, 78", "926789123", "Bibliotecária", "AnaCosta", "password");
            bibliotecaSistema.AdicionarFuncionario("Pedro Santos", "Rua Nova, 12", "938765432", "Assistente", "PedroSantos", "password");

            bool sair = false;

            while (!sair)
            {
                Console.Clear();

                // Título estilizado com Figgle (ASCII Art)
                var tituloAscii = FiggleFonts.Standard.Render("Biblioteca");
                AnsiConsole.Write(new Panel(tituloAscii)
                    .Border(BoxBorder.Rounded)
                    .BorderStyle(new Style(foreground: Color.CornflowerBlue))
                    .Padding(1, 1)
                    .Header("[yellow]Sistema de Gestao de Biblioteca[/]", Justify.Center));

                // Menu interactivo com Spectre.Console
                var escolha = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("\n[bold blue]Escolha uma opção:[/]")
                        .PageSize(5)
                        .AddChoices(
                            "Aceder como Funcionário",
                            "Aceder como Utilizador",
                            "Sair")
                );

                switch (escolha)
                {
                    case "Aceder como Funcionário":
                        funcionarioServico.FazerLoginFuncionario(bibliotecaSistema);
                        funcionarioServico.MenuFuncionario(bibliotecaSistema);
                        break;
                    case "Aceder como Utilizador":
                        utilizadorServico.FazerLoginUtilizador(bibliotecaSistema);
                        utilizadorServico.MenuUtilizador(bibliotecaSistema);
                        break;
                    case "Sair":
                        sair = true;
                        AnsiConsole.MarkupLine("[green]A sair do sistema... Até breve![/]");
                        break;
                }

                if (!sair)
                {
                    // Pequena pausa e instrução para continuar
                    AnsiConsole.MarkupLine("[grey]Prima qualquer tecla para voltar ao menu...[/]");
                    Console.ReadKey();
                }
            }
        }
    }
}
