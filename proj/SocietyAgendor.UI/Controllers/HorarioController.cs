using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocietyAgendor.UI.Models;
using SocietyAgendor.UI.Service;

namespace SocietyAgendor.UI.Controllers
{
    public class HorarioController : Controller
    {
        private readonly IHorarioService _horarioService;
        private readonly IDiaSemanaService _diaSemanaService;

        public HorarioController(IHorarioService horarioService, IDiaSemanaService diaSemanaService)
        {
            _horarioService = horarioService;
            _diaSemanaService = diaSemanaService;
        }

        public async Task<IActionResult> Index()
        {
            var horarios = await _horarioService.GetHorariosAsync();
            return View(horarios);
        }

        public IActionResult CreateHorario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateHorario(HorarioModel horario)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var newCargo = await _horarioService.CreateHorarioAsync(horario);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateHorario(int horarioId)
        {
            var horarios = await _horarioService.GetHorariosAsync();
            var horario = horarios.Find(c => c.Horario_Id == horarioId);

            ViewBag.DiaSemanaList = await GetDiaSemanaListAsync();

            return View("UpdateHorario", horario);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateHorario(HorarioModel horario)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception(ModelStateInvalidError.Message(ModelState));
            }

            var response = await _horarioService.UpdateHorarioAsync(horario);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteHorario(int horarioId)
        {
            var horarios = await _horarioService.GetHorariosAsync();
            var horario = horarios.Where(x => x.Horario_Id == horarioId).FirstOrDefault();

            return View(horario);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteHorario(HorarioModel horario)
        {
            await _horarioService.DeleteHorarioAsync(horario);

            return RedirectToAction("Index");
        }

        private async Task<SelectList> GetDiaSemanaListAsync()
        {
            var diaSemana = await _diaSemanaService.GetDiasDaSemanaAsync();
            diaSemana.Insert(0, new DiaDaSemanaModel { DiaSemana_Id = -1, DiaSemana_Desc = "Selecione um dia da semana ..." });

            return new SelectList(diaSemana, "DiaSemana_Id", "DiaSemana_Desc");
        }
    }
}