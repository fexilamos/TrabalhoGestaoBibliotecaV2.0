using System;
using GestaoBiblioteca;
using Spectre.Console;
using Figgle;

namespace GestaoBiblioteca
{
    internal class UtilizadorServico
    {
        public void MenuUtilizador(BibliotecaSistema bibliotecaSistema)
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.Clear();

                // Título visual tipo o menu principal
                var tituloAscii = FiggleFonts.Standard.Render("Utilizador");
                AnsiConsole.Write(
                    new Panel(tituloAscii)
                        .Border(BoxBorder.Rounded)
                        .BorderStyle(new Style(foreground: Color.CornflowerBlue))
                        .Padding(1, 1)
                        .Header("[yellow]Menu do Utilizador[/]", Justify.Center)
                );

                // Menu visual com Spectre.Console
                var opcao = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("\n[bold blue]Escolha a opção que pretende:[/]")
                        .PageSize(5)
                        .AddChoices(
                            //"Registar-se como Novo Utilizador",
                            "Consultar Livros Disponíveis",
                            "Devolver Livros",
                            "Voltar ao Menu Principal"
                        )
                );

                switch (opcao)
                {
                    case "Registar-se como Novo Utilizador":
                        RegistarNovoUtilizador(bibliotecaSistema);
                        break;
                    case "Consultar Livros Disponíveis":
                        ListarLivrosDisponiveis(bibliotecaSistema);
                        break;
                    case "Devolver Livros":
                        RegistarDevolucao(bibliotecaSistema);
                        break;
                    case "Voltar ao Menu Principal":
                        voltar = true;
                        break;
                }

                if (!voltar)
                {
                    AnsiConsole.MarkupLine("[grey]Prima qualquer tecla para continuar...[/]");
                    Console.ReadKey();
                }
            }
        }

        private void RegistarNovoUtilizador(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();
            Console.WriteLine("\n--- Registar-se como Novo Utilizador ---");

            string nome = ConsolaAjuda.ValidacaoInput("Insira o seu nome: ");
            string morada = ConsolaAjuda.ValidacaoInput("Insira a sua morada: ");
            string telefone = ConsolaAjuda.ValidacaoTelefone("Insira o seu numero de telefone (9 dígitos): ");
            string username = ConsolaAjuda.ValidacaoNomeUsuario("Insira o seu Nome do Usuario: ", bibliotecaSistema);
            string password = ConsolaAjuda.ValidacaoSenha("Insira a sua senha: ", "Confirme a senha: ", minLength: 8);

            bibliotecaSistema.AdicionarUtilizador(nome, morada, telefone, username, password);
            Console.WriteLine("Utilizador registado com sucesso!");
        }

        //private void ListarEmprestimos(BibliotecaSistema bibliotecaSistema, bool apenasAtivos)
        //{
        //    Console.Clear();

        //    string tituloPainel = apenasAtivos ? "Empréstimos Ativos" : "Todos os Empréstimos";

        //    AnsiConsole.Write(
        //        new Panel(tituloPainel)
        //            .Border(BoxBorder.Rounded)
        //            .BorderStyle(new Style(foreground: Color.Blue))
        //            .Header("[yellow]Lista de Empréstimos[/]", Justify.Center)
        //    );

        //    var lista = bibliotecaSistema.ObterEmprestimos(apenasAtivos);

        //    if (lista.Count == 0)
        //    {
        //        AnsiConsole.MarkupLine("[red]Nenhum empréstimo encontrado![/]");
        //        return;
        //    }

        //    var tabela = new Table();
        //    tabela.Border(TableBorder.Rounded);

        //    tabela.AddColumn("[bold]ID[/]");
        //    tabela.AddColumn("[bold]Utilizador[/]");
        //    tabela.AddColumn("[bold]Livro[/]");
        //    tabela.AddColumn("[bold]Data Empréstimo[/]");
        //    tabela.AddColumn("[bold]Data Devolução Prevista[/]");
        //    tabela.AddColumn("[bold]Estado[/]");

        //    foreach (var emprestimo in lista)
        //    {
        //        // ⚡ CORRIGIDO: usar UtilizadorID() e LivroID()
        //        var utilizador = bibliotecaSistema.UtilizadorID(emprestimo.UtilizadorID);
        //        var livro = bibliotecaSistema.LivroID(emprestimo.LivroID);

        //        string nomeUtilizador = utilizador != null ? utilizador.Nome : "Desconhecido";
        //        string tituloLivro = livro != null ? livro.Titulo : "Desconhecido";

        //        tabela.AddRow(
        //            emprestimo.ID.ToString(),
        //            nomeUtilizador,
        //            tituloLivro,
        //            emprestimo.DataEmprestimo.ToString("dd/MM/yyyy"),
        //            emprestimo.DataDevolucaoPrevista.ToString("dd/MM/yyyy"),
        //            emprestimo.Estado == EstadoEmprestimo.Ativo ? "[green]Ativo[/]" : "[red]Devolvido[/]"
        //        );
        //    }

        //    AnsiConsole.Write(tabela);
        //}
        private void ListarLivrosDisponiveis(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();

            AnsiConsole.Write(
                new Panel("Livros Disponíveis")
                    .Border(BoxBorder.Rounded)
                    .BorderStyle(new Style(foreground: Color.Green))
                    .Header("[yellow]Lista de Livros Disponíveis[/]", Justify.Center)
            );

            var lista = bibliotecaSistema.ObterLivrosDisponiveis();

            if (lista.Count == 0)
            {
                AnsiConsole.MarkupLine("[red]Não há livros disponíveis no momento![/]");
                return;
            }

            var tabela = new Table();
            tabela.Border(TableBorder.Rounded);

            tabela.AddColumn("[bold]ID[/]");
            tabela.AddColumn("[bold]Título[/]");
            tabela.AddColumn("[bold]Autor[/]");
            tabela.AddColumn("[bold]Ano[/]");
            tabela.AddColumn("[bold]Exemplares Disponíveis[/]");

            foreach (var livro in lista)
            {
                tabela.AddRow(
                    livro.ID.ToString(),
                    livro.Titulo,
                    livro.Autor,
                    livro.Ano.ToString(),
                    livro.Exemplares.ToString()
                );
            }

            AnsiConsole.Write(tabela);
        }


        private void RegistarDevolucao(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();

            Console.WriteLine("\n--- Registar Devolução de Livro ---");

            Utilizador utilizador = ConsolaAjuda.ProcurarUtilizadorPorID(bibliotecaSistema);
            int utilizadorID = utilizador.ID;
            Livro livro = ConsolaAjuda.ProcurarLivroPorID(bibliotecaSistema);
            int livroID = livro.ID;

            decimal multaAplicada;
            bool sucesso = bibliotecaSistema.RegistarDevolucao(livroID, utilizadorID, out multaAplicada);

            if (sucesso)
            {
                Console.WriteLine("Livro devolvido com sucesso!");
                if (multaAplicada > 0)
                {
                    Console.WriteLine($"Multa aplicada: {multaAplicada:C}");
                }
                else
                {
                    Console.WriteLine("Devolução realizada dentro do prazo. Nenhuma multa aplicada.");
                }
            }
            else
            {
                Console.WriteLine("Erro ao devolver. Verifique os dados inseridos ou se o empréstimo está ativo.");
            }
        }

        public void FazerLoginUtilizador(BibliotecaSistema bibliotecaSistema)
        {
            string username;
            string password;
            Utilizador utilizador = null;

            do
            {
                username = ConsolaAjuda.ValidacaoInput("\nUsername: ");
                Console.Write("Password: ");
                password = ConsolaAjuda.LerPasswordComAsteriscos();

                utilizador = bibliotecaSistema.LoginUtilizador(username, password);

                if (utilizador != null)
                {
                    Console.WriteLine($"Login bem-sucedido! Bem-vindo, {utilizador.Nome}.");
                    break;
                }
                else
                {
                    Console.WriteLine("Credenciais inválidas. Tente novamente.");
                }

            } while (true);
        }
    }
}
