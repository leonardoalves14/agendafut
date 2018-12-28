using System;
using System.ComponentModel.DataAnnotations;

namespace SocietyAgendor.API.Models
{
    public class FuncionarioModel
    {
        public int? Funcionario_Id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "É permitido até 255 caracteres.")]
        public string Funcionario_Nome { get; set; }

        [Required]
        public string Funcionario_CPF { get; set; }

        [Required]
        public string Funcionario_RG { get; set; }

        [Required]
        public DateTime Funcionario_DtNascimento { get; set; }

        [Required]
        public string Funcionario_Celular { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "É permitido até 300 caracteres.")]
        public string Funcionario_Email { get; set; }

        [Required]
        public DateTime FuncionarioDtAdmissao { get; set; }

        [Required]
        public string Funcionario_Telefone { get; set; }

        public int? Endereco_Id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "É permitido até 10 caracteres.")]
        public string Endereco_Numero { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "É permitido até 100 caracteres.")]
        public string Endereco_Logradouro { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "É permitido até 50 caracteres.")]
        public string Endereco_Bairro { get; set; }

        [StringLength(255, ErrorMessage = "É permitido até 255 caracteres.")]
        public string Endereco_Complemento { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "É permitido até 100 caracteres.")]
        public string Endereco_Cidade { get; set; }

        [Required]
        [StringLength(2, ErrorMessage = "É permitido até 2 caracteres.")]
        public string Endereco_Estado { get; set; }

        [Required]
        public string Endereco_CEP { get; set; }

        [Required]
        public int? Cargo_Id { get; set; }

        public string Cargo_Desc { get; set; }

        [Required]
        public int? Estabelecimento_Id { get; set; }

        public string Estabelecimento_Nome { get; set; }

        [Required]
        public int? Usuario_Id { get; set; }

        public string Usuario_Login { get; set; }
    }
}
