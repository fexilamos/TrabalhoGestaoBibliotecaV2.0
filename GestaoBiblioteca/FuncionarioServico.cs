using System;
using GestaoBiblioteca;
using Spectre.Console;
using Figgle;

namespace GestaoBiblioteca
{
    internal class FuncionarioServico
    {
        public void MenuFuncionario(BibliotecaSistema bibliotecaSistema)
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.Clear();

                // Título Figgle e painel
                var tituloAscii = FiggleFonts.Standard.Render("Funcionario");
                AnsiConsole.Write(
                    new Panel(tituloAscii)
                        .Border(BoxBorder.Rounded)
                        .BorderStyle(new Style(foreground: Color.CornflowerBlue))
                        .Padding(1, 1)
                        .Header("[yellow]Menu do Funcionário[/]", Justify.Center)
                );

                // Menu visual Spectre.Console
                var opcao = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("\n[bold blue]Escolha a opção que pretende:[/]")
                        .PageSize(7)
                        .AddChoices(
                            "Registar Novo Utilizador",
                            "Registar Novo Funcionário",
                            "Listar Utilizadores",
                            "Listar Funcionários",
                            "Gestão de Livros",
                            "Gestão de Empréstimos",
                            "Voltar ao Menu Principal"
                        )
                );

                switch (opcao)
                {
                    case "Registar Novo Utilizador":
                        RegistarNovoUtilizador(bibliotecaSistema);
                        break;
                    case "Registar Novo Funcionário":
                        RegistarNovoFuncionario(bibliotecaSistema);
                        break;
                    case "Listar Utilizadores":
                        ListarUtilizadores(bibliotecaSistema);
                        break;
                    case "Listar Funcionários":
                        ListarFuncionarios(bibliotecaSistema);
                        break;
                    case "Gestão de Livros":
                        MostrarMenusLivros(bibliotecaSistema);
                        break;
                    case "Gestão de Empréstimos":
                        MostrarMenusEmprestimos(bibliotecaSistema);
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

        private void MostrarMenusLivros(BibliotecaSistema bibliotecaSistema)
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.Clear();

                var tituloAscii = FiggleFonts.Standard.Render("Livros");
                AnsiConsole.Write(
                    new Panel(tituloAscii)
                        .Border(BoxBorder.Rounded)
                        .BorderStyle(new Style(foreground: Color.Green))
                        .Padding(1, 1)
                        .Header("[yellow]Gestão de Livros[/]", Justify.Center)
                );

                var opcao = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("\n[bold green]Escolha a opção que pretende:[/]")
                        .PageSize(4)
                        .AddChoices(
                            "Adicionar Novo Livro",
                            "Listar Todos os Livros",
                            "Listar Livros Disponíveis",
                            "Voltar ao Menu Principal"
                        )
                );

                switch (opcao)
                {
                    case "Adicionar Novo Livro":
                        AdicionarLivro(bibliotecaSistema);
                        break;
                    case "Listar Todos os Livros":
                        ListarLivros(bibliotecaSistema, false);
                        break;
                    case "Listar Livros Disponíveis":
                        ListarLivros(bibliotecaSistema, true);
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

        private void MostrarMenusEmprestimos(BibliotecaSistema bibliotecaSistema)
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.Clear();

                var tituloAscii = FiggleFonts.Standard.Render("Emprestimos");
                AnsiConsole.Write(
                    new Panel(tituloAscii)
                        .Border(BoxBorder.Rounded)
                        .BorderStyle(new Style(foreground: Color.Yellow))
                        .Padding(1, 1)
                        .Header("[yellow]Gestão de Empréstimos[/]", Justify.Center)
                );

                var opcao = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("\n[bold yellow]Escolha a opção que pretende:[/]")
                        .PageSize(5)
                        .AddChoices(
                            "Realizar Novo Empréstimo",
                            "Registar Devolução",
                            "Listar Empréstimos Ativos",
                            "Listar Todos os Empréstimos",
                            "Voltar ao Menu Principal"
                        )
                );

                switch (opcao)
                {
                    case "Realizar Novo Empréstimo":
                        RealizarEmprestimo(bibliotecaSistema);
                        break;
                    case "Registar Devolução":
                        RegistarDevolucao(bibliotecaSistema);
                        break;
                    case "Listar Empréstimos Ativos":
                        ListarEmprestimos(bibliotecaSistema, true);
                        break;
                    case "Listar Todos os Empréstimos":
                        ListarEmprestimos(bibliotecaSistema, false);
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

            AnsiConsole.Write(
                new Panel("Registar Novo Utilizador")
                    .Border(BoxBorder.Rounded)
                    .BorderStyle(new Style(foreground: Color.Blue))
                    .Header("[yellow]Novo Utilizador[/]", Justify.Center)
            );

            string nome = ConsolaAjuda.ValidacaoInput("Insira o seu nome: ");
            string morada = ConsolaAjuda.ValidacaoInput("Insira a sua morada: ");
            string telefone = ConsolaAjuda.ValidacaoTelefone("Insira o seu número de telefone (9 dígitos): ");
            string username = ConsolaAjuda.ValidacaoNomeUsuario("Insira o seu Nome de Utilizador: ", bibliotecaSistema);
            string password = ConsolaAjuda.ValidacaoSenha("Insira a sua senha:", "Confirme a senha:", minLength: 8);

            bibliotecaSistema.AdicionarUtilizador(nome, morada, telefone, username, password);
            TxtHelper.GerarFichaUtilizador(nome, morada, telefone);

            AnsiConsole.MarkupLine("\n[green]✅ Utilizador registado com sucesso![/]");
            AnsiConsole.MarkupLine("[grey]Prima qualquer tecla para continuar...[/]");
            Console.ReadKey();
        }



        private void RegistarNovoFuncionario(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();

            AnsiConsole.Write(
                new Panel("Registar Novo Funcionário")
                    .Border(BoxBorder.Rounded)
                    .BorderStyle(new Style(foreground: Color.Blue))
                    .Header("[yellow]Novo Funcionário[/]", Justify.Center)
            );

            string nome = ConsolaAjuda.ValidacaoInput("Insira o seu nome: ");
            string morada = ConsolaAjuda.ValidacaoInput("Insira a sua morada: ");
            string telefone = ConsolaAjuda.ValidacaoTelefone("Insira o seu número de telefone (9 dígitos): ");
            string cargo = ConsolaAjuda.ValidacaoInput("Insira o seu cargo: ");
            string username = ConsolaAjuda.ValidacaoNomeUsuario("Insira o seu Nome de Utilizador: ", bibliotecaSistema);
            string password = ConsolaAjuda.ValidacaoSenha("Insira a sua senha:", "Confirme a senha:", minLength: 8);

            bibliotecaSistema.AdicionarFuncionario(nome, morada, telefone, cargo, username, password);
            TxtHelper.GerarFichaFuncionario(nome, morada, telefone, cargo);

            AnsiConsole.MarkupLine("\n[green]✅ Funcionário registado com sucesso![/]");
            AnsiConsole.MarkupLine("[grey]Prima qualquer tecla para continuar...[/]");
            Console.ReadKey();
        }


        private void ListarUtilizadores(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();

            AnsiConsole.Write(
                new Panel("Utilizadores")
                    .Border(BoxBorder.Rounded)
                    .BorderStyle(new Style(foreground: Color.Cyan1))
                    .Header("[yellow]Lista de Utilizadores[/]", Justify.Center)
            );

            var lista = bibliotecaSistema.ObterUtilizadores();

            if (lista.Count == 0)
            {
                AnsiConsole.MarkupLine("[red]Nenhum utilizador registado![/]");
                return;
            }

            var tabela = new Table();
            tabela.Border(TableBorder.Rounded);
            tabela.AddColumn("[bold]ID[/]");
            tabela.AddColumn("[bold]Nome[/]");
            tabela.AddColumn("[bold]Morada[/]");
            tabela.AddColumn("[bold]Telefone[/]");
            tabela.AddColumn("[bold]Username[/]");

            foreach (var utilizador in lista)
            {
                tabela.AddRow(
                    utilizador.ID.ToString(),
                    utilizador.Nome,
                    utilizador.Morada,
                    utilizador.Telefone,
                    utilizador.Username
                );
            }

            AnsiConsole.Write(tabela);
        }


        private void ListarFuncionarios(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();

            AnsiConsole.Write(
                new Panel("Funcionários")
                    .Border(BoxBorder.Rounded)
                    .BorderStyle(new Style(foreground: Color.Orange1))
                    .Header("[yellow]Lista de Funcionários[/]", Justify.Center)
            );

            var lista = bibliotecaSistema.ObterFuncionarios();

            if (lista.Count == 0)
            {
                AnsiConsole.MarkupLine("[red]Nenhum funcionário registado![/]");
                return;
            }

            var tabela = new Table();
            tabela.Border(TableBorder.Rounded);
            tabela.AddColumn("[bold]ID[/]");
            tabela.AddColumn("[bold]Nome[/]");
            tabela.AddColumn("[bold]Morada[/]");
            tabela.AddColumn("[bold]Telefone[/]");
            tabela.AddColumn("[bold]Cargo[/]");
            tabela.AddColumn("[bold]Username[/]");

            foreach (var funcionario in lista)
            {
                tabela.AddRow(
                    funcionario.ID.ToString(),
                    funcionario.Nome,
                    funcionario.Morada,
                    funcionario.Telefone,
                    funcionario.Cargo,
                    funcionario.Username
                );
            }

            AnsiConsole.Write(tabela);
        }


        private void AdicionarLivro(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();

            // Painel bonito a dizer "Adicionar Novo Livro"
            AnsiConsole.Write(
                new Panel("Adicionar Novo Livro")
                    .Border(BoxBorder.Rounded)
                    .BorderStyle(new Style(foreground: Color.Green))
                    .Header("[yellow]Novo Livro[/]", Justify.Center)
            );

            string titulo = ConsolaAjuda.TituloUnico("Insira o Título: ", bibliotecaSistema);
            string autor = ConsolaAjuda.ValidacaoInput("Insira o Autor: ");
            int ano = ConsolaAjuda.ConverteInt("Insira o Ano de Publicação: ");
            int exemplares = ConsolaAjuda.ConverteInt("Insira o Número de Exemplares: ");

            bibliotecaSistema.AdicionarLivro(titulo, autor, ano, exemplares);

            AnsiConsole.MarkupLine("\n[green]✅ Livro adicionado com sucesso![/]");
            AnsiConsole.MarkupLine("[grey]Prima qualquer tecla para continuar...[/]");
            Console.ReadKey();
        }


        private void ListarLivros(BibliotecaSistema bibliotecaSistema, bool apenasDisponiveis)
        {
            Console.Clear();

            string tituloPainel = apenasDisponiveis ? "Livros Disponíveis" : "Todos os Livros";

            AnsiConsole.Write(
                new Panel(tituloPainel)
                    .Border(BoxBorder.Rounded)
                    .BorderStyle(new Style(foreground: Color.Green))
                    .Header("[yellow]Lista de Livros[/]", Justify.Center)
            );

            var lista = apenasDisponiveis ? bibliotecaSistema.ObterLivrosDisponiveis() : bibliotecaSistema.ObterTodosLivros();

            if (lista.Count == 0)
            {
                AnsiConsole.MarkupLine("[red]Nenhum livro encontrado![/]");
                return;
            }

            var tabela = new Table();
            tabela.Border(TableBorder.Rounded);

            tabela.AddColumn("[bold]ID[/]");
            tabela.AddColumn("[bold]Título[/]");
            tabela.AddColumn("[bold]Autor[/]");
            tabela.AddColumn("[bold]Ano[/]");
            tabela.AddColumn("[bold]Exemplares[/]");

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


        private void RealizarEmprestimo(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();
            Console.WriteLine("\n--- Realizar Novo Empréstimo ---");

            Utilizador utilizador = ConsolaAjuda.ProcurarUtilizadorPorID(bibliotecaSistema);
            int utilizadorID = utilizador.ID;
            Livro livro = ConsolaAjuda.ProcurarLivroPorID(bibliotecaSistema);
            int livroID = livro.ID;

            bool sucesso = bibliotecaSistema.FazerEmprestimo(livroID, utilizadorID);

            if (sucesso)
            {
                Console.WriteLine("Empréstimo realizado com sucesso!");
                TxtHelper.GerarReciboEmprestimo(utilizador.Nome, livro.Titulo, DateTime.Now);
            }
            else
            {
                Console.WriteLine("Não foi possível realizar o empréstimo. Verifique a disponibilidade ou o limite de empréstimos.");
            }
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

        private void ListarEmprestimos(BibliotecaSistema bibliotecaSistema, bool apenasAtivos)
        {
            Console.Clear();

            Console.WriteLine($"\n--- {(apenasAtivos ? "Empréstimos Ativos" : "Todos os Empréstimos")} ---");

            var lista = bibliotecaSistema.ObterEmprestimos(apenasAtivos);

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum empréstimo encontrado.");
            }
            else
            {
                foreach (var emprestimo in lista)
                {
                    Console.WriteLine(emprestimo);
                }
            }
        }

        public void FazerLoginFuncionario(BibliotecaSistema bibliotecaSistema)
        {
            string username;
            string password;
            Funcionario funcionario = null;

            do
            {
                username = ConsolaAjuda.ValidacaoInput("\nUsername: ");
                Console.Write("Password: ");
                password = ConsolaAjuda.LerPasswordComAsteriscos();

                funcionario = bibliotecaSistema.LoginFuncionario(username, password);

                if (funcionario != null)
                {
                    Console.WriteLine($"Login bem-sucedido! Bem-vindo, {funcionario.Nome}.");
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
