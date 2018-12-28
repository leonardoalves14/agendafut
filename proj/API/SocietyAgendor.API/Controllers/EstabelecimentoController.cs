using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Models;
using SocietyAgendor.API.Services;
using System.Collections.Generic;

namespace SocietyAgendor.API.Controllers
{
    // TODO: RETORNAR 1 ESTABELECIMENTO

    [Route("api/estabelecimentos")]
    public class EstabelecimentoController : Controller
    {
        private readonly IEstabelecimentoRepository _estabelecimentoRepository;

        public EstabelecimentoController(IEstabelecimentoRepository estabelecimentoRepository)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
        }

        public IActionResult GetAllEstabelecimentos()
        {
            List<EstabelecimentoModel> result = new List<EstabelecimentoModel>();
            List<Estabelecimento> list = _estabelecimentoRepository.GetAllEstabelecimentos();

            foreach (var item in list)
            {
                result.Add(new EstabelecimentoModel
                {
                    Estabelecimento_Id = item.EstabelecimentoId,
                    Estabelecimento_Nome = item.EstabelecimentoNome,
                    Estabelecimento_CNPJ = item.EstabelecimentoCNPJ,
                    Estabelecimento_Celular = item.EstabelecimentoCelular,
                    Estabelecimento_Telefone = item.EstabelecimentoTelefone,
                    Estabelecimento_Email = item.EstabelecimentoEmail,
                    Endereco_Id = item.EnderecoId,
                    Endereco_Numero = item.EnderecoNumero,
                    Endereco_Logradouro = item.EnderecoLogradouro,
                    Endereco_Complemento = item.EnderecoComplemento,
                    Endereco_Bairro = item.EnderecoBairro,
                    Endereco_Cidade = item.EnderecoCidade,
                    Endereco_Estado = item.EnderecoEstado,
                    Endereco_CEP = item.EnderecoCEP
                });
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateEstabelecimento([FromBody] EstabelecimentoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Estabelecimento estabelecimento = new Estabelecimento
            {
                EstabelecimentoNome = model.Estabelecimento_Nome,
                EstabelecimentoCNPJ = model.Estabelecimento_CNPJ,
                EstabelecimentoCelular = model.Estabelecimento_Celular,
                EstabelecimentoTelefone = model.Estabelecimento_Telefone,
                EstabelecimentoEmail = model.Estabelecimento_Email,
                EnderecoNumero = model.Endereco_Numero,
                EnderecoLogradouro = model.Endereco_Logradouro,
                EnderecoComplemento = model.Endereco_Complemento,
                EnderecoBairro = model.Endereco_Bairro,
                EnderecoCidade = model.Endereco_Cidade,
                EnderecoEstado = model.Endereco_Estado,
                EnderecoCEP = model.Endereco_CEP
            };

            Estabelecimento newItem = _estabelecimentoRepository.CreateEstabelecimento(estabelecimento);

            model.Estabelecimento_Id = newItem.EstabelecimentoId;
            model.Endereco_Id = newItem.EnderecoId;

            return Ok(model);
        }


        [HttpPut("{estabelecimentoId}")]
        public IActionResult UpdateEstabelecimento(int estabelecimentoId, [FromBody] EstabelecimentoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_estabelecimentoRepository.EstabelecimentoExists(estabelecimentoId))
            {
                return NotFound($"Estabelecimento {estabelecimentoId} não existe!");
            }

            Estabelecimento estabelecimento = new Estabelecimento
            {
                EstabelecimentoId = model.Estabelecimento_Id,
                EstabelecimentoNome = model.Estabelecimento_Nome,
                EstabelecimentoCNPJ = model.Estabelecimento_CNPJ,
                EstabelecimentoCelular = model.Estabelecimento_Celular,
                EstabelecimentoTelefone = model.Estabelecimento_Telefone,
                EstabelecimentoEmail = model.Estabelecimento_Email,
                EnderecoId = model.Endereco_Id,
                EnderecoNumero = model.Endereco_Numero,
                EnderecoLogradouro = model.Endereco_Logradouro,
                EnderecoComplemento = model.Endereco_Complemento,
                EnderecoBairro = model.Endereco_Bairro,
                EnderecoCidade = model.Endereco_Cidade,
                EnderecoEstado = model.Endereco_Estado,
                EnderecoCEP = model.Endereco_CEP
            };

            _estabelecimentoRepository.UpdateEstabelecimento(estabelecimento);

            return NoContent();
        }

        [HttpDelete("{estabelecimentoId}")]
        public IActionResult DeleteEstabelecimento(int estabelecimentoId)
        {
            if (!_estabelecimentoRepository.EstabelecimentoExists(estabelecimentoId))
            {
                return NotFound($"Estabelecimento {estabelecimentoId} não existe!");
            }

            _estabelecimentoRepository.DeleteEstabelecimento(estabelecimentoId);

            return NoContent();
        }
    }
}
