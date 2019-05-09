﻿using System.ComponentModel.DataAnnotations;

namespace SocietyAgendor.UI.Models
{
    public class EstabelecimentoModel
    {
        public int? Estabelecimento_Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "É permitido até 200 caracteres.")]
        public string Estabelecimento_Nome { get; set; }

        [Required]
        public string Estabelecimento_CNPJ { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "É permitido até 20 caracteres.")]
        public string Estabelecimento_Celular { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(300, ErrorMessage = "É permitido até 300 caracteres.")]
        public string Estabelecimento_Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "É permitido até 20 caracteres.")]
        public string Estabelecimento_Telefone { get; set; }

        public int? Endereco_Id { get; set; }

        [Required]
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
        public string Endereco_CEP { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "É permitido até 100 caracteres.")]
        public string Endereco_Cidade { get; set; }

        [Required]
        [StringLength(2, ErrorMessage = "É permitido até 2 caracteres.")]
        public string Endereco_Estado { get; set; }

        //public int? Estabelecimento_Id { get; set; }

        //[Required]
        //[Display(Name = "Estabelecimento")]
        //[StringLength(200, ErrorMessage = "É permitido até 200 caracteres.")]
        //public string Estabelecimento_Nome { get; set; }

        //[Required]
        //[EmailAddress]
        //[Display(Name = "Email")]
        //[StringLength(200, ErrorMessage = "É permitido até 200 caracteres.")]
        //public string Estabelecimento_Email { get; set; }

        //[Required]
        //[Display(Name = "Telefone")]
        //[StringLength(20, ErrorMessage = "É permitido até 20 caracteres.")]
        //public string Estabelecimento_Telefone { get; set; }

        //public int? Endereco_Id { get; set; }

        //[Required]
        //[Display(Name = "Número")]
        //public string Endereco_Numero { get; set; }

        //[Required]
        //[Display(Name = "Rua")]
        //[StringLength(50, ErrorMessage = "É permitido até 50 caracteres.")]
        //public string Endereco_Logradouro { get; set; }

        //[Required]
        //[Display(Name = "Bairro")]
        //[StringLength(50, ErrorMessage = "É permitido até 50 caracteres.")]
        //public string Endereco_Bairro { get; set; }

        //[Required]
        //[Display(Name = "Cidade")]
        //[StringLength(100, ErrorMessage = "É permitido até 100 caracteres.")]
        //public string Endereco_Cidade { get; set; }

        //[Required]
        //[Display(Name = "UF")]
        //[StringLength(2, ErrorMessage = "É permitido até 2 caracteres.")]
        //public string Endereco_Estado { get; set; }
    }
}
