using Dapper;
using Microsoft.Extensions.Configuration;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Services;
using System.Collections.Generic;
using System.Linq;

namespace SocietyAgendor.API.Concrete
{
    public class ClienteRepository : Base.Base, IClienteRepository
    {
        public ClienteRepository(IConfiguration configuration) : base(configuration) { }

        public List<Cliente> GetAllClientes()
        {
            return ExecuteSP<Cliente>("spsCliente");
        }

        public Cliente CreateCliente(Cliente model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Cliente_Id", model.ClienteId, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
            parameters.Add("@Cliente_Nome", model.ClienteNome, System.Data.DbType.String);
            parameters.Add("@Cliente_CPF", model.ClienteCPF, System.Data.DbType.String);
            parameters.Add("@Cliente_RG", model.ClienteRG, System.Data.DbType.String);
            parameters.Add("@Cliente_Email", model.ClienteEmail, System.Data.DbType.String);
            parameters.Add("@Cliente_DtNascimento", model.ClienteDtNascimento, System.Data.DbType.Date);
            parameters.Add("@Cliente_Telefone", model.ClienteTelefone, System.Data.DbType.String);
            parameters.Add("@Cliente_Celular", model.ClienteCelular, System.Data.DbType.String);
            parameters.Add("@Endereco_Id", model.EnderecoId, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
            parameters.Add("@Endereco_Logradouro", model.EnderecoLogradouro, System.Data.DbType.String);
            parameters.Add("@Endereco_Numero", model.EnderecoNumero, System.Data.DbType.String);
            parameters.Add("@Endereco_Bairro", model.EnderecoBairro, System.Data.DbType.String);
            parameters.Add("@Endereco_Complemento", model.EnderecoComplemento, System.Data.DbType.String);
            parameters.Add("@Endereco_Cidade", model.EnderecoCidade, System.Data.DbType.String);
            parameters.Add("@Endereco_Estado", model.EnderecoEstado, System.Data.DbType.String);
            parameters.Add("@Endereco_CEP", model.EnderecoCEP, System.Data.DbType.String);

            ExecuteSP("spiCliente", parameters);
            model.ClienteId = parameters.Get<int>("@Cliente_Id");
            model.EnderecoId = parameters.Get<int>("@Endereco_Id");

            return model;
        }

        public void UpdateCliente(Cliente model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Cliente_Id", model.ClienteId, System.Data.DbType.Int32);
            parameters.Add("@Cliente_Nome", model.ClienteNome, System.Data.DbType.String);
            parameters.Add("@Cliente_CPF", model.ClienteCPF, System.Data.DbType.String);
            parameters.Add("@Cliente_RG", model.ClienteRG, System.Data.DbType.String);
            parameters.Add("@Cliente_Email", model.ClienteEmail, System.Data.DbType.String);
            parameters.Add("@Cliente_DtNascimento", model.ClienteDtNascimento, System.Data.DbType.Date);
            parameters.Add("@Cliente_Telefone", model.ClienteTelefone, System.Data.DbType.String);
            parameters.Add("@Cliente_Celular", model.ClienteCelular, System.Data.DbType.String);
            parameters.Add("@Endereco_Id", model.EnderecoId, System.Data.DbType.Int32);
            parameters.Add("@Endereco_Logradouro", model.EnderecoLogradouro, System.Data.DbType.String);
            parameters.Add("@Endereco_Numero", model.EnderecoNumero, System.Data.DbType.String);
            parameters.Add("@Endereco_Bairro", model.EnderecoBairro, System.Data.DbType.String);
            parameters.Add("@Endereco_Complemento", model.EnderecoComplemento, System.Data.DbType.String);
            parameters.Add("@Endereco_Cidade", model.EnderecoCidade, System.Data.DbType.String);
            parameters.Add("@Endereco_Estado", model.EnderecoEstado, System.Data.DbType.String);
            parameters.Add("@Endereco_CEP", model.EnderecoCEP, System.Data.DbType.String);

            ExecuteSP("spuCliente", parameters);
        }

        public void DeleteCliente(int clienteId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Cliente_Id", clienteId, System.Data.DbType.Int32);

            ExecuteSP("spdCliente", parameters);
        }

        public bool ClienteExists(int clienteId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Cliente_Id", clienteId, System.Data.DbType.Int32);

            var cliente = new List<HelperEntity>();
            var list = ExecuteSP<HelperEntity>("speCliente", parameters);

            foreach (var item in list)
            {
                cliente.Add(item);
            }

            if (cliente.FirstOrDefault().Exists)
                return true;
            else
                return false;
        }
    }
}
