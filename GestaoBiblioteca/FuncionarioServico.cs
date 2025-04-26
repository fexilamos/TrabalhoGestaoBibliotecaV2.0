using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoBiblioteca;

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

                if (!voltar) ConsolaAjuda.PressioneParaContinuar();
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

                if (!voltar) ConsolaAjuda.PressioneParaContinuar();
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

                if (!voltar) ConsolaAjuda.PressioneParaContinuar();
            }
        }

        private void RegistarNovoUtilizador(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();
            Console.WriteLine("\n--- Registar Novo Utilizador ---");

            string nome = ConsolaAjuda.ValidacaoInput("Insira o seu nome: ");

            string morada = ConsolaAjuda.ValidacaoInput("Insira a sua morada: ");

            string telefone = ConsolaAjuda.ValidacaoTelefone("Insira o seu numero de telefone (9 dígitos): ");

            string username = ConsolaAjuda.ValidacaoNomeUsuario("Insira o seu Nome do Usuario: ", bibliotecaSistema);

            string password = ConsolaAjuda.ValidacaoSenha("Insira a sua senha: ", "Confirme a senha: ", minLength: 8);

            bibliotecaSistema.AdicionarUtilizador(nome, morada, telefone, username, password);
            Console.WriteLine("Utilizador registado com sucesso!");
        }

        private void RegistarNovoFuncionario(BibliotecaSistema bibliotecaSistema)
        {
            Console.Clear();
            Console.WriteLine("\n--- Registar Novo Funcionário ---");

            string nome = ConsolaAjuda.ValidacaoInput("Insira o seu nome: ");

            string morada = ConsolaAjuda.ValidacaoInput("Insira a sua morada: ");

            string telefone = ConsolaAjuda.ValidacaoTelefone("Insira o seu numero de telefone (9 dígitos): ");

            string cargo = ConsolaAjuda.ValidacaoInput("Insira o seu cargo: ");

            string username = ConsolaAjuda.ValidacaoNomeUsuario("Insira o seu Nome do Usuario: ", bibliotecaSistema);

            string password = ConsolaAjuda.ValidacaoSenha("Insira a sua senha: ", "Confirme a senha: ", minLength: 8);

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

            
            string titulo = ConsolaAjuda.TituloUnico("Insira o Título: ", bibliotecaSistema);

            string autor = ConsolaAjuda.ValidacaoInput("Insira o Autor: ");

            int ano = ConsolaAjuda.ConverteInt("Insira o Ano de Publicação: ");
            
            int exemplares = ConsolaAjuda.ConverteInt("Insira o Número de Exemplares: ");

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

            Utilizador utilizador = ConsolaAjuda.ProcurarUtilizadorPorID(bibliotecaSistema);

            int utilizadorID = utilizador.ID;

            Livro livro = ConsolaAjuda.ProcurarLivroPorID(bibliotecaSistema);

            int livroID = livro.ID;

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
