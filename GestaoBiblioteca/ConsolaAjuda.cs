using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoBiblioteca;

namespace GestaoBiblioteca
{
    public static class ConsolaAjuda // Classe auxiliar estática que fornece métodos comuns para interação com a consola (input, output, validação).
    {
        // Pausa a execução da aplicação na consola até que o utilizador pressione uma tecla.
        public static void PressioneParaContinuar()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey(true);
        }

        // Mostra asteriscos (*) na password enquanto o utilizador a digita.
        public static string LerPasswordComAsteriscos()
        {
            string password = "";
            ConsoleKeyInfo tecla;

            do
            {
                // Lê a próxima tecla pressionada. 'true' significa que o caractere da tecla não é exibido na consola.
                tecla = Console.ReadKey(true);

                // Verifica se a tecla pressionada NÃO é Backspace nem Enter
                if (tecla.Key != ConsoleKey.Backspace && tecla.Key != ConsoleKey.Enter)
                {
                    // Adiciona o caractere à string da password
                    password += tecla.KeyChar;
                    // Exibe um asterisco na consola para indicar que um caractere foi digitado
                    Console.Write("*");
                }
                // Verifica se a tecla é Backspace E se há caracteres na password para apagar
                else if (tecla.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    // Remove o último caractere da string da password
                    password = password.Substring(0, password.Length - 1);

                    // Código para apagar o último asterisco exibido na consola:
                    // 1. Obtém a posição atual do cursor na linha.
                    int cursorPos = Console.CursorLeft;
                    // 2. Move o cursor uma posição para trás.
                    Console.SetCursorPosition(cursorPos - 1, Console.CursorTop);
                    // 3. Escreve um espaço em branco para "apagar" o asterisco.
                    Console.Write(" ");
                    // 4. Move o cursor de volta para a posição onde estava antes de escrever o espaço,
                    //    para que o próximo caractere digitado apareça no lugar correto.
                    Console.SetCursorPosition(cursorPos - 1, Console.CursorTop);
                }
                //So se faz com o espaço em branco pois outras teclas não são tomadas em conta por o ConsoleKey

            } while (tecla.Key != ConsoleKey.Enter); // Continua este ciclo até que o utilizador pressione a tecla Enter

            Console.WriteLine(); // Move o cursor para a próxima linha após a entrada da password
            return password; // Retorna a string da password lida
        }

        public static string ValidacaoInput(string prompt)
        {
            string input;
            do
            {
                // Exibe a mensagem ao utilizador
                Console.Write(prompt);
                // Lê a linha de input do utilizador
                input = Console.ReadLine();

                // Verifica se a string lida é nula, vazia ou contém apenas espaços em branco
                if (string.IsNullOrWhiteSpace(input))
                {
                    // Exibe uma mensagem de erro se a validação falhar
                    Console.WriteLine("[Erro]: Este campo não pode estar vazio. Por favor, insira um valor válido.");
                    // O ciclo continua porque 'input' é inválido
                }
            } while (string.IsNullOrWhiteSpace(input)); // Repete enquanto a string for inválida
            return input; // Retorna a string quando for válida
        }

        public static int ConverteInt(string prompt)
        {
            string input;
            int id; // Variável para armazenar o resultado da conversão
            do
            {
                // Exibe a mensagem e lê a entrada
                Console.Write(prompt);
                input = Console.ReadLine();

                // Tenta converter a string lida para um número inteiro.
                // TryParse retorna true se a conversão for bem-sucedida e armazena o resultado em 'result'.
                // Retorna false se a conversão falhar.
                if (!int.TryParse(input, out id))
                {
                    // Exibe mensagem de erro se a conversão falhar
                    Console.WriteLine("[Erro]: Entrada inválida. Por favor, insira um número inteiro.");
                    // O ciclo continua porque TryParse retornou false
                }
            } while (!int.TryParse(input, out id)); // Repete enquanto a conversão falhar
            return id; // Retorna o número inteiro válido
        }

        public static string ValidacaoTelefone(string prompt)
        {
            string telefone;
            bool telefoneValido = false;
            do
            {
                // Reutiliza o metodo ValidacaoInput para garantir que o input não está vazio
                telefone = ValidacaoInput(prompt);

                // Verifica se o comprimento da string é exatamente 9
                if (telefone.Length != 9)
                {
                    Console.WriteLine("[Erro]: O número de telefone deve ter exatamente 9 dígitos.");
                    telefoneValido = false; // A validação falhou
                }
                // Verifica que todos os caracteres na string são dígitos
                else if (!telefone.All(char.IsDigit))
                {
                    Console.WriteLine("[Erro]: O número de telefone deve conter apenas números.");
                    telefoneValido = false; // A validação falhou
                }
                else
                {
                    telefoneValido = true; // Todas as validações passaram
                }
            } while (!telefoneValido); // Repete enquanto a string não for considerada um telefone válido
            return telefone; // Retorna o número de telefone válido
        }


        public static string ValidacaoNomeUsuario(string prompt, BibliotecaSistema bibliotecaSistema)
        {
            string username;
            bool usernameValido = false;
            do
            {
                // Reutiliza ValidacaoInput para garantir que o input não está vazio
                username = ValidacaoInput(prompt);

                // Valida se o username já existe no sistema usando o método da BibliotecaSistema
                if (bibliotecaSistema.UtilizadorExiste(username))
                {
                    Console.WriteLine($"[Erro]: O Nome de Usuario '{username}' já está em uso. Por favor, escolha outro.");
                    usernameValido = false; // A validação falhou porque já existe
                }
                else
                {
                    usernameValido = true; // O username é válido e único
                }
            } while (!usernameValido); // Repete enquanto o username for inválido (vazio ou já existente)
            return username; // Retorna o username válido e único
        }

        
        public static string ValidacaoSenha(string prompt, string confirmationPrompt, int minLength = 8) // Senha requer 8 carateres minimo
        {
            string password;
            string confirmacaoPassword;
            bool passwordValida = false; // Validação da primeira senha
            bool passwordsCorrespondem = false; // Validação se a confirmação coincide

            // Primeira senha
            do
            {
                Console.Write(prompt);
                // Reutiliza LerPasswordComAsteriscos para ler a senha sem a exibir
                password = LerPasswordComAsteriscos();

                // Valida se a senha não está vazia/branca
                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("[Erro]: A senha não pode estar vazia.");
                    passwordValida = false;
                }
                // Valida o comprimento mínimo
                else if (minLength > 0 && password.Length < minLength)
                {
                    Console.WriteLine($"[Erro]: A senha deve ter pelo menos {minLength} caracteres.");
                    passwordValida = false;
                }
                else
                {
                    passwordValida = true; // A senha passou nas validações de formato e comprimento
                }
            } while (!passwordValida); // Repete até que a primeira senha seja válida

            // Validar segunda senha
            // Este ciclo repete até que a confirmação corresponda à senha original
            do
            {
                Console.Write(confirmationPrompt);
                // Reutiliza LerPasswordComAsteriscos para ler a confirmação
                confirmacaoPassword = LerPasswordComAsteriscos();

                // Valida se a confirmação não está vazia/branca
                if (string.IsNullOrWhiteSpace(confirmacaoPassword))
                {
                    Console.WriteLine("[Erro]: A confirmação da senha não pode estar vazia.");
                    passwordsCorrespondem = false;
                }
                // Compara a confirmação com a senha original
                else if (confirmacaoPassword != password)
                {
                    Console.WriteLine("[Erro]: As senhas não correspondem. Por favor, tente novamente.");
                    passwordsCorrespondem = false; // A validação falhou
                }
                else
                {
                    passwordsCorrespondem = true; // As senhas coincidem
                }
            } while (!passwordsCorrespondem); // Repete até que as senhas correspondam

            return password; // Retorna a senha
        }

        public static Utilizador ProcurarUtilizadorPorID(BibliotecaSistema bibliotecaSistema)
        {
            int utilizadorID;
            Utilizador utilizador = null; // Variável para armazenar o objeto Utilizador encontrado
            bool encontrado = false; // Flag para controlar se o utilizador foi encontrado

            do
            {
                // Reutiliza ConverteInt para obter um ID que seja um número inteiro válido
                utilizadorID = ConverteInt("Insira o ID do Utilizador: ");

                // Tenta encontrar o utilizador com o ID fornecido usando o método da BibliotecaSistema
                utilizador = bibliotecaSistema.UtilizadorID(utilizadorID);

                // Verifica se o método retornou um objeto (significa que encontrou o utilizador)
                if (utilizador != null)
                {
                    encontrado = true; // Utilizador encontrado, sai do ciclo
                }
                else
                {
                    // Exibe mensagem de erro se o utilizador não foi encontrado com esse ID
                    Console.WriteLine($"[Erro]: O Utilizador com ID {utilizadorID} não foi encontrado no sistema. Por favor, verifique o ID.");
                    // 'encontrado' continua false, então o ciclo repete
                }
            } while (!encontrado); // Repete enquanto um utilizador com o ID inserido não for encontrado

            return utilizador; // Retorna o objeto Utilizador encontrado (garantido que não é null por causa do ciclo)
        }

        public static Livro ProcurarLivroPorID(BibliotecaSistema bibliotecaSistema)
        {
            int livroID;
            Livro livro = null; // Variável para armazenar o objeto Livro encontrado
            bool encontrado = false; // Flag para controlar se o livro foi encontrado

            do
            {
                // Reutiliza GetIntInput para obter um ID que seja um número inteiro válido
                livroID = ConverteInt("Insira o ID do Livro: ");

                // Tenta encontrar o livro com o ID fornecido usando o método da BibliotecaSistema
                livro = bibliotecaSistema.LivroID(livroID);

                // Verifica se o método retornou um objeto (significa que encontrou o livro)
                if (livro != null)
                {
                    encontrado = true; // Livro encontrado, podemos sair do ciclo
                }
                else
                {
                    // Exibe mensagem de erro se o livro não foi encontrado com esse ID
                    Console.WriteLine($"[Erro]: Livro com ID {livroID} não encontrado no sistema. Por favor, verifique o ID.");
                    // 'encontrado' continua false, então o ciclo 'do-while' repete
                }
            } while (!encontrado); // Repete enquanto um livro com o ID inserido não for encontrado

            return livro; // Retorna o objeto Livro encontrado (garantido que não é null por causa do ciclo)
        }

        
        public static string TituloUnico(string prompt, BibliotecaSistema bibliotecaSistema)
        {
            string titulo;
            bool tituloValido = false;
            do
            {
                // Reutiliza ValidacaoInput para garantir que o input não está vazio
                titulo = ValidacaoInput(prompt);

                // Valida se o título já existe no sistema usando o método da BibliotecaSistema (comparação ignorando maiúsculas/minúsculas)
                if (bibliotecaSistema.LivroExiste(titulo))
                {
                    Console.WriteLine($"[Erro]: O livro com o título '{titulo}' já existe no sistema. Por favor, escolha outro título.");
                    tituloValido = false; // A validação falhou porque já existe
                }
                else
                {
                    tituloValido = true; // O título é válido e único
                }
            } while (!tituloValido); // Repete enquanto o título for inválido (vazio ou já existente)
            return titulo; // Retorna o título válido e único
        }

    }
}
