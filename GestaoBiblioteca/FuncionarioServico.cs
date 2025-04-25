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
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        RegistarNovoUtilizador(bibliotecaSistema);
                        break;
                    case "2":
                        RegistarNovoFuncionario(bibliotecaSistema);
                        break;
                    case "3":
                        ListarUtilizadores(bibliotecaSistema);
                        break;
                    case "4":
                        ListarFuncionarios(bibliotecaSistema);
                        break;
                    case "5":
                        MostrarMenusLivros(bibliotecaSistema);
                        break;
                    case "6":
                        MostrarMenusEmprestimos(bibliotecaSistema);
                        break;
                    case "0":
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
            string nome;
            // Validar Nome: garantir que não está vazio ou apenas com espaços em branco
            do
            {
                Console.Write("Insira o seu nome: ");
                nome = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("[Erro] O nome não pode estar vazio. Por favor, insira um nome válido.");
                }
            } while (string.IsNullOrWhiteSpace(nome)); // Repete enquanto o nome for vazio ou só espaços

            string morada;
            // Validar Morada: garantir que não está vazia ou apenas com espaços em branco
            do
            {
                Console.Write("Insira a sua morada: ");
                morada = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(morada))
                {
                    Console.WriteLine("[Erro] A morada não pode estar vazia. Por favor, insira uma morada válida.");
                }
            } while (string.IsNullOrWhiteSpace(morada));

            string telefone;
            bool telefoneValido = false;
            // Validar Telefone: garantir que não está vazio, tem 9 dígitos e contém apenas números
            do
            {
                Console.Write("Insira o seu numero de telefone (9 dígitos): ");
                telefone = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(telefone))
                {
                    Console.WriteLine("[Erro] O número de telefone não pode estar vazio.");
                    telefoneValido = false; // Não é válido
                }
                else if (telefone.Length != 9)
                {
                    Console.WriteLine("[Erro] O número de telefone deve ter exatamente 9 dígitos.");
                    telefoneValido = false; // Não é válido
                }
                else
                {
                    // Verificar se todos os caracteres são dígitos
                    // Requer 'using System.Linq;' no topo do seu ficheiro
                    if (telefone.All(char.IsDigit))
                    {
                        telefoneValido = true; // Passou todas as validações básicas
                    }
                    else
                    {
                        Console.WriteLine("[Erro] O número de telefone deve conter apenas números.");
                        telefoneValido = false; // Não é válido
                    }
                }
            } while (!telefoneValido);

            string username;
            bool usernameValido = false;
            do
            {
                Console.Write("Insira o seu Nome do Usuario: ");
                username = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(username))
                {
                    Console.WriteLine("Erro: O Nome do Usuario não pode estar vazio.");
                    usernameValido = false;
                }
                else
                {
                    // --- Validar se o username já existe no sistema ---
                    if (bibliotecaSistema.UtilizadorExiste(username))
                    {
                        Console.WriteLine($"[Erro]: O Nome de Usuario '{username}' já está em uso. Por favor, escolha outro.");
                        usernameValido = false; // Não é válido porque não é único
                    }
                    else
                    {
                        usernameValido = true; // Válido (passou verificações de formato e unicidade)
                    }
                }
            } while (!usernameValido); // Repetir enquanto o username for inválido (vazio ou já existente)
            string password;
            bool passwordValida = false;
            do
            {
                Console.Write("Insira a sua senha: ");
                password = LerPasswordComAsteriscos();

                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("[Erro]: A senha não pode estar vazia.");
                    passwordValida = false;
                }

                else if (password.Length < 8) // Senha com mínimo 8 caracteres
                {
                    Console.WriteLine("[Erro]: A senha deve ter pelo menos 8 caracteres.");
                    passwordValida = false;
                }
                else
                {
                    passwordValida = true; // Passou as validações de formato e comprimento
                }
            } while (!passwordValida); // Repetir enquanto a password for inválida


            // Confirmação da Password (deve ser igual à anterior)
            string confirmacaoPassword;
            bool passwordsCorrespondem = false;
            do
            {
                Console.Write("Confirme a senha: ");
                confirmacaoPassword = LerPasswordComAsteriscos();

                if (string.IsNullOrWhiteSpace(confirmacaoPassword))
                {
                    Console.WriteLine("[Erro]: A confirmação da senha não pode estar vazia.");
                    passwordsCorrespondem = false;
                }
                else if (confirmacaoPassword != password) // Comparar com a password original inserida
                {
                    Console.WriteLine("[Erro]: As senhas não correspondem. Por favor, tente novamente.");
                    passwordsCorrespondem = false;
                }
                else
                {
                    passwordsCorrespondem = true; // Passwords coincidem
                }
            } while (!passwordsCorrespondem);

            bibliotecaSistema.AdicionarUtilizador(nome, morada, telefone, username, password);
            Console.WriteLine("Utilizador registado com sucesso!");
        }

        private void RegistarNovoFuncionario(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();
            Console.WriteLine("\n--- Registar Novo Funcionário ---");
            Console.Write("Insira o Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Insira a Morada: ");
            string morada = Console.ReadLine();
            Console.Write("Insira o numero de Telefone: ");
            string telefone = Console.ReadLine();
            Console.Write("Insira o Cargo: ");
            string cargo = Console.ReadLine();
            Console.Write("Insira o Nome do Usuario: ");
            string username = Console.ReadLine();
            Console.Write("Insira a Senha: ");
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
