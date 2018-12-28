namespace SocietyAgendor.API.Entities
{
    public class Estabelecimento
    {
        public int? EstabelecimentoId { get; set; }
        public string EstabelecimentoNome { get; set; }
        public string EstabelecimentoCNPJ { get; set; }
        public string EstabelecimentoCelular { get; set; }
        public string EstabelecimentoEmail { get; set; }
        public string EstabelecimentoTelefone { get; set; }
        public int? EnderecoId { get; set; }
        public string EnderecoNumero { get; set; }
        public string EnderecoLogradouro { get; set; }
        public string EnderecoBairro { get; set; }
        public string EnderecoComplemento { get; set; }
        public string EnderecoCEP { get; set; }
        public string EnderecoCidade { get; set; }
        public string EnderecoEstado { get; set; }
    }
}
