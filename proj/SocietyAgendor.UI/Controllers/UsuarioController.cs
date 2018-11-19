using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.UI.Models;
using SocietyAgendor.UI.Service;
using System;
using System.Threading.Tasks;

namespace SocietyAgendor.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.GetUsuariosAsync();

            return View(usuarios);
        }        

        public IActionResult UsuarioAdd()
        {
            return PartialView("_NewUserPartial", new UsuarioModel());
        }        

        [HttpPost]
        public async Task<IActionResult> UsuarioAdd(UsuarioModel usuario)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception(ModelStateInvalidError.Message(ModelState));
            }

           var newUser = await _usuarioService.CreateUsuarioAsync(usuario);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UsuarioUpdate(int usuarioId)
        {
            var usuarios = await _usuarioService.GetUsuariosAsync();
            var usuario = usuarios.Find(c => c.Usuario_Id == usuarioId);

            return PartialView("_EditUserPartial", usuario);
        }

        [HttpPost]
        public async Task<IActionResult> UsuarioUpdate(UsuarioModel usuario)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception(ModelStateInvalidError.Message(ModelState));
            }

            var response = await _usuarioService.UpdateUsuarioAsync(usuario);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UsuarioDeletePartial(int usuarioId)
        {
            var usuarios = await _usuarioService.GetUsuariosAsync();
            var usuario = usuarios.Find(c => c.Usuario_Id == usuarioId);

            return PartialView("_DeleteUserPartial", usuario);
        }
                
        [HttpPost]
        public async Task<IActionResult> UsuarioDelete(UsuarioModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception(ModelStateInvalidError.Message(ModelState));
            }

            var response = await _usuarioService.DeleteUsuarioAsync((int)model.Usuario_Id);

            return RedirectToAction("Index");
        }
    }
}