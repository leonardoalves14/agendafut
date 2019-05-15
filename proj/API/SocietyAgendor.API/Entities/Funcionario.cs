using System;

namespace SocietyAgendor.API.Entities
{
    public class Funcionario
    {
        public int? Funcionario_Id { get; set; }
        public string Funcionario_Nome { get; set; }
        public string Funcionario_CPF { get; set; }
        public string Funcionario_RG { get; set; }
        public DateTime Funcionario_DtNascimento { get; set; }
        public string Funcionario_Celular { get; set; }
        public string Funcionario_Email { get; set; }
        public string Funcionario_Telefone { get; set; }
        public DateTime FuncionarioDtAdmissao { get; set; }
        public int? Endereco_Id { get; set; }
        public string Endereco_Numero { get; set; }
        public string Endereco_Logradouro { get; set; }
        public string Endereco_Bairro { get; set; }
        public string Endereco_Cidade { get; set; }
        public string Endereco_Estado { get; set; }
        public string Endereco_Complemento { get; set; }
        public string Endereco_CEP { get; set; }
        public int? Cargo_Id { get; set; }
        public string Cargo_Desc { get; set; }
        public int? Estabelecimento_Id { get; set; }
        public string Estabelecimento_Nome { get; set; }
        public int? Usuario_Id { get; set; }
        public string Usuario_Login { get; set; }
    }
}
