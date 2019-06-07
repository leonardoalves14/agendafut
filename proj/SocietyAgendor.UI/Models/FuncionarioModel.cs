using SocietyAgendor.UI.Service;
using System;
using System.ComponentModel.DataAnnotations;

namespace SocietyAgendor.UI.Models
{
    public class FuncionarioModel
    {
        public int? Funcionario_Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [StringLength(255, ErrorMessage = "É permitido até 255 caracteres.")]
        public string Funcionario_Nome { get; set; }

        [Required]
        [CPF]
        [Display(Name = "CPF")]
        public string Funcionario_CPF { get; set; }

        [Required]
        [Display(Name = "RG")]
        public string Funcionario_RG { get; set; }

        [Required]
        [Display(Name = "Data Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Funcionario_DtNascimento { get; set; }

        [Required]
        [Display(Name = "Celular")]
        public string Funcionario_Celular { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [StringLength(200, ErrorMessage = "É permitido até 200 caracteres.")]
        public string Funcionario_Email { get; set; }

        [Required]
        [Display(Name = "Data Admissão")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FuncionarioDtAdmissao { get; set; }

        [Required]
        [Display(Name = "Telefone")]
        public string Funcionario_Telefone { get; set; }

        public int? Endereco_Id { get; set; }

        [Required]
        [Display(Name = "Número")]
        [StringLength(10, ErrorMessage = "É permitido até 10 caracteres.")]
        public string Endereco_Numero { get; set; }

        [Required]
        [Display(Name = "Rua")]
        [StringLength(50, ErrorMessage = "É permitido até 50 caracteres.")]
        public string Endereco_Logradouro { get; set; }

        [Required]
        [Display(Name = "Bairro")]
        [StringLength(50, ErrorMessage = "É permitido até 50 caracteres.")]
        public string Endereco_Bairro { get; set; }

        [Display(Name = "Complemento")]
        [StringLength(100, ErrorMessage = "É permitido até 100 caracteres.")]
        public string Endereco_Complemento { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        [StringLength(100, ErrorMessage = "É permitido até 100 caracteres.")]
        public string Endereco_Cidade { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [StringLength(2, ErrorMessage = "É permitido até 2 caracteres.")]
        public string Endereco_Estado { get; set; }

        [Required]
        [Display(Name = "CEP")]
        public string Endereco_CEP { get; set; }

        [Required]
        [Display(Name = "Id do Cargo")]
        public int? Cargo_Id { get; set; }

        [Display(Name = "Cargo")]
        public string Cargo_Desc { get; set; }

        [Required]
        [Display(Name = "ID do Estabelecimento")]
        public int? Estabelecimento_Id { get; set; }

        [Display(Name = "Estabelecimento")]
        public string Estabelecimento_Nome { get; set; }

        [Required]
        [Display(Name = "Id do Usuário")]
        public int? Usuario_Id { get; set; }

        [Display(Name = "Usuário")]
        public string Usuario_Login { get; set; }
    }
}
