using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    class TxtHelper
    {

        public static string GerarFichaFuncionario(string nome, string morada, string telefone, string cargo)
        {
            string nomeSeguro = NomeSeguro(nome);
            string nomeFicheiro = $"Funcionario_{nomeSeguro}_{DateTime.Now:yyyyMMddHHmmss}.txt";
            string caminhoFicheiro = Path.Combine(@"C:\Temp", nomeFicheiro);

            try
            {
                using (StreamWriter sw = new StreamWriter(caminhoFicheiro))
                {
                    sw.WriteLine("===========================================");
                    sw.WriteLine("           FICHA DE FUNCIONÁRIO            ");
                    sw.WriteLine("===========================================");
                    sw.WriteLine();
                    sw.WriteLine($"  Nome     : {nome}");
                    sw.WriteLine($"  Morada   : {morada}");
                    sw.WriteLine($"  Telefone : {telefone}");
                    sw.WriteLine($"  Cargo    : {cargo}");
                    sw.WriteLine();
                    sw.WriteLine("-------------------------------------------");
                    sw.WriteLine($"  Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                    sw.WriteLine("===========================================");
                }
                Console.WriteLine($"Ficha de Funcionário gerada em: {caminhoFicheiro}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRO ao gerar ficha de funcionário: " + ex.Message);
            }

            return caminhoFicheiro;
        }


        public static string GerarFichaUtilizador(string nome, string morada, string telefone)
        {
            string nomeSeguro = NomeSeguro(nome);
            string nomeFicheiro = $"Ficha_{nomeSeguro}_{DateTime.Now:yyyyMMddHHmmss}.txt";
            string caminhoFicheiro = Path.Combine(@"C:\Temp", nomeFicheiro);

            try
            {
                using (StreamWriter sw = new StreamWriter(caminhoFicheiro))
                {
                    sw.WriteLine("===========================================");
                    sw.WriteLine("           FICHA DE UTILIZADOR             ");
                    sw.WriteLine("===========================================");
                    sw.WriteLine();
                    sw.WriteLine($"  Nome     : {nome}");
                    sw.WriteLine($"  Morada   : {morada}");
                    sw.WriteLine($"  Telefone : {telefone}");
                    sw.WriteLine();
                    sw.WriteLine("-------------------------------------------");
                    sw.WriteLine($"  Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                    sw.WriteLine("===========================================");
                }
                Console.WriteLine($"Ficha gerada em: {caminhoFicheiro}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRO ao gerar TXT: " + ex.Message);
            }

            return caminhoFicheiro;
        }

        public static string GerarReciboEmprestimo(string nomeCliente, string nomeLivro, DateTime dataEmprestimo)
        {
            string nomeSeguro = NomeSeguro(nomeCliente);
            string nomeFicheiro = $"Recibo_{nomeSeguro}_{dataEmprestimo:yyyyMMddHHmmss}.txt";
            string caminhoFicheiro = Path.Combine(@"C:\Temp", nomeFicheiro);

            try
            {
                using (StreamWriter sw = new StreamWriter(caminhoFicheiro))
                {
                    sw.WriteLine("===========================================");
                    sw.WriteLine("             RECIBO DE EMPRÉSTIMO          ");
                    sw.WriteLine("===========================================");
                    sw.WriteLine();
                    sw.WriteLine($"  Cliente : {nomeCliente}");
                    sw.WriteLine($"  Livro   : {nomeLivro}");
                    sw.WriteLine($"  Data do Empréstimo: {dataEmprestimo:dd/MM/yyyy}");
                    sw.WriteLine($"  Data de Devolução Prevista: {dataEmprestimo.AddDays(3):dd/MM/yyyy}");
                    sw.WriteLine();
                    sw.WriteLine("-------------------------------------------");
                    sw.WriteLine($"  Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                    sw.WriteLine("===========================================");
                }
                Console.WriteLine($"Recibo gerado em: {caminhoFicheiro}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRO ao gerar recibo TXT: " + ex.Message);
            }

            return caminhoFicheiro;
        }

        private static string NomeSeguro(string nome)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                nome = nome.Replace(c, '_');
            }
            return nome.Replace(" ", "_");
        }
    }
}
