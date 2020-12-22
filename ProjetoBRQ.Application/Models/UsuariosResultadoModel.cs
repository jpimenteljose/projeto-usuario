using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBRQ.Application.Models
{
    public class UsuariosResultadoModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }

        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }


    }
}
