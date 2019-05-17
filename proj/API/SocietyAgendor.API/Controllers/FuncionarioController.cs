using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Models;
using SocietyAgendor.API.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyAgendor.API.Controllers
{
    // TODO: RETORNAR 1 FUNCIONÁRIO

    [Route("api/funcionarios")]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllFuncionarios()
        {
            var result = _mapper.Map<IEnumerable<FuncionarioModel>>(_funcionarioRepository.GetAllFuncionarios());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateFuncionario([FromBody] FuncionarioModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var funcionario = _mapper.Map<Funcionario>(model);
            var newFuncionario = _funcionarioRepository.CreateFuncionario(funcionario);

            model.Funcionario_Id = newFuncionario.Funcionario_Id;
            model.Endereco_Id = newFuncionario.Endereco_Id;

            return Ok(model);
        }

        [HttpPut("{funcionarioId}")]
        public IActionResult UpdateFuncionario(int funcionarioId, [FromBody] FuncionarioModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_funcionarioRepository.FuncionarioExists(funcionarioId))
                return NotFound($"Funcionário {funcionarioId} não existe!");

            var funcionario = _mapper.Map<Funcionario>(model);
            _funcionarioRepository.UpdateFuncionario(funcionario);

            return NoContent();
        }

        [HttpDelete("{funcionarioId}")]
        public IActionResult DeleteFuncionario(int funcionarioId)
        {
            if (!_funcionarioRepository.FuncionarioExists(funcionarioId))
                return NotFound($"Funcionário {funcionarioId} não existe!");

            _funcionarioRepository.DeleteFuncionario(funcionarioId);

            return NoContent();
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetFuncionarioByUserId(int usuarioId)
        {
            Funcionario funcionario = await _funcionarioRepository.GetFuncionarioByUsuarioId(usuarioId);

            if (funcionario == null)
                return NotFound();

            var result = _mapper.Map<PerfilFuncionarioModel>(funcionario);

            return Ok(result);
        }
    }
}
