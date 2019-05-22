using System;

namespace SocietyAgendor.API.Entities
{
    public class Cliente
    {
        public int? Cliente_Id { get; set; }
        public string Cliente_Nome { get; set; }
        public string Cliente_CPF { get; set; }
        public string Cliente_RG { get; set; }
        public string Cliente_Email { get; set; }
        public DateTime Cliente_DtNascimento { get; set; }
        public string Cliente_Telefone { get; set; }
        public string Cliente_Celular { get; set; }
        public int? Endereco_Id { get; set; }
        public string Endereco_Logradouro { get; set; }
        public string Endereco_Numero { get; set; }
        public string Endereco_Bairro { get; set; }
        public string Endereco_Cidade { get; set; }
        public string Endereco_Estado { get; set; }
        public string Endereco_Complemento { get; set; }
        public string Endereco_CEP { get; set; }
    }
}
