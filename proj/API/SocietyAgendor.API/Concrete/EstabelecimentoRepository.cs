using Dapper;
using Microsoft.Extensions.Configuration;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Services;
using System.Collections.Generic;
using System.Linq;

namespace SocietyAgendor.API.Concrete
{
    public class EstabelecimentoRepository : Base.Base, IEstabelecimentoRepository
    {
        public EstabelecimentoRepository(IConfiguration configuration) : base(configuration) { }

        public List<Estabelecimento> GetAllEstabelecimentos()
        {
            return ExecuteSP<Estabelecimento>("spsEstabelecimento");
        }

        public Estabelecimento CreateEstabelecimento(Estabelecimento model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Estabelecimento_Id", model.EstabelecimentoId, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
            parameters.Add("@Estabelecimento_Nome", model.EstabelecimentoNome, System.Data.DbType.String);
            parameters.Add("@Estabelecimento_CNPJ", model.EstabelecimentoCNPJ, System.Data.DbType.String);
            parameters.Add("@Endereco_Id", model.EnderecoId, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
            parameters.Add("@Endereco_Numero", model.EnderecoNumero, System.Data.DbType.String);
            parameters.Add("@Endereco_Logradouro", model.EnderecoLogradouro, System.Data.DbType.String);
            parameters.Add("@Endereco_Bairro", model.EnderecoBairro, System.Data.DbType.String);
            parameters.Add("@Endereco_Complemento", model.EnderecoComplemento, System.Data.DbType.String);
            parameters.Add("@Endereco_Cidade", model.EnderecoCidade, System.Data.DbType.String);
            parameters.Add("@Endereco_Estado", model.EnderecoEstado, System.Data.DbType.String);
            parameters.Add("@Endereco_CEP", model.EnderecoCEP, System.Data.DbType.String);
            parameters.Add("@Estabelecimento_Celular", model.EstabelecimentoCelular, System.Data.DbType.String);
            parameters.Add("@Estabelecimento_Email", model.EstabelecimentoEmail, System.Data.DbType.String);
            parameters.Add("@Estabelecimento_Telefone", model.EstabelecimentoTelefone, System.Data.DbType.String);

            ExecuteSP("spiEstabelecimento", parameters);
            model.EstabelecimentoId = parameters.Get<int>("@Estabelecimento_Id");
            model.EnderecoId = parameters.Get<int>("@Endereco_Id");

            return model;
        }

        public void UpdateEstabelecimento(Estabelecimento model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Estabelecimento_Id", model.EstabelecimentoId, System.Data.DbType.Int32);
            parameters.Add("@Estabelecimento_Nome", model.EstabelecimentoNome, System.Data.DbType.String);
            parameters.Add("@Estabelecimento_CNPJ", model.EstabelecimentoCNPJ, System.Data.DbType.String);
            parameters.Add("@Endereco_Id", model.EnderecoId, System.Data.DbType.Int32);
            parameters.Add("@Endereco_Numero", model.EnderecoNumero, System.Data.DbType.String);
            parameters.Add("@Endereco_Logradouro", model.EnderecoLogradouro, System.Data.DbType.String);
            parameters.Add("@Endereco_Bairro", model.EnderecoBairro, System.Data.DbType.String);
            parameters.Add("@Endereco_Complemento", model.EnderecoComplemento, System.Data.DbType.String);
            parameters.Add("@Endereco_Cidade", model.EnderecoCidade, System.Data.DbType.String);
            parameters.Add("@Endereco_Estado", model.EnderecoEstado, System.Data.DbType.String);
            parameters.Add("@Endereco_CEP", model.EnderecoCEP, System.Data.DbType.String);
            parameters.Add("@Estabelecimento_Celular", model.EstabelecimentoCelular, System.Data.DbType.String);
            parameters.Add("@Estabelecimento_Email", model.EstabelecimentoEmail, System.Data.DbType.String);
            parameters.Add("@Estabelecimento_Telefone", model.EstabelecimentoTelefone, System.Data.DbType.String);

            ExecuteSP("spuEstabelecimento", parameters);
        }

        public void DeleteEstabelecimento(int estabelecimentoId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Estabelecimento_Id", estabelecimentoId, System.Data.DbType.Int32);

            ExecuteSP("spdEstabelecimento", parameters);
        }

        public bool EstabelecimentoExists(int estabelecimentoId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Estabelecimento_Id", estabelecimentoId, System.Data.DbType.Int32);

            var estabelecimentos = new List<HelperEntity>();
            var list = ExecuteSP<HelperEntity>("speEstabelecimento", parameters);

            foreach (var item in list)
            {
                estabelecimentos.Add(item);
            }

            if (estabelecimentos.FirstOrDefault().Exists)
                return true;
            else
                return false;
        }
    }
}
