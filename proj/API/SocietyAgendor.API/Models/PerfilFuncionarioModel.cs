using System;

namespace SocietyAgendor.API.Models
{
    public class PerfilFuncionarioModel
    {
        public string Funcionario_Nome { get; set; }
        public string Funcionario_CPF { get; set; }
        public string Funcionario_RG { get; set; }
        public DateTime Funcionario_DtNascimento { get; set; }
        public string Cargo_Desc { get; set; }
        public string Estabelecimento_Nome { get; set; }
        public string Usuario_Login { get; set; }
    }
}