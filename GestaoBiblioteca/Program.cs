using Figgle;
using System;

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
bibliotecaSistema.AdicionarUtilizador("David Bruno", "Rua de Mafamude, 123", "912345678", "David Bruno", "password");
bibliotecaSistema.AdicionarUtilizador("Rita Faria", "Av. da Liberdade, 456", "934567890", "Rita Faria", "password");
bibliotecaSistema.AdicionarUtilizador("João Silva", "Rua da Alegria, 789", "945678901", "João Silva", "password");

// Funcionário
bibliotecaSistema.AdicionarFuncionario("Ana Costa", "Travessa do Sol, 78", "926789123", "Bibliotecária", "Ana Costa", "password");
bibliotecaSistema.AdicionarFuncionario("Pedro Santos", "Rua Nova, 12", "938765432", "Assistente", "Pedro Santos", "password");

            Console.WriteLine(
    FiggleFonts.Ogre.Render("Biblioteca"));
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine("     Sistema de Gestão de Biblioteca ");
                Console.WriteLine("=====================================");
                Console.WriteLine("[1] Aceder como Funcionário");
                Console.WriteLine("[2] Aceder como Utilizador");
                Console.WriteLine("[0] Sair");
                Console.Write("Escolha a opção que pretende: ");



                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        funcionarioServico.FazerLoginFuncionario(bibliotecaSistema);
                        funcionarioServico.MenuFuncionario(bibliotecaSistema);
                        break;
                    case "2":
                        utilizadorServico.FazerLoginUtilizador(bibliotecaSistema);
                        utilizadorServico.MenuUtilizador(bibliotecaSistema);
                        break;
                    case "0":
                        sair = true;
                        Console.WriteLine("A sair do sistema... Até breve!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        PressioneParaContinuar();
                        break;
                }
            }
        }

        static void PressioneParaContinuar()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}