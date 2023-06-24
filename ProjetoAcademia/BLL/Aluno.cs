using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcademia.BLL
{
    internal class Aluno
    {
        private long codAluno;
        private string nome;
        private string email;
        private string cpf;
        private string telefone;

        public long CodAluno { get => codAluno; set => codAluno = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Telefone { get => telefone; set => telefone = value; }
    }
}
