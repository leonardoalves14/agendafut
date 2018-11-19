using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.UI.Models;
using SocietyAgendor.UI.Service;

namespace SocietyAgendor.UI.Controllers
{
    public class HorarioController : Controller
    {
        private readonly IHorarioService _horarioService;

        public HorarioController(IHorarioService horarioService)
        {
            _horarioService = horarioService;
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
    }
}