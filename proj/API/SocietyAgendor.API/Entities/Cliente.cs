using System;

namespace SocietyAgendor.API.Entities
{
    public class Cliente
    {
        public int? ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteCPF { get; set; }
        public string ClienteRG { get; set; }
        public string ClienteEmail { get; set; }
        public DateTime ClienteDtNascimento { get; set; }
        public string ClienteTelefone { get; set; }
        public string ClienteCelular { get; set; }
        public int? EnderecoId { get; set; }
        public string EnderecoLogradouro { get; set; }
        public string EnderecoNumero { get; set; }
        public string EnderecoBairro { get; set; }
        public string EnderecoCidade { get; set; }
        public string EnderecoEstado { get; set; }
        public string EnderecoComplemento { get; set; }
        public string EnderecoCEP { get; set; }
    }
}
