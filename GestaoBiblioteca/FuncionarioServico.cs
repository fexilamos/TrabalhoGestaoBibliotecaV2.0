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
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarLivro(bibliotecaSistema);
                        break;
                    case "2":
                        ListarLivros(bibliotecaSistema, false);
                        break;
                    case "3":
                        ListarLivros(bibliotecaSistema, true);
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
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        RealizarEmprestimo(bibliotecaSistema);
                        break;
                    case "2":
                        RegistarDevolucao(bibliotecaSistema);
                        break;
                    case "3":
                        ListarEmprestimos(bibliotecaSistema, true);
                        break;
                    case "4":
                        ListarEmprestimos(bibliotecaSistema, false);
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
                    Console.WriteLine("[Erro]: O nome não pode estar vazio. Por favor, insira um nome válido.");
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
                    Console.WriteLine("[Erro]: A morada não pode estar vazia. Por favor, insira uma morada válida.");
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
                    Console.WriteLine("[Erro]: O número de telefone não pode estar vazio.");
                    telefoneValido = false; // Não é válido
                }
                else if (telefone.Length != 9)
                {
                    Console.WriteLine("[Erro]: O número de telefone deve ter exatamente 9 dígitos.");
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
                        Console.WriteLine("[Erro]: O número de telefone deve conter apenas números.");
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
                    Console.WriteLine("[Erro]: O Nome do Usuario não pode estar vazio.");
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
            string nome;
            // Validar Nome: garantir que não está vazio ou apenas com espaços em branco
            do
            {
                Console.Write("Insira o seu nome: ");
                nome = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("[Erro]: O nome não pode estar vazio. Por favor, insira um nome válido.");
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
                    Console.WriteLine("[Erro]: A morada não pode estar vazia. Por favor, insira uma morada válida.");
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
                    Console.WriteLine("[Erro]: O número de telefone não pode estar vazio.");
                    telefoneValido = false; // Não é válido
                }
                else if (telefone.Length != 9)
                {
                    Console.WriteLine("[Erro]: O número de telefone deve ter exatamente 9 dígitos.");
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
                        Console.WriteLine("[Erro]: O número de telefone deve conter apenas números.");
                        telefoneValido = false; // Não é válido
                    }
                }
            } while (!telefoneValido);

            string cargo;
            // Validar Cargo: garantir que não está vazio ou apenas com espaços em branco
            do
            {
                Console.Write("Insira o Cargo: ");
                cargo = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(cargo))
                {
                    Console.WriteLine("[Erro]: O cargo não pode estar vazia. Por favor, insira uma morada válida.");
                }
            } while (string.IsNullOrWhiteSpace(cargo));
            //Validar Username: Garantir que não esta vazio ou apenas com espaços em branco, garantir que não existe no sistema
            string username;
            bool usernameValido = false;
            do
            {
                Console.Write("Insira o seu Nome do Usuario: ");
                username = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(username))
                {
                    Console.WriteLine("[Erro]: O Nome do Usuario não pode estar vazio.");
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

            // Validar a password não pode estar vazia e ter menos de 8 carateres
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

            bool tituloValido = false;
            string titulo;
            do 
            { 
                Console.Write("Insira o Título: ");
                titulo = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(titulo))
                {
                    Console.WriteLine("[Erro]: O título não pode estar vazio. Por favor, insira um título válido.");
                }
                else
                {
                    if (bibliotecaSistema.LivroExiste(titulo))
                    {
                        Console.WriteLine($"[Erro]: O livro '{titulo}' já existe no sistema. Por favor, escolha outro título.");
                        tituloValido = false; // Não é válido porque não é único
                    }
                    else
                    {
                        tituloValido = true; // Válido (passou verificações de formato e unicidade)
                    }
                }
            } while ( !tituloValido );
            // Repetir enquanto o título for inválido (vazio ou já existente)
            // Validar Autor: garantir que não está vazio ou apenas com espaços em branco
            string autor;
            do
            {
                Console.Write("Insira o Autor: ");
                autor = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(autor))
                {
                    Console.WriteLine("[Erro]: O autor não pode estar vazio. Por favor, insira um autor válido.");
                }
            } while (string.IsNullOrWhiteSpace(autor)); // Repete enquanto o autor for vazio ou só espaços

            // Validar Ano: garantir que é um número inteiro
            string input;
            int ano;
            do
            {
                Console.Write("Insira o Ano de Publicação: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out ano))
                {
                    Console.WriteLine("[Erro]: O ano deve ser um número inteiro.");
                }
            } while (!int.TryParse(input, out ano)); // Repete enquanto o ano não for um número inteiro

            // Validar Exemplares: garantir que é um número inteiro
            string input2;
            int exemplares;
            do
            {
                Console.Write("Insira o Número de Exemplares: ");
                input2 = Console.ReadLine();
                if (int.TryParse(input2, out exemplares))
                {
                    Console.WriteLine("[Erro]: O número de exemplares deve ser um número inteiro.");
                }
            } while (!int.TryParse(input2, out exemplares)); // Repete enquanto o número de exemplares não for um número inteiro

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

            int utilizadorID;
            bool utilizadorEncontrado = false; // Flag para controlar a validação e existência do utilizador

            // Ciclo para obter e validar o ID do Utilizador

            do
            {
                Console.Write("Insira o ID do Utilizador: ");
                string inputUtilizador = Console.ReadLine();

                // Tentar converter a entrada para inteiro
                if (int.TryParse(inputUtilizador, out utilizadorID))
                {
                    // Conversão bem-sucedida, agora verificar se o utilizador existe no sistema
                    // Método no BibliotecaSistema para procurar o utilizador
                    Utilizador utilizador = bibliotecaSistema.GetUtilizadorById(utilizadorID); // Assume que retorna null se não existir

                    if (utilizador != null) // Verificar se o método encontrou o utilizador
                    {
                        utilizadorEncontrado = true; // ID válido e utilizador existe
                    }
                    else
                    {
                        Console.WriteLine($"[Erro]: O Utilizador com ID {utilizadorID} não foi encontrado no sistema. Por favor, verifique o ID.");
                        utilizadorEncontrado = false; // ID válido, mas utilizador não existe
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um ID de utilizador numérico.");
                    utilizadorEncontrado = false; // A conversão falhou (não era um número)
                }
                // Repetir enquanto o utilizador não for encontrado (ou a entrada for inválida)
            } while (!utilizadorEncontrado);

            int livroID;
            bool livroEncontrado = false; // Flag para controlar a validação e existência do livro

            // Ciclo para obter e validar o ID do Livro
            do
            {
                Console.Write("Insira o ID do Livro: ");
                string inputLivro = Console.ReadLine();

                //Tentar converter a entrada para inteiro
                if (int.TryParse(inputLivro, out livroID))
                {
                    // Conversão bem-sucedida, agora verificar se o livro existe no sistema
                    // Método no BibliotecaSistema para procurar o livro
                    Livro livro = bibliotecaSistema.GetLivroById(livroID); // Assume que retorna null se não existir

                    if (livro != null) // Verificar se o método encontrou o livro
                    {
                        livroEncontrado = true; // ID válido e livro existe
                    }
                    else
                    {
                        Console.WriteLine($"[Erro]: Livro com ID {livroID} não encontrado no sistema. Por favor, verifique o ID.");
                        livroEncontrado = false; // ID válido, mas livro não existe
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um ID de livro numérico.");
                    livroEncontrado = false; // A conversão falhou (não era um número)
                }
                // Repetir enquanto o livro não for encontrado (ou a entrada for inválida)
            } while (!livroEncontrado);

            bool sucesso = bibliotecaSistema.FazerEmprestimo(livroID, utilizadorID);

            if (sucesso)
            {
                Console.WriteLine("Empréstimo realizado com sucesso!");
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

            int utilizadorID;
            bool utilizadorEncontrado = false; // Flag para controlar a validação e existência do utilizador

            // Ciclo para obter e validar o ID do Utilizador

            do
            {
                Console.Write("Insira o ID do Utilizador: ");
                string inputUtilizador = Console.ReadLine();

                // Tentar converter a entrada para inteiro
                if (int.TryParse(inputUtilizador, out utilizadorID))
                {
                    // Conversão bem-sucedida, agora verificar se o utilizador existe no sistema
                    // Método no BibliotecaSistema para procurar o utilizador
                    Utilizador utilizador = bibliotecaSistema.GetUtilizadorById(utilizadorID); // Assume que retorna null se não existir

                    if (utilizador != null) // Verificar se o método encontrou o utilizador
                    {
                        utilizadorEncontrado = true; // ID válido e utilizador existe
                    }
                    else
                    {
                        Console.WriteLine($"[Erro]: O Utilizador com ID {utilizadorID} não foi encontrado no sistema. Por favor, verifique o ID.");
                        utilizadorEncontrado = false; // ID válido, mas utilizador não existe
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um ID de utilizador numérico.");
                    utilizadorEncontrado = false; // A conversão falhou (não era um número)
                }
                // Repetir enquanto o utilizador não for encontrado (ou a entrada for inválida)
            } while (!utilizadorEncontrado);

            int livroID;
            bool livroEncontrado = false; // Flag para controlar a validação e existência do livro

            // Ciclo para obter e validar o ID do Livro
            do
            {
                Console.Write("Insira o ID do Livro: ");
                string inputLivro = Console.ReadLine();

                //Tentar converter a entrada para inteiro
                if (int.TryParse(inputLivro, out livroID))
                {
                    // Conversão bem-sucedida, agora verificar se o livro existe no sistema
                    // Método no BibliotecaSistema para procurar o livro
                    Livro livro = bibliotecaSistema.GetLivroById(livroID); // Assume que retorna null se não existir

                    if (livro != null) // Verificar se o método encontrou o livro
                    {
                        livroEncontrado = true; // ID válido e livro existe
                    }
                    else
                    {
                        Console.WriteLine($"[Erro]: Livro com ID {livroID} não encontrado no sistema. Por favor, verifique o ID.");
                        livroEncontrado = false; // ID válido, mas livro não existe
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um ID de livro numérico.");
                    livroEncontrado = false; // A conversão falhou (não era um número)
                }
                // Repetir enquanto o livro não for encontrado (ou a entrada for inválida)
            } while (!livroEncontrado);


            bool sucesso = bibliotecaSistema.RegistarDevolucao(livroID, utilizadorID);

            if (sucesso)
            {
                Console.WriteLine("Livro devolvido com sucesso!");
            }
            else
            {
                // O erro agora não é porque o ID não existe, mas sim porque a devolução falhou por outro motivo
                // Por exemplo, o livro não estava emprestado a este utilizador.
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
