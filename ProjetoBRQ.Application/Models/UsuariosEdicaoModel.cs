using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoBRQ.Application.Models
{
    public class UsuariosEdicaoModel
    {
        public Guid IdUsuario { get; set; } //campo oculto

        [Required(ErrorMessage = "Por favor, informe o nome da usuário")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Por favor, informe o sobrenome da usuário")]
        public string SobrenomeUsuario { get; set; }

        [StringLength(11, ErrorMessage = "Por favor, informe {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o cpf do usuário.")]
        public string CpfUsuario { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do usuário")]
        public string DataNascimentoUsuario { get; set; }

        [StringLength(8, ErrorMessage = "Por favor, informe {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o CEP do usuário")]
        public string CepUsuario { get; set; }

        [Required(ErrorMessage = "Por favor, informe o endereço do usuário")]
        public string EnderecoUsuario { get; set; }

        [Required(ErrorMessage = "Por favor, informe o número do endereço do usuário")]
        public string NumeroUsuario { get; set; }

        [Required(ErrorMessage = "Por favor, informe o complemento do endereço do usuário")]
        public string ComplementoUsuario { get; set; }

        [Required(ErrorMessage = "Por favor, informe a cidade do endereço do usuário")]
        public string CidadeUsuario { get; set; }

        [Required(ErrorMessage = "Por favor, informe o estado do endereço do usuário")]
        public string EstadoUsuario { get; set; }
    }
}
