using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.UI.Models;
using SocietyAgendor.UI.Service;

namespace SocietyAgendor.UI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IActionResult Table()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteService.GetClientesAsync();

            return View(clientes);
        }

        public IActionResult CreateCliente()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ClienteAdd(ClienteModel cliente)
        {
            // Repensar em como fazer aqui
            if (!ModelState.IsValid)
            {
                throw new Exception(ModelStateInvalidError.Message(ModelState));
            }

            var newCliente = await _clienteService.CreateClientesAsync(cliente);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCliente(int clienteId)
        {
            // Pego todos os cargos
            var cargos = await _clienteService.GetClientesAsync();

            // Filtro pelo cargo que vou editar
            var cargo = cargos.Where(c => c.Cliente_Id == clienteId).FirstOrDefault();

            return View(cargo);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCliente(ClienteModel cliente)
        {

            await _clienteService.DeleteClientesAsync((int)cliente.Cliente_Id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCliente(int clienteId)
        {
            // Pego todos os cargos
            var clientes = await _clienteService.GetClientesAsync();

            // Filtro pelo cargo que vou editar
            var cliente = clientes.Where(c => c.Cliente_Id == clienteId).FirstOrDefault();

            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCliente(ClienteModel cliente)
        {
            // Repensar em como fazer aqui
            if (!ModelState.IsValid)
            {
                throw new Exception(ModelStateInvalidError.Message(ModelState));
            }

            await _clienteService.UpdateClientesAsync(cliente);

            return RedirectToAction("Index");
        }

    }
}