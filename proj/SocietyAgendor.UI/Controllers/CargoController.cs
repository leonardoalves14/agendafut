using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.UI.Models;
using SocietyAgendor.UI.Service;

namespace SocietyAgendor.UI.Controllers
{
    public class CargoController : Controller
    {
        private readonly ICargoService _cargoService;

        // controller de usuário é uma base pra se tomar pra fazer os outros/
        // construtor....

        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        public async Task<IActionResult> Index()
        {
            var cargos = await _cargoService.GetCargosAsync();

            return View(cargos);
        }

        public IActionResult CreateCargo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CargoAdd(CargoModel cargo)
        {
            // Repensar em como fazer aqui
            if (!ModelState.IsValid)
            {
                throw new Exception(ModelStateInvalidError.Message(ModelState));
            }

            var newCargo = await _cargoService.CreateHorarioAsync(cargo);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCargo(int cargoId)
        {
            // Pego todos os cargos
            var cargos = await _cargoService.GetCargosAsync();

            // Filtro pelo cargo que vou editar
            var cargo = cargos.Where(c => c.Cargo_Id == cargoId).FirstOrDefault();

            return View(cargo);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCargo(CargoModel cargo)
        {
            // Repensar em como fazer aqui
            if (!ModelState.IsValid)
            {
                throw new Exception(ModelStateInvalidError.Message(ModelState));
            }

            await _cargoService.UpdateCargoAsync(cargo);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCargo(int cargoId)
        {
            // Pego todos os cargos
            var cargos = await _cargoService.GetCargosAsync();

            // Filtro pelo cargo que vou editar
            var cargo = cargos.Where(c => c.Cargo_Id == cargoId).FirstOrDefault();

            return View(cargo);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCargo(CargoModel cargo)
        {

            await _cargoService.DeleteCargoAsync((int)cargo.Cargo_Id);

            return RedirectToAction("Index");
        }
    }
}