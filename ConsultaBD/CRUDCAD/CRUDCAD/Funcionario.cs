using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCAD
{
    public class Funcionario:Pessoa
    {
        public string Cargo;

        public Funcionario()
        { }
        public Funcionario
            (string nome,
            string cpf,
            string cargo) : this()
        {
            this.Nome = nome;
            this.CPF = cpf;
            this.Cargo = cargo;
        }
    }
}
