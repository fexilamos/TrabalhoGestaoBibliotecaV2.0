using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("\n--- Menu Funcionário ---");
                Console.WriteLine("[1] Registar Novo Utilizador");
                Console.WriteLine("[2] Registar Novo Funcionário");
                Console.WriteLine("[3] Listar Utilizadores");
                Console.WriteLine("[4] Listar Funcionários");
                Console.WriteLine("[5] Gestão de Livros");
                Console.WriteLine("[6] Gestão de Empréstimos");
                Console.WriteLine("[0] Voltar ao Menu Principal");
                Console.Write("Escolha a opção que pretende: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        RegistarNovoUtilizador(bibliotecaSistema);
                        break;
                    case 2:
                        RegistarNovoFuncionario(bibliotecaSistema);
                        break;
                    case 3:
                        ListarUtilizadores(bibliotecaSistema);
                        break;
                    case 4:
                        ListarFuncionarios(bibliotecaSistema);
                        break;
                    case 5:
                        MostrarMenusLivros(bibliotecaSistema);
                        break;
                    case 6:
                        MostrarMenusEmprestimos(bibliotecaSistema);
                        break;
                    case 0:
                        voltar = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (!voltar) PressioneParaContinuar();
            }
        }

        private void MostrarMenusLivros(BibliotecaSistema bibliotecaSistema)
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.Clear();
                Console.WriteLine("\n--- Gestão de Livros ---");
                Console.WriteLine("1. Adicionar Novo Livro");
                Console.WriteLine("2. Listar Todos os Livros");
                Console.WriteLine("3. Listar Livros Disponíveis");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha a opção que pretende: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarLivro(bibliotecaSistema);
                        break;
                    case 2:
                        ListarLivros(bibliotecaSistema, false);
                        break;
                    case 3:
                        ListarLivros(bibliotecaSistema, true);
                        break;
                    case 0:
                        voltar = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (!voltar) PressioneParaContinuar();
            }
        }

        private void MostrarMenusEmprestimos(BibliotecaSistema bibliotecaSistema)
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.Clear();
                Console.WriteLine("\n--- Gestão de Empréstimos ---");
                Console.WriteLine("1. Realizar Novo Empréstimo");
                Console.WriteLine("2. Registar Devolução");
                Console.WriteLine("3. Listar Empréstimos Ativos");
                Console.WriteLine("4. Listar Todos os Empréstimos");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha a opção que pretende: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        RealizarEmprestimo(bibliotecaSistema);
                        break;
                    case 2:
                        RegistarDevolucao(bibliotecaSistema);
                        break;
                    case 3:
                        ListarEmprestimos(bibliotecaSistema, true);
                        break;
                    case 4:
                        ListarEmprestimos(bibliotecaSistema, false);
                        break;
                    case 0:
                        voltar = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (!voltar) PressioneParaContinuar();
            }
        }

        private void PressioneParaContinuar()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private void RegistarNovoUtilizador(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();
            Console.WriteLine("\n--- Registar Novo Utilizador ---");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Morada: ");
            string morada = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = LerPasswordComAsteriscos();

            bibliotecaSistema.AdicionarUtilizador(nome, morada, telefone, username, password);
            Console.WriteLine("Utilizador registado com sucesso!");
        }

        private void RegistarNovoFuncionario(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();
            Console.WriteLine("\n--- Registar Novo Funcionário ---");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Morada: ");
            string morada = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.Write("Cargo: ");
            string cargo = Console.ReadLine();
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();


            bibliotecaSistema.AdicionarFuncionario(nome, morada, telefone, cargo, username, password);
            Console.WriteLine("Funcionário registado com sucesso!");
        }

        private void ListarUtilizadores(BibliotecaSistema bibliotecaSistema)
        {
            Console.WriteLine("\n--- Lista de Utilizadores ---");
            var lista = bibliotecaSistema.ObterUtilizadores();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum utilizador registado.");
            }
            else
            {
                foreach (var utilizador in lista)
                {
                    Console.WriteLine(utilizador);
                }
            }
        }

        private void ListarFuncionarios(BibliotecaSistema bibliotecaSistema)
        {
            Console.WriteLine("\n--- Lista de Funcionários ---");
            var lista = bibliotecaSistema.ObterFuncionarios();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum funcionário registado.");
            }
            else
            {
                foreach (var funcionario in lista)
                {
                    Console.WriteLine(funcionario);
                }
            }
        }

        private void AdicionarLivro(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();
            Console.WriteLine("\n--- Adicionar Novo Livro ---");
            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            Console.Write("Ano de publicação: ");
            int ano = int.Parse(Console.ReadLine());
            Console.Write("Número de exemplares: ");
            int exemplares = int.Parse(Console.ReadLine());

            bibliotecaSistema.AdicionarLivro(titulo, autor, ano, exemplares);
            Console.WriteLine("Livro adicionado com sucesso!");
        }

        private void ListarLivros(BibliotecaSistema bibliotecaSistema, bool apenasDisponiveis)
        {
            Console.Clear();

            Console.WriteLine($"\n--- {(apenasDisponiveis ? "Livros Disponíveis" : "Todos os Livros")} ---");

            var lista = apenasDisponiveis ? bibliotecaSistema.ObterLivrosDisponiveis() : bibliotecaSistema.ObterTodosLivros();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum livro encontrado.");
            }
            else
            {
                foreach (var livro in lista)
                {
                    Console.WriteLine(livro);
                }
            }
        }

        private void RealizarEmprestimo(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();

            Console.WriteLine("\n--- Realizar Novo Empréstimo ---");

            Console.Write("ID do Utilizador: ");
            int utilizadorID = int.Parse(Console.ReadLine());

            Console.Write("ID do Livro: ");
            int livroID = int.Parse(Console.ReadLine());

            bool sucesso = bibliotecaSistema.FazerEmprestimo(livroID, utilizadorID);

            if (sucesso)
                Console.WriteLine("Empréstimo realizado com sucesso!");
            else
                Console.WriteLine("Não foi possível realizar o empréstimo. Verifique a disponibilidade ou o limite de empréstimos.");
        }

        private void RegistarDevolucao(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();

            Console.WriteLine("\n--- Registar Devolução de Livro ---");

            Console.Write("ID do Utilizador: ");
            int utilizadorID = int.Parse(Console.ReadLine());

            Console.Write("ID do Livro: ");
            int livroID = int.Parse(Console.ReadLine());

            bool sucesso = bibliotecaSistema.RegistarDevolucao(livroID, utilizadorID);

            if (sucesso)
                Console.WriteLine("Devolução registada com sucesso!");
            else
                Console.WriteLine("Não foi possível registar a devolução. Verifique os dados introduzidos.");
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
                Console.Write("\nUsername: ");
                username = Console.ReadLine();
                Console.Write("Password: ");
                password = LerPasswordComAsteriscos();

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
        private string LerPasswordComAsteriscos()
        {
            string password = "";
            ConsoleKeyInfo tecla;

            do
            {
                tecla = Console.ReadKey(true);

                if (tecla.Key != ConsoleKey.Backspace && tecla.Key != ConsoleKey.Enter)
                {
                    password += tecla.KeyChar;
                    Console.Write("*");
                }
                else if (tecla.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);

                    int cursorPos = Console.CursorLeft;
                    Console.SetCursorPosition(cursorPos - 1, Console.CursorTop);
                    Console.Write(" ");
                    Console.SetCursorPosition(cursorPos - 1, Console.CursorTop);
                }

            } while (tecla.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
    }
}
