using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.UI.Models;
using SocietyAgendor.UI.Service;
using System.Collections.Generic;
using System.Linq;

namespace SocietyAgendor.UI.Controllers
{
    public class EstabelecimentoController : Controller
    {
        private readonly IEstabelecimentoService _estabelecimentoService;

        public EstabelecimentoController(IEstabelecimentoService estabelecimentoService)
        {
            _estabelecimentoService = estabelecimentoService;
        }

        //puxando view de edição de estabelecimento
        public IActionResult CreateEstabelecimento()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var estabelecimentos = await _estabelecimentoService.GetEstabelecimentoAsync();

            return View(estabelecimentos);
        }

        public IActionResult CreateEstabelecimentoTest()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EstabalecimentoAddTest(EstabelecimentoModel estabelecimento)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception(ModelStateInvalidError.Message(ModelState));
            }

            var newEstab = await _estabelecimentoService.CreateEstabelecimentoAsync(estabelecimento);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EstabalecimentoAdd(EstabelecimentoModel estabelecimento)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception(ModelStateInvalidError.Message(ModelState));
            }

            var newEstab = await _estabelecimentoService.CreateEstabelecimentoAsync(estabelecimento);

            return RedirectToAction("Index");
        }

        /* parte de update*/
        public async Task<IActionResult> UpdateEstabelecimento(int estabelecimentoId)
        {
            // Pego todos os cargos
            var estabelecimentos = await _estabelecimentoService.GetEstabelecimentoAsync();

            var estab = estabelecimentos.FindIndex(e => e.Estabelecimento_Id == estabelecimentoId);

            return View(estab);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEstabelecimento(EstabelecimentoModel estabelecimento)
        {
            // Repensar em como fazer aqui
            if (!ModelState.IsValid)
            {
                throw new Exception(ModelStateInvalidError.Message(ModelState));
            }

            await _estabelecimentoService.UpdateEstabelecimentoAsync(estabelecimento);

            return RedirectToAction("Index");
        }
    }
}