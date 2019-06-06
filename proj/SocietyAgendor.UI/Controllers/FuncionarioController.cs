using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> CreateFuncionario()
        {
            ViewBag.CargoList = await GetCargosListAsync();
            ViewBag.EstabelecimentoList = await GetEstabelecimentosListAsync();
            ViewBag.UsuarioList = await GetUsuarioListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FuncionarioAdd(FuncionarioModel usuario)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Propriedades Inválidas");
            }

            var newFunc = await _funcionarioService.CreateFuncionarioAsync(usuario);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateFuncionario(int funcionarioId)
        {
            var funcionarios = await _funcionarioService.GetFuncionariosAsync();
            var funcionario = funcionarios.Find(c => c.Funcionario_Id == funcionarioId);

            ViewBag.CargoList = await GetCargosListAsync();
            ViewBag.EstabelecimentoList = await GetEstabelecimentosListAsync();
            ViewBag.UsuarioList = await GetUsuarioListAsync();

            return View("UpdateFuncionario", funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFuncionario(FuncionarioModel funcionario)
        {

            if (!ModelState.IsValid)
            {
                throw new Exception("Propriedades Inválidas");
            }

            await _funcionarioService.UpdateFuncionarioAsync(funcionario);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteFuncionario(int funcionarioId)
        {
            var funcionarios = await _funcionarioService.GetFuncionariosAsync();
            var funcionario = funcionarios.Where(x => x.Funcionario_Id == funcionarioId).FirstOrDefault();

            return View(funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFuncionario(FuncionarioModel funcionario)
        {
            await _funcionarioService.DeleteFuncionarioAsync((int)funcionario.Funcionario_Id);

            return RedirectToAction("Index");
        }


        private async Task<SelectList> GetCargosListAsync()
        {
            var cargos = await _cargoService.GetCargosAsync();
            cargos.Insert(0, new CargoModel { Cargo_Id = -1, Cargo_Desc = "Selecione um Cargo..." });

            return new SelectList(cargos, "Cargo_Id", "Cargo_Desc");
        }

        private async Task<SelectList> GetEstabelecimentosListAsync()
        {
            var estabelecimentos = await _estabelecimentoService.GetEstabelecimentoAsync();
            estabelecimentos.Insert(0, new EstabelecimentoModel { Estabelecimento_Id = -1, Estabelecimento_Nome = "Selecione um Estebelecimento..." });

            return new SelectList(estabelecimentos, "Estabelecimento_Id", "Estabelecimento_Nome");
        }

        private async Task<SelectList> GetUsuarioListAsync()
        {
            var usuarios = await _usuarioService.GetUsuariosAsync();
            usuarios.Insert(0, new UsuarioModel { Usuario_Id = -1, Usuario_Login = "Selecione um Usuário..." });

            return new SelectList(usuarios, "Usuario_Id", "Usuario_Login");
        }
    }
}