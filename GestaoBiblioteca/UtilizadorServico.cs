using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoBiblioteca;

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

                if (!voltar) ConsolaAjuda.PressioneParaContinuar();
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
