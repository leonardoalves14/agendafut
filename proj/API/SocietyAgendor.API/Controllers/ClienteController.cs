using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Models;
using SocietyAgendor.API.Services;
using System.Collections.Generic;

namespace SocietyAgendor.API.Controllers
{
    // TODO: RETORNAR 1 CLIENTE

    [Route("api/clientes")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllClientes()
        {
            var result = _mapper.Map<IEnumerable<ClienteModel>>(_clienteRepository.GetAllClientes());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCliente([FromBody] ClienteModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cliente = _mapper.Map<Cliente>(model);
            Cliente createdClient = _clienteRepository.CreateCliente(cliente);

            model.Cliente_Id = createdClient.Cliente_Id;
            model.Endereco_Id = createdClient.Endereco_Id;

            return Ok(model);
        }

        [HttpPut("{clienteId}")]
        public IActionResult UpdateCliente(int clienteId, [FromBody] ClienteModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_clienteRepository.ClienteExists(clienteId))
                return NotFound($"Cliente {clienteId} não existe!");

            var cliente = _mapper.Map<Cliente>(model);
            _clienteRepository.UpdateCliente(cliente);

            return NoContent();
        }

        [HttpDelete("{clienteId}")]
        public IActionResult DeleteCliente(int clienteId)
        {
            if (!_clienteRepository.ClienteExists(clienteId))
                return NotFound($"Cliente {clienteId} não existe!");

            _clienteRepository.DeleteCliente(clienteId);

            return NoContent();
        }
    }
}
