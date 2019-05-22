using AutoMapper;
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
        private readonly IMapper _mapper;

        public EstabelecimentoController(IEstabelecimentoRepository estabelecimentoRepository, IMapper mapper)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
            _mapper = mapper;
        }

        public IActionResult GetAllEstabelecimentos()
        {
            var result = _mapper.Map<IEnumerable<EstabelecimentoModel>>(_estabelecimentoRepository.GetAllEstabelecimentos());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateEstabelecimento([FromBody] EstabelecimentoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var estabelecimento = _mapper.Map<Estabelecimento>(model);
            Estabelecimento newItem = _estabelecimentoRepository.CreateEstabelecimento(estabelecimento);

            model.Estabelecimento_Id = newItem.Estabelecimento_Id;
            model.Endereco_Id = newItem.Endereco_Id;

            return Ok(model);
        }

        [HttpPut("{estabelecimentoId}")]
        public IActionResult UpdateEstabelecimento(int estabelecimentoId, [FromBody] EstabelecimentoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_estabelecimentoRepository.EstabelecimentoExists(estabelecimentoId))
                return NotFound($"Estabelecimento {estabelecimentoId} não existe!");

            var estabelecimento = _mapper.Map<Estabelecimento>(model);
            _estabelecimentoRepository.UpdateEstabelecimento(estabelecimento);

            return NoContent();
        }

        [HttpDelete("{estabelecimentoId}")]
        public IActionResult DeleteEstabelecimento(int estabelecimentoId)
        {
            if (!_estabelecimentoRepository.EstabelecimentoExists(estabelecimentoId))
                return NotFound($"Estabelecimento {estabelecimentoId} não existe!");

            _estabelecimentoRepository.DeleteEstabelecimento(estabelecimentoId);

            return NoContent();
        }
    }
}
