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
            parameters.Add("@Funcionario_Id", model.FuncionarioId, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
            parameters.Add("@Funcionario_Nome", model.FuncionarioNome, System.Data.DbType.String);
            parameters.Add("@Funcionario_CPF", model.FuncionarioCPF, System.Data.DbType.String);
            parameters.Add("@Funcionario_RG", model.FuncionarioRG, System.Data.DbType.String);
            parameters.Add("@Funcionario_DtNascimento", model.FuncionarioDtNascimento, System.Data.DbType.Date);
            parameters.Add("@Funcionario_Celular", model.FuncionarioCelular, System.Data.DbType.String);
            parameters.Add("@Funcionario_Telefone", model.FuncionarioTelefone, System.Data.DbType.String);
            parameters.Add("@Funcionario_Email", model.FuncionarioEmail, System.Data.DbType.String);
            parameters.Add("@Cargo_Id", model.CargoId, System.Data.DbType.Int32);
            parameters.Add("@Funcionario_DtAdmissao", model.FuncionarioDtAdmissao, System.Data.DbType.Date);
            parameters.Add("@Estabelecimento_Id", model.EstabelecimentoId, System.Data.DbType.Int32);
            parameters.Add("@Endereco_Id", model.EnderecoId, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
            parameters.Add("@Endereco_Numero", model.EnderecoNumero, System.Data.DbType.String);
            parameters.Add("@Endereco_Logradouro", model.EnderecoLogradouro, System.Data.DbType.String);
            parameters.Add("@Endereco_Bairro", model.EnderecoBairro, System.Data.DbType.String);
            parameters.Add("@Endereco_Complemento", model.EnderecoComplemento, System.Data.DbType.String);
            parameters.Add("@Endereco_Cidade", model.EnderecoCidade, System.Data.DbType.String);
            parameters.Add("@Endereco_Estado", model.EnderecoEstado, System.Data.DbType.String);
            parameters.Add("@Endereco_CEP", model.EnderecoCEP, System.Data.DbType.String);
            parameters.Add("@Usuario_Id", model.UsuarioId, System.Data.DbType.Int32);

            ExecuteSP("spiFuncionario", parameters);
            model.FuncionarioId = parameters.Get<int>("@Funcionario_Id");
            model.EnderecoId = parameters.Get<int>("@Endereco_Id");

            return model;
        }

        public void UpdateFuncionario(Funcionario model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Funcionario_Id", model.FuncionarioId, System.Data.DbType.Int32);
            parameters.Add("@Funcionario_Nome", model.FuncionarioNome, System.Data.DbType.String);
            parameters.Add("@Funcionario_CPF", model.FuncionarioCPF, System.Data.DbType.String);
            parameters.Add("@Funcionario_RG", model.FuncionarioRG, System.Data.DbType.String);
            parameters.Add("@Funcionario_DtNascimento", model.FuncionarioDtNascimento, System.Data.DbType.Date);
            parameters.Add("@Funcionario_Celular", model.FuncionarioCelular, System.Data.DbType.String);
            parameters.Add("@Funcionario_Telefone", model.FuncionarioTelefone, System.Data.DbType.String);
            parameters.Add("@Funcionario_Email", model.FuncionarioEmail, System.Data.DbType.String);
            parameters.Add("@Cargo_Id", model.CargoId, System.Data.DbType.Int32);
            parameters.Add("@Funcionario_DtAdmissao", model.FuncionarioDtAdmissao, System.Data.DbType.Date);
            parameters.Add("@Estabelecimento_Id", model.EstabelecimentoId, System.Data.DbType.Int32);
            parameters.Add("@Endereco_Id", model.EnderecoId, System.Data.DbType.Int32);
            parameters.Add("@Endereco_Numero", model.EnderecoNumero, System.Data.DbType.String);
            parameters.Add("@Endereco_Logradouro", model.EnderecoLogradouro, System.Data.DbType.String);
            parameters.Add("@Endereco_Bairro", model.EnderecoBairro, System.Data.DbType.String);
            parameters.Add("@Endereco_Complemento", model.EnderecoComplemento, System.Data.DbType.String);
            parameters.Add("@Endereco_Cidade", model.EnderecoCidade, System.Data.DbType.String);
            parameters.Add("@Endereco_Estado", model.EnderecoEstado, System.Data.DbType.String);
            parameters.Add("@Endereco_CEP", model.EnderecoCEP, System.Data.DbType.String);
            parameters.Add("@Usuario_Id", model.UsuarioId, System.Data.DbType.Int32);

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
