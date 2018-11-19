using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.UI.Models;
using SocietyAgendor.UI.Service;

namespace SocietyAgendor.UI.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly ICargoService _cargoService;
        private readonly IEstabelecimentoService _estabelecimentoService;
        private readonly IUsuarioService _usuarioService;

        public FuncionarioController(IFuncionarioService funcionarioService,
                                     ICargoService cargoService,
                                     IEstabelecimentoService estabelecimentoService,
                                     IUsuarioService usuarioService)
        { 
            _funcionarioService = funcionarioService;
            _cargoService = cargoService;
            _estabelecimentoService = estabelecimentoService;
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            var funcionarios = await _funcionarioService.GetFuncionariosAsync();

            return View(funcionarios);
        }

        public IActionResult FuncionarioAdd()
        {
            return PartialView("_NewFuncPartial", new FuncionarioModel());
        }

        [HttpPost]
        public async Task<IActionResult> FuncionarioAdd(FuncionarioModel usuario)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception(ModelStateInvalidError.Message(ModelState));
            }

            var newFunc = await _funcionarioService.CreateFuncionarioAsync(usuario);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateFuncionario(int funcionarioId)
        {
            var funcionarios = await _funcionarioService.GetFuncionariosAsync();
            var funcionario = funcionarios.Find(c => c.Funcionario_Id == funcionarioId);

            ViewBag.CargoList = await _cargoService.GetCargosAsync();
            ViewBag.EstabelecimentoList = await _estabelecimentoService.GetEstabelecimentoAsync();
            ViewBag.UsuarioList = await _usuarioService.GetUsuariosAsync();

            return View("UpdateFuncionario", funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFuncionario(FuncionarioModel funcionario)
        {
            
            if (!ModelState.IsValid)
            {
                throw new Exception(ModelStateInvalidError.Message(ModelState));
            }

            await _funcionarioService.UpdateFuncionarioAsync(funcionario);

            return RedirectToAction("Index");
        }
    }
}