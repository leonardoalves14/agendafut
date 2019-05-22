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
            parameters.Add("@Cliente_Id", model.Cliente_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
            parameters.Add("@Cliente_Nome", model.Cliente_Nome, System.Data.DbType.String);
            parameters.Add("@Cliente_CPF", model.Cliente_CPF, System.Data.DbType.String);
            parameters.Add("@Cliente_RG", model.Cliente_RG, System.Data.DbType.String);
            parameters.Add("@Cliente_Email", model.Cliente_Email, System.Data.DbType.String);
            parameters.Add("@Cliente_DtNascimento", model.Cliente_DtNascimento, System.Data.DbType.Date);
            parameters.Add("@Cliente_Telefone", model.Cliente_Telefone, System.Data.DbType.String);
            parameters.Add("@Cliente_Celular", model.Cliente_Celular, System.Data.DbType.String);
            parameters.Add("@Endereco_Id", model.Endereco_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
            parameters.Add("@Endereco_Logradouro", model.Endereco_Logradouro, System.Data.DbType.String);
            parameters.Add("@Endereco_Numero", model.Endereco_Numero, System.Data.DbType.String);
            parameters.Add("@Endereco_Bairro", model.Endereco_Bairro, System.Data.DbType.String);
            parameters.Add("@Endereco_Complemento", model.Endereco_Complemento, System.Data.DbType.String);
            parameters.Add("@Endereco_Cidade", model.Endereco_Cidade, System.Data.DbType.String);
            parameters.Add("@Endereco_Estado", model.Endereco_Estado, System.Data.DbType.String);
            parameters.Add("@Endereco_CEP", model.Endereco_CEP, System.Data.DbType.String);

            ExecuteSP("spiCliente", parameters);
            model.Cliente_Id = parameters.Get<int>("@Cliente_Id");
            model.Endereco_Id = parameters.Get<int>("@Endereco_Id");

            return model;
        }

        public void UpdateCliente(Cliente model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Cliente_Id", model.Cliente_Id, System.Data.DbType.Int32);
            parameters.Add("@Cliente_Nome", model.Cliente_Nome, System.Data.DbType.String);
            parameters.Add("@Cliente_CPF", model.Cliente_CPF, System.Data.DbType.String);
            parameters.Add("@Cliente_RG", model.Cliente_RG, System.Data.DbType.String);
            parameters.Add("@Cliente_Email", model.Cliente_Email, System.Data.DbType.String);
            parameters.Add("@Cliente_DtNascimento", model.Cliente_DtNascimento, System.Data.DbType.Date);
            parameters.Add("@Cliente_Telefone", model.Cliente_Telefone, System.Data.DbType.String);
            parameters.Add("@Cliente_Celular", model.Cliente_Celular, System.Data.DbType.String);
            parameters.Add("@Endereco_Id", model.Endereco_Id, System.Data.DbType.Int32);
            parameters.Add("@Endereco_Logradouro", model.Endereco_Logradouro, System.Data.DbType.String);
            parameters.Add("@Endereco_Numero", model.Endereco_Numero, System.Data.DbType.String);
            parameters.Add("@Endereco_Bairro", model.Endereco_Bairro, System.Data.DbType.String);
            parameters.Add("@Endereco_Complemento", model.Endereco_Complemento, System.Data.DbType.String);
            parameters.Add("@Endereco_Cidade", model.Endereco_Cidade, System.Data.DbType.String);
            parameters.Add("@Endereco_Estado", model.Endereco_Estado, System.Data.DbType.String);
            parameters.Add("@Endereco_CEP", model.Endereco_CEP, System.Data.DbType.String);

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
