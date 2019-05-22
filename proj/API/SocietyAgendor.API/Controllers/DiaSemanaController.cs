using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.API.Models;
using SocietyAgendor.API.Services;

namespace SocietyAgendor.API.Controllers
{
    [Route("api/diassemana")]
    public class DiaSemanaController : Controller
    {
        private readonly IDiaSemanaRepository _diaSemanaRepository;
        private readonly IMapper _mapper;

        public DiaSemanaController(IDiaSemanaRepository diaSemanaRepository, IMapper mapper)
        {
            _diaSemanaRepository = diaSemanaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllDiasSemana()
        {
            var result = _mapper.Map<IEnumerable<DiaSemanaModel>>(_diaSemanaRepository.GetAllDiasDaSemana());
            return Ok(result);
        }
    }
}