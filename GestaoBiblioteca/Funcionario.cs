using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    class Funcionario : Utilizador
    {

        private static int proximoCodFuncionario = 101; //Contador estatico APENAS para Funcionario

        public int CodigoFuncionario { get; private set; }
        public string Cargo { get; set; }

        public Funcionario(string nome, string morada, string telefone, string cargo, string username, string password) 
            : base (nome, morada, telefone, username, password)
        {
            CodigoFuncionario = proximoCodFuncionario++;
            Cargo = cargo;
        }


        //Dois metodos para contruir uma string de apresentação de cada objeto. Desta maneira ja não precisamos do metodo ExibirInformacoes

        public override string ObterTipo()
        {
            return "Funcionário";
        }

        public override string ToString()
        {
            return base.ToString() + $"| Código: {CodigoFuncionario} | Cargo: {Cargo}";
        }

    }


}
