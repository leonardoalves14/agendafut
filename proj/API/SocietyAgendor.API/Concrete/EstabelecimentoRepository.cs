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
            parameters.Add("@Estabelecimento_Id", model.Estabelecimento_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
            parameters.Add("@Estabelecimento_Nome", model.Estabelecimento_Nome, System.Data.DbType.String);
            parameters.Add("@Estabelecimento_CNPJ", model.Estabelecimento_CNPJ, System.Data.DbType.String);
            parameters.Add("@Endereco_Id", model.Endereco_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
            parameters.Add("@Endereco_Numero", model.Endereco_Numero, System.Data.DbType.String);
            parameters.Add("@Endereco_Logradouro", model.Endereco_Logradouro, System.Data.DbType.String);
            parameters.Add("@Endereco_Bairro", model.Endereco_Bairro, System.Data.DbType.String);
            parameters.Add("@Endereco_Complemento", model.Endereco_Complemento, System.Data.DbType.String);
            parameters.Add("@Endereco_Cidade", model.Endereco_Cidade, System.Data.DbType.String);
            parameters.Add("@Endereco_Estado", model.Endereco_Estado, System.Data.DbType.String);
            parameters.Add("@Endereco_CEP", model.Endereco_CEP, System.Data.DbType.String);
            parameters.Add("@Estabelecimento_Celular", model.Estabelecimento_Celular, System.Data.DbType.String);
            parameters.Add("@Estabelecimento_Email", model.Estabelecimento_Email, System.Data.DbType.String);
            parameters.Add("@Estabelecimento_Telefone", model.Estabelecimento_Telefone, System.Data.DbType.String);

            ExecuteSP("spiEstabelecimento", parameters);
            model.Estabelecimento_Id = parameters.Get<int>("@Estabelecimento_Id");
            model.Endereco_Id = parameters.Get<int>("@Endereco_Id");

            return model;
        }

        public void UpdateEstabelecimento(Estabelecimento model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Estabelecimento_Id", model.Estabelecimento_Id, System.Data.DbType.Int32);
            parameters.Add("@Estabelecimento_Nome", model.Estabelecimento_Nome, System.Data.DbType.String);
            parameters.Add("@Estabelecimento_CNPJ", model.Estabelecimento_CNPJ, System.Data.DbType.String);
            parameters.Add("@Endereco_Id", model.Endereco_Id, System.Data.DbType.Int32);
            parameters.Add("@Endereco_Numero", model.Endereco_Numero, System.Data.DbType.String);
            parameters.Add("@Endereco_Logradouro", model.Endereco_Logradouro, System.Data.DbType.String);
            parameters.Add("@Endereco_Bairro", model.Endereco_Bairro, System.Data.DbType.String);
            parameters.Add("@Endereco_Complemento", model.Endereco_Complemento, System.Data.DbType.String);
            parameters.Add("@Endereco_Cidade", model.Endereco_Cidade, System.Data.DbType.String);
            parameters.Add("@Endereco_Estado", model.Endereco_Estado, System.Data.DbType.String);
            parameters.Add("@Endereco_CEP", model.Endereco_CEP, System.Data.DbType.String);
            parameters.Add("@Estabelecimento_Celular", model.Estabelecimento_Celular, System.Data.DbType.String);
            parameters.Add("@Estabelecimento_Email", model.Estabelecimento_Email, System.Data.DbType.String);
            parameters.Add("@Estabelecimento_Telefone", model.Estabelecimento_Telefone, System.Data.DbType.String);

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
