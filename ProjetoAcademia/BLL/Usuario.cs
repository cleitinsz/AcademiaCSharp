﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcademia.BLL
{
    internal class Usuario
    {
        private long codUsuario;
        private string nome;
        private string email;
        private string senha;

        public long CodUsuario { get => codUsuario; set => codUsuario = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Senha { get => senha; set => senha = value; }
    }
}
