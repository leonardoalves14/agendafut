namespace SocietyAgendor.API.Entities
{
    public class Estabelecimento
    {
        public int? Estabelecimento_Id { get; set; }
        public string Estabelecimento_Nome { get; set; }
        public string Estabelecimento_CNPJ { get; set; }
        public string Estabelecimento_Celular { get; set; }
        public string Estabelecimento_Email { get; set; }
        public string Estabelecimento_Telefone { get; set; }
        public int? Endereco_Id { get; set; }
        public string Endereco_Numero { get; set; }
        public string Endereco_Logradouro { get; set; }
        public string Endereco_Bairro { get; set; }
        public string Endereco_Complemento { get; set; }
        public string Endereco_CEP { get; set; }
        public string Endereco_Cidade { get; set; }
        public string Endereco_Estado { get; set; }
    }
}
