using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Models;
using SocietyAgendor.API.Services;
using System.Collections.Generic;

namespace SocietyAgendor.API.Controllers
{
    // TODO: RETORNAR 1 AGENDAMENTO

    [Route("api/agendamentos")]
    public class AgendamentoController : Controller
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IMapper _mapper;

        public AgendamentoController(IAgendamentoRepository agendamentoRepository, IMapper mapper)
        {
            _agendamentoRepository = agendamentoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAgendamentos()
        {
            var result = _mapper.Map<IEnumerable<AgendamentoModel>>(_agendamentoRepository.GetAllAgendamentos());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateAgendamento([FromBody] AgendamentoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var agendamento = _mapper.Map<Agendamento>(model);
            model.Agendamento_Id = _agendamentoRepository.CreateAgendamento(agendamento);

            return Ok(model);
        }

        [HttpPut("{agendamentoId}")]
        public IActionResult UpdateAgendamento(int agendamentoId, [FromBody] AgendamentoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var agendamento = _mapper.Map<Agendamento>(model);
            _agendamentoRepository.UpdateAgendamento(agendamento);

            return Ok(model);
        }

        [HttpDelete("{agendamentoId}")]
        public IActionResult DeleteAgendamento(int agendamentoId)
        {
            _agendamentoRepository.DeleteAgendamento(agendamentoId);

            return NoContent();
        }
    }
}
