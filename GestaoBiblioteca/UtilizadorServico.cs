using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("\n--- Menu Utilizador ---");
                Console.WriteLine("[1] Registar-se como Novo Utilizador");
                Console.WriteLine("[2] Consultar Livros Disponíveis");
                Console.WriteLine("[3] Devolver Livros");
                Console.WriteLine("[0] Voltar ao Menu Principal");
                Console.Write("Escolha a opção que pretende: ");
                string opcao = (Console.ReadLine());

                switch (opcao)
                {
                    case "1":
                        RegistarNovoUtilizador(bibliotecaSistema);
                        break;
                    case "2":
                        ListarLivrosDisponiveis(bibliotecaSistema);
                        break;
                    case "3":
                        RegistarDevolucao(bibliotecaSistema);
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
            Console.WriteLine("\n--- Registar-se como Novo Utilizador ---");

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
            } while (string.IsNullOrWhiteSpace(morada)); // Repete enquanto a morada for vazia ou só espaços

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

        private void ListarLivrosDisponiveis(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();
            Console.WriteLine("\n--- Livros Disponíveis ---");
            var lista = bibliotecaSistema.ObterLivrosDisponiveis();

            if (lista.Count == 0)
            {
                Console.WriteLine("Não há livros disponíveis no momento.");
            }
            else
            {
                foreach (var livro in lista)
                {
                    Console.WriteLine(livro);
                }
            }
        }

        private void RegistarDevolucao(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();
            Console.WriteLine("\n--- Devolver Livro ---");
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
                    object utilizador = bibliotecaSistema.GetUtilizadorById(utilizadorID); // Assume que retorna null se não existir

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
                    object livro = bibliotecaSistema.GetLivroById(livroID); // Assume que retorna null se não existir

                    if (livro != null) // Verificar se o método encontrou o livro
                    {
                        livroEncontrado = true; // ID válido e livro existe
                    }
                    else
                    {
                        Console.WriteLine($"Erro: Livro com ID {livroID} não encontrado no sistema. Por favor, verifique o ID.");
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
        public void FazerLoginUtilizador(BibliotecaSistema bibliotecaSistema)
        {
            
            string username;
            string password;
            Utilizador utilizador = null;

            do
            {
                Console.Write("\nUsername: ");
                username = Console.ReadLine();
                Console.Write("Password: ");
                password = LerPasswordComAsteriscos();

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
        public string LerPasswordComAsteriscos()
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
