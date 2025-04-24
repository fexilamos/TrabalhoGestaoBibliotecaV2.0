using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    class Livro
    {
        private static int proximoID = 1;

        public int ID {get; private set;}
        public string Titulo { get; set; }
        public string Autor { get; set; }
      
        public int Ano { get; set; }
        public int Exemplares {  get; set; }

        public Livro(string titulo, string autor, int ano, int exemplares)
        {
            ID = proximoID++;
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Exemplares = exemplares;
        }

        public override string ToString()
        {
            return $"ID: {ID} | Título: {Titulo} | Autor: {Autor} | Ano: {Ano} | Disp: {Exemplares}";
        }

        public bool EstaDisponivel()
        {
            return Exemplares > 0; // Verifica se há mais de 0 exemplares disponíveis
        }

        // Método para ser chamado QUANDO um empréstimo é feito
        public void DecrementarDisponiveis()
        {
            if (EstaDisponivel()) // Verifica antes de decrementar
            {
                Exemplares--;
            }
            // Poderia adicionar um 'else throw new Exception(...)' se tentar decrementar sem disponibilidade
        }

        // Método para ser chamado QUANDO uma devolução é feita
        public void IncrementarDisponiveis()
        {
            // Assume-se que só incrementa se um foi previamente decrementado.
            // Poderia adicionar lógica para não exceder um nº total se o tivesse guardado.
            Exemplares++;
        }
        
    }

    

    
}
