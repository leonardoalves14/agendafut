using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.UI.Models;
using SocietyAgendor.UI.Service;

namespace SocietyAgendor.UI.Controllers
{
    public class EstabelecimentoController : Controller
    {
        private readonly IEstabelecimentoService _estabelecimentoService;

        public EstabelecimentoController(IEstabelecimentoService estabelecimentoService)
        {
            _estabelecimentoService = estabelecimentoService;
        }

        public IActionResult EditEstab()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var estabelecimentos = await _estabelecimentoService.GetEstabelecimentoAsync();

            return View(estabelecimentos);
        }

        [HttpPost]
        public async Task<IActionResult> EstabalecimentoAdd(EstabelecimentoModel estabelecimento)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception(ModelStateInvalidError.Message(ModelState));
            }

            var newFunc = await _estabelecimentoService.CreateEstabelecimentoAsync(estabelecimento);

            return RedirectToAction("Index");
        }
    }
}