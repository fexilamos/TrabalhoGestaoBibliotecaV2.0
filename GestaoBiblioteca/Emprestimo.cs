using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    public enum EstadoEmprestimo
    {
        Ativo,
        Devolvido
    }
    class Emprestimo
    {
        private static int proximoID = 1;
        private const int DuracaoEmpresitmoDias = 3;
        public int ID {  get; private set; }
        public int LivroID { get; private set; }
        public int UtilizadorID { get; private set; }
        
        public DateTime DataEmprestimo { get; private set; }
        public DateTime DataDevolucaoPrevista { get; private set; }
        public EstadoEmprestimo Estado {  get; set; }

        public Emprestimo (int livroID, int utilizadorID)
        {
            ID = proximoID;
            LivroID = livroID;
            UtilizadorID = utilizadorID;
            DataEmprestimo = DateTime.Now; //Vai ficar com a hora do computador
            DataDevolucaoPrevista = DataEmprestimo.AddDays(DuracaoEmpresitmoDias);
            Estado = EstadoEmprestimo.Ativo;
        }
        public override string ToString()
        {

            //Usa o operador ternário(condição? valor_se_true : valor_se_false) para definir o seu valor.
            //Condição: Verifica se a propriedade 'Estado' deste empréstimo é igual ao valor 'Devolvido' do enum 'EstadoEmprestimo'.
            string estadoStr = Estado == EstadoEmprestimo.Devolvido
                             // Se a condição for VERDADEIRA (Estado é Devolvido):
                             ? "Devolvido"// Atribui a string "Devolvido" a estadoStr.
                             // Se a condição for FALSA (Estado é Ativo):
                             // Usa interpolação de string ($"...") para criar a string.
                             // Insere a DataDevolucaoPrevista formatada (dd/MM/yyyy).
                             : $"Ativo (Devolver até {DataDevolucaoPrevista:dd/MM/yyyy})";
            // Após esta linha, a variável estadoStr contém ou "Devolvido" ou "Ativo (Devolver até ...)"
            return $"ID Empr: {ID} | Livro ID: {LivroID} | Utilizador ID: {UtilizadorID} | Data: {DataEmprestimo:dd/MM/yyyy} | Estado: {estadoStr}";
        }

    }
    

    

}
