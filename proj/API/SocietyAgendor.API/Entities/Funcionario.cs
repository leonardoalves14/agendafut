using System;

namespace SocietyAgendor.API.Entities
{
    public class Funcionario
    {
        public int? FuncionarioId { get; set; }
        public string FuncionarioNome { get; set; }
        public string FuncionarioCPF { get; set; }
        public string FuncionarioRG { get; set; }
        public DateTime FuncionarioDtNascimento { get; set; }
        public string FuncionarioCelular { get; set; }
        public string FuncionarioEmail { get; set; }
        public string FuncionarioTelefone { get; set; }
        public DateTime FuncionarioDtAdmissao { get; set; }
        public int? EnderecoId { get; set; }
        public string EnderecoNumero { get; set; }
        public string EnderecoLogradouro { get; set; }
        public string EnderecoBairro { get; set; }
        public string EnderecoCidade { get; set; }
        public string EnderecoEstado { get; set; }
        public string EnderecoComplemento { get; set; }
        public string EnderecoCEP { get; set; }
        public int? CargoId { get; set; }
        public string CargoDesc { get; set; }
        public int? EstabelecimentoId { get; set; }
        public string EstabelecimentoNome { get; set; }
        public int? UsuarioId { get; set; }
        public string UsuarioLogin { get; set; }
    }
}
