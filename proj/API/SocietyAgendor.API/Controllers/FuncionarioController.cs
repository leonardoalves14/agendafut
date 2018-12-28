using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Models;
using SocietyAgendor.API.Services;
using System.Collections.Generic;

namespace SocietyAgendor.API.Controllers
{
    // TODO: RETORNAR 1 FUNCIONÁRIO

    [Route("api/funcionarios")]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        [HttpGet]
        public IActionResult GetAllFuncionarios()
        {
            List<FuncionarioModel> result = new List<FuncionarioModel>();
            List<Funcionario> list = _funcionarioRepository.GetAllFuncionarios();

            foreach (var item in list)
            {
                result.Add(new FuncionarioModel
                {
                    Funcionario_Id = item.FuncionarioId,
                    Funcionario_Nome = item.FuncionarioNome,
                    Funcionario_CPF = item.FuncionarioCPF,
                    Funcionario_RG = item.FuncionarioRG,
                    Funcionario_DtNascimento = item.FuncionarioDtNascimento,
                    Funcionario_Celular = item.FuncionarioCelular,
                    Funcionario_Telefone = item.FuncionarioTelefone,
                    Funcionario_Email = item.FuncionarioEmail,
                    FuncionarioDtAdmissao = item.FuncionarioDtAdmissao,
                    Endereco_Id = item.EnderecoId,
                    Endereco_Numero = item.EnderecoNumero,
                    Endereco_Logradouro = item.EnderecoLogradouro,
                    Endereco_Bairro = item.EnderecoBairro,
                    Endereco_Complemento = item.EnderecoComplemento,
                    Endereco_Cidade = item.EnderecoCidade,
                    Endereco_CEP = item.EnderecoCEP,
                    Endereco_Estado = item.EnderecoEstado,
                    Cargo_Id = item.CargoId,
                    Cargo_Desc = item.CargoDesc,
                    Estabelecimento_Id = item.EstabelecimentoId,
                    Estabelecimento_Nome = item.EstabelecimentoNome,
                    Usuario_Id = item.UsuarioId,
                    Usuario_Login = item.UsuarioLogin
                });
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateFuncionario([FromBody] FuncionarioModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Funcionario funcionario = new Funcionario
            {
                FuncionarioNome = model.Funcionario_Nome,
                FuncionarioCPF = model.Funcionario_CPF,
                FuncionarioRG = model.Funcionario_RG,
                FuncionarioDtNascimento = model.Funcionario_DtNascimento,
                FuncionarioCelular = model.Funcionario_Celular,
                FuncionarioTelefone = model.Funcionario_Telefone,
                FuncionarioEmail = model.Funcionario_Email,
                FuncionarioDtAdmissao = model.FuncionarioDtAdmissao,
                EnderecoNumero = model.Endereco_Numero,
                EnderecoLogradouro = model.Endereco_Logradouro,
                EnderecoBairro = model.Endereco_Bairro,
                EnderecoComplemento = model.Endereco_Complemento,
                EnderecoCidade = model.Endereco_Cidade,
                EnderecoCEP = model.Endereco_CEP,
                EnderecoEstado = model.Endereco_Estado,
                CargoId = model.Cargo_Id,
                EstabelecimentoId = model.Estabelecimento_Id,
                UsuarioId = model.Usuario_Id
            };

            var newFuncionario = _funcionarioRepository.CreateFuncionario(funcionario);
            model.Funcionario_Id = newFuncionario.FuncionarioId;
            model.Endereco_Id = newFuncionario.EnderecoId;

            return Ok(model);
        }

        [HttpPost("{funcionarioId}")]
        public IActionResult UpdateFuncionario(int funcionarioId,
                                               [FromBody] FuncionarioModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_funcionarioRepository.FuncionarioExists(funcionarioId))
            {
                return NotFound($"Funcionário {funcionarioId} não existe!");
            }

            Funcionario funcionario = new Funcionario
            {
                FuncionarioId = model.Funcionario_Id,
                FuncionarioNome = model.Funcionario_Nome,
                FuncionarioCPF = model.Funcionario_CPF,
                FuncionarioRG = model.Funcionario_RG,
                FuncionarioDtNascimento = model.Funcionario_DtNascimento,
                FuncionarioCelular = model.Funcionario_Celular,
                FuncionarioTelefone = model.Funcionario_Telefone,
                FuncionarioEmail = model.Funcionario_Email,
                FuncionarioDtAdmissao = model.FuncionarioDtAdmissao,
                EnderecoId = model.Endereco_Id,
                EnderecoNumero = model.Endereco_Numero,
                EnderecoLogradouro = model.Endereco_Logradouro,
                EnderecoBairro = model.Endereco_Bairro,
                EnderecoComplemento = model.Endereco_Complemento,
                EnderecoCidade = model.Endereco_Cidade,
                EnderecoCEP = model.Endereco_CEP,
                EnderecoEstado = model.Endereco_Estado,
                CargoId = model.Cargo_Id,
                EstabelecimentoId = model.Estabelecimento_Id,
                UsuarioId = model.Usuario_Id
            };

            _funcionarioRepository.UpdateFuncionario(funcionario);

            return NoContent();
        }

        [HttpDelete("{funcionarioId}")]
        public IActionResult DeleteFuncionario(int funcionarioId)
        {
            if (!_funcionarioRepository.FuncionarioExists(funcionarioId))
            {
                return NotFound($"Funcionário {funcionarioId} não existe!");
            }

            _funcionarioRepository.DeleteFuncionario(funcionarioId);

            return NoContent();
        }
    }
}
