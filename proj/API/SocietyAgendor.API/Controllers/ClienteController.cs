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

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public IActionResult GetAllClientes()
        {
            List<ClienteModel> result = new List<ClienteModel>();
            List<Cliente> list = _clienteRepository.GetAllClientes();

            foreach (var item in list)
            {
                result.Add(new ClienteModel
                {
                    Cliente_Id = item.ClienteId,
                    Cliente_Nome = item.ClienteNome,
                    Cliente_CPF = item.ClienteCPF,
                    Cliente_RG = item.ClienteRG,
                    Cliente_DtNascimento = item.ClienteDtNascimento,
                    Cliente_Email = item.ClienteEmail,
                    Cliente_Celular = item.ClienteCelular,
                    Cliente_Telefone = item.ClienteTelefone,
                    Endereco_Id = item.EnderecoId,
                    Endereco_Logradouro = item.EnderecoLogradouro,
                    Endereco_Numero = item.EnderecoNumero,
                    Endereco_Bairro = item.EnderecoBairro,
                    Endereco_Complemento = item.EnderecoComplemento,
                    Endereco_CEP = item.EnderecoCEP,
                    Endereco_Cidade = item.EnderecoCidade,
                    Endereco_Estado = item.EnderecoEstado
                });
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCliente([FromBody] ClienteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Cliente cliente = new Cliente
            {
                ClienteNome = model.Cliente_Nome,
                ClienteCPF = model.Cliente_CPF,
                ClienteRG = model.Cliente_RG,
                ClienteDtNascimento = model.Cliente_DtNascimento,
                ClienteEmail = model.Cliente_Email,
                ClienteCelular = model.Cliente_Celular,
                ClienteTelefone = model.Cliente_Telefone,
                EnderecoLogradouro = model.Endereco_Logradouro,
                EnderecoNumero = model.Endereco_Numero,
                EnderecoBairro = model.Endereco_Bairro,
                EnderecoComplemento = model.Endereco_Complemento,
                EnderecoCEP = model.Endereco_CEP,
                EnderecoCidade = model.Endereco_Cidade,
                EnderecoEstado = model.Endereco_Estado
            };

            Cliente newCliente = _clienteRepository.CreateCliente(cliente);
            model.Cliente_Id = newCliente.ClienteId;

            return Ok(model);
        }

        [HttpPut("{clienteId}")]
        public IActionResult UpdateCliente(int clienteId, [FromBody] ClienteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_clienteRepository.ClienteExists(clienteId))
            {
                return NotFound($"Cliente {clienteId} não existe!");
            }

            Cliente cliente = new Cliente
            {
                ClienteId = model.Cliente_Id,
                ClienteNome = model.Cliente_Nome,
                ClienteCPF = model.Cliente_CPF,
                ClienteRG = model.Cliente_RG,
                ClienteDtNascimento = model.Cliente_DtNascimento,
                ClienteEmail = model.Cliente_Email,
                ClienteCelular = model.Cliente_Celular,
                ClienteTelefone = model.Cliente_Telefone,
                EnderecoId = model.Endereco_Id,
                EnderecoLogradouro = model.Endereco_Logradouro,
                EnderecoNumero = model.Endereco_Numero,
                EnderecoBairro = model.Endereco_Bairro,
                EnderecoComplemento = model.Endereco_Complemento,
                EnderecoCEP = model.Endereco_CEP,
                EnderecoCidade = model.Endereco_Cidade,
                EnderecoEstado = model.Endereco_Estado
            };

            _clienteRepository.UpdateCliente(cliente);

            return NoContent();
        }

        [HttpDelete("{clienteId}")]
        public IActionResult DeleteCliente(int clienteId)
        {
            if (!_clienteRepository.ClienteExists(clienteId))
            {
                return NotFound($"Cliente {clienteId} não existe!");
            }

            _clienteRepository.DeleteCliente(clienteId);

            return NoContent();
        }
    }
}
