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

        public AgendamentoController(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        [HttpGet]
        public IActionResult GetAllAgendamentos()
        {
            List<AgendamentoModel> result = new List<AgendamentoModel>();
            List<Agendamento> list = _agendamentoRepository.GetAllAgendamentos();

            foreach (var agendamento in list)
            {
                result.Add(new AgendamentoModel
                {
                    Agendamento_Id = agendamento.AgendamentoId,
                    Agendamento_Descricao = agendamento.AgendamentoDescricao,
                    DataAgendamento = agendamento.DataAgendamento,
                    DiaSemana_Id = agendamento.DiaSemanaId,
                    DiaSemana_Desc = agendamento.DiaSemanaDesc,
                    Horario_Id = agendamento.HorarioId,
                    Horario_Desc = agendamento.HorarioDesc,
                    Cliente_Id = agendamento.ClienteId,
                    Cliente_Nome = agendamento.ClienteNome,
                    Estabelecimento_Id = agendamento.EstabelecimentoId,
                    Estabelecimento_Nome = agendamento.EstabelecimentoNome
                });
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateAgendamento([FromBody] AgendamentoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Agendamento agendamento = new Agendamento
            {
                AgendamentoDescricao = model.Agendamento_Descricao,
                ClienteId = model.Cliente_Id,
                EstabelecimentoId = model.Estabelecimento_Id,
                DataAgendamento = model.DataAgendamento,
                HorarioId = model.Horario_Id,
                DiaSemanaId = model.DiaSemana_Id
            };

            Agendamento newAgendamento = _agendamentoRepository.CreateAgendamento(agendamento);
            model.Agendamento_Id = newAgendamento.AgendamentoId;

            return Ok(model);
        }

        [HttpPut("{agendamentoId}")]
        public IActionResult UpdateAgendamento(int agendamentoId, [FromBody] AgendamentoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Agendamento agendamento = new Agendamento
            {
                AgendamentoId = model.Agendamento_Id,
                AgendamentoDescricao = model.Agendamento_Descricao,
                DataAgendamento = model.DataAgendamento,
                HorarioId = model.Horario_Id,
                DiaSemanaId = model.DiaSemana_Id
            };

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
