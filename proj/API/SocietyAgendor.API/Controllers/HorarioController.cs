using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Models;
using SocietyAgendor.API.Services;
using System;
using System.Collections.Generic;

namespace SocietyAgendor.API.Controllers
{
    // TODO: RETORNAR 1 HORÁRIO

    [Route("api/horarios")]
    public class HorarioController : Controller
    {
        private readonly IHorarioRepository _horarioRepository;
        private readonly IMapper _mapper;

        public HorarioController(IHorarioRepository horarioRepository, IMapper mapper)
        {
            _horarioRepository = horarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllHorarios()
        {
            var result = _mapper.Map<IEnumerable<HorarioModel>>(_horarioRepository.GetAllHorarios());
            return Ok(result);
        }

        [HttpGet("disponiveis/{dia}")]
        public IActionResult GetHorariosDisponiveis(DateTime dia)
        {
            var result = _mapper.Map<IEnumerable<HorarioDisponivelModel>>(_horarioRepository.GetHorariosDisponiveis(dia));
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateHorario([FromBody] HorarioModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var horario = _mapper.Map<Horario>(model);
            model.Horario_Id = _horarioRepository.CreateHorario(horario);

            return Ok(model);
        }

        [HttpPut("{horarioId}")]
        public IActionResult UpdateHorario(int horarioId, [FromBody] HorarioModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var horario = _mapper.Map<Horario>(model);
            _horarioRepository.UpdateHorario(horario);

            return NoContent();
        }

        [HttpDelete("{horarioId}")]
        public IActionResult DeleteHorario([FromBody] HorarioModel model, int horarioId)
        {
            _horarioRepository.DeleteHorario((int)model.Horario_Id, (int)model.DiaSemana_Id);

            return NoContent();
        }
    }
}
