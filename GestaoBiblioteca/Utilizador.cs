using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    class Utilizador
    {
        private static int proximoID = 1; // Contador para gerar IDs unicos

        //Propiedades Utilizador
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Telefone { get; set; }
        public int ID { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Utilizador(string nome, string morada, string telefone, string username, string password)
        {
            ID = proximoID++;
            Nome = nome;
            Morada = morada;
            Telefone = telefone; 
            Username = username;
            Password = password;
        }

        //Dois metodos para contruir uma string de apresentação de cada objeto. Desta maneira ja não precisamos do metodo ExibirInformacoes
        public virtual string ObterTipo()
        {
            return "Utilizador";

        }

        public override string ToString()
        {
            return $"ID: {ID} | Nome: {Nome} ({ObterTipo()}) | Morada: {Morada} | Telefone: {Telefone}";
        }
        
      


    }
}


