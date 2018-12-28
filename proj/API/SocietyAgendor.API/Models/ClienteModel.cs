using System;
using System.ComponentModel.DataAnnotations;

namespace SocietyAgendor.API.Models
{
    public class ClienteModel
    {
        public int? Cliente_Id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "É permitido até 255 caracteres.")]
        public string Cliente_Nome { get; set; }

        [Required]
        public string Cliente_CPF { get; set; }

        [Required]
        public string Cliente_RG { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Cliente_Email { get; set; }

        [Required]
        public DateTime Cliente_DtNascimento { get; set; }

        [Required]
        public string Cliente_Telefone { get; set; }

        [Required]
        public string Cliente_Celular { get; set; }

        public int? Endereco_Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "É permitido até 100 caracteres.")]
        public string Endereco_Logradouro { get; set; }

        [Required]
        public string Endereco_Numero { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "É permitido até 50 caracteres.")]
        public string Endereco_Bairro { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "É permitido até 100 caracteres.")]
        public string Endereco_Cidade { get; set; }

        [Required]
        [StringLength(2, ErrorMessage = "É permitido até 2 caracteres.")]
        public string Endereco_Estado { get; set; }

        [StringLength(255, ErrorMessage = "É permitido até 255 caracteres.")]
        public string Endereco_Complemento { get; set; }

        [Required]
        public string Endereco_CEP { get; set; }
    }
}
