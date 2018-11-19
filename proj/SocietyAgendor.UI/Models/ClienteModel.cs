using System;
using System.ComponentModel.DataAnnotations;

namespace SocietyAgendor.UI.Models
{
    public class ClienteModel
    {
        public int? Cliente_Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [StringLength(255, ErrorMessage = "É permitido até 255 caracteres.")]
        public string Cliente_Nome { get; set; }

        [Required]
        [Display(Name = "CPF")]
        public string Cliente_CPF { get; set; }

        [Required]
        [Display(Name = "RG")]
        public string Cliente_RG { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Cliente_Email { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        public DateTime Cliente_DtNascimento { get; set; }

        [Required]
        [Display(Name = "Telefone")]
        public string Cliente_Telefone { get; set; }

        [Required]
        [Display(Name = "Celular")]
        public string Cliente_Celular { get; set; }

        public int? Endereco_Id { get; set; }

        [Required]
        [Display(Name = "Rua")]
        [StringLength(50, ErrorMessage = "É permitido até 50 caracteres.")]
        public string Endereco_Logradouro { get; set; }

        [Required]
        [Display(Name = "Nº")]
        public string Endereco_Numero { get; set; }

        [Required]
        [Display(Name = "Bairro")]
        [StringLength(50, ErrorMessage = "É permitido até 50 caracteres.")]
        public string Endereco_Bairro { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        [StringLength(100, ErrorMessage = "É permitido até 100 caracteres.")]
        public string Endereco_Cidade { get; set; }

        [Required]
        [Display(Name = "UF")]
        [StringLength(2, ErrorMessage = "É permitido até 2 caracteres.")]
        public string Endereco_Estado { get; set; }

        [StringLength(100, ErrorMessage = "É permitido até 100 caracteres.")]
        [Display(Name = "Complemento")]
        public string Endereco_Complemento { get; set; }

        [Required]
        [Display(Name = "CEP")]
        public string Endereco_CEP { get; set; }
    }
}
