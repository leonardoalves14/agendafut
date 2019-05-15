using Dapper;
using Microsoft.Extensions.Configuration;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyAgendor.API.Concrete
{
    public class FuncionarioRepository : Base.Base, IFuncionarioRepository
    {
        public FuncionarioRepository(IConfiguration configuration) : base(configuration) { }

        public List<Funcionario> GetAllFuncionarios()
        {
            return ExecuteSP<Funcionario>("spsFuncionario");
        }

        public async Task<Funcionario> GetFuncionarioByUsuarioId(int usuarioId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Usuario_Id", usuarioId, System.Data.DbType.Int32);

            var result = await GetFirstOrDefault<Funcionario>("spsUsuarioFuncionario", parameters);

            return result;
        }

        public Funcionario CreateFuncionario(Funcionario model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Funcionario_Id", model.Funcionario_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
            parameters.Add("@Funcionario_Nome", model.Funcionario_Nome, System.Data.DbType.String);
            parameters.Add("@Funcionario_CPF", model.Funcionario_CPF, System.Data.DbType.String);
            parameters.Add("@Funcionario_RG", model.Funcionario_RG, System.Data.DbType.String);
            parameters.Add("@Funcionario_DtNascimento", model.Funcionario_DtNascimento, System.Data.DbType.Date);
            parameters.Add("@Funcionario_Celular", model.Funcionario_Celular, System.Data.DbType.String);
            parameters.Add("@Funcionario_Telefone", model.Funcionario_Telefone, System.Data.DbType.String);
            parameters.Add("@Funcionario_Email", model.Funcionario_Email, System.Data.DbType.String);
            parameters.Add("@Cargo_Id", model.Cargo_Id, System.Data.DbType.Int32);
            parameters.Add("@Funcionario_DtAdmissao", model.FuncionarioDtAdmissao, System.Data.DbType.Date);
            parameters.Add("@Estabelecimento_Id", model.Estabelecimento_Id, System.Data.DbType.Int32);
            parameters.Add("@Endereco_Id", model.Endereco_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
            parameters.Add("@Endereco_Numero", model.Endereco_Numero, System.Data.DbType.String);
            parameters.Add("@Endereco_Logradouro", model.Endereco_Logradouro, System.Data.DbType.String);
            parameters.Add("@Endereco_Bairro", model.Endereco_Bairro, System.Data.DbType.String);
            parameters.Add("@Endereco_Complemento", model.Endereco_Complemento, System.Data.DbType.String);
            parameters.Add("@Endereco_Cidade", model.Endereco_Cidade, System.Data.DbType.String);
            parameters.Add("@Endereco_Estado", model.Endereco_Estado, System.Data.DbType.String);
            parameters.Add("@Endereco_CEP", model.Endereco_CEP, System.Data.DbType.String);
            parameters.Add("@Usuario_Id", model.Usuario_Id, System.Data.DbType.Int32);

            ExecuteSP("spiFuncionario", parameters);
            model.Funcionario_Id = parameters.Get<int>("@Funcionario_Id");
            model.Endereco_Id = parameters.Get<int>("@Endereco_Id");

            return model;
        }

        public void UpdateFuncionario(Funcionario model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Funcionario_Id", model.Funcionario_Id, System.Data.DbType.Int32);
            parameters.Add("@Funcionario_Nome", model.Funcionario_Nome, System.Data.DbType.String);
            parameters.Add("@Funcionario_CPF", model.Funcionario_CPF, System.Data.DbType.String);
            parameters.Add("@Funcionario_RG", model.Funcionario_RG, System.Data.DbType.String);
            parameters.Add("@Funcionario_DtNascimento", model.Funcionario_DtNascimento, System.Data.DbType.Date);
            parameters.Add("@Funcionario_Celular", model.Funcionario_Celular, System.Data.DbType.String);
            parameters.Add("@Funcionario_Telefone", model.Funcionario_Telefone, System.Data.DbType.String);
            parameters.Add("@Funcionario_Email", model.Funcionario_Email, System.Data.DbType.String);
            parameters.Add("@Cargo_Id", model.Cargo_Id, System.Data.DbType.Int32);
            parameters.Add("@Funcionario_DtAdmissao", model.FuncionarioDtAdmissao, System.Data.DbType.Date);
            parameters.Add("@Estabelecimento_Id", model.Estabelecimento_Id, System.Data.DbType.Int32);
            parameters.Add("@Endereco_Id", model.Endereco_Id, System.Data.DbType.Int32);
            parameters.Add("@Endereco_Numero", model.Endereco_Numero, System.Data.DbType.String);
            parameters.Add("@Endereco_Logradouro", model.Endereco_Logradouro, System.Data.DbType.String);
            parameters.Add("@Endereco_Bairro", model.Endereco_Bairro, System.Data.DbType.String);
            parameters.Add("@Endereco_Complemento", model.Endereco_Complemento, System.Data.DbType.String);
            parameters.Add("@Endereco_Cidade", model.Endereco_Cidade, System.Data.DbType.String);
            parameters.Add("@Endereco_Estado", model.Endereco_Estado, System.Data.DbType.String);
            parameters.Add("@Endereco_CEP", model.Endereco_CEP, System.Data.DbType.String);
            parameters.Add("@Usuario_Id", model.Usuario_Id, System.Data.DbType.Int32);

            ExecuteSP("spuFuncionario", parameters);
        }

        public void DeleteFuncionario(int funcionarioId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Funcionario_Id", funcionarioId, System.Data.DbType.Int32);

            ExecuteSP("spdFuncionario", parameters);
        }

        public bool FuncionarioExists(int funcionarioId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Funcionario_Id", funcionarioId, System.Data.DbType.Int32);

            var funcionarios = new List<HelperEntity>();
            var list = ExecuteSP<HelperEntity>("speFuncionario", parameters);

            foreach (var item in list)
            {
                funcionarios.Add(item);
            }

            if (funcionarios.FirstOrDefault().Exists)
                return true;
            else
                return false;
        }
    }
}
