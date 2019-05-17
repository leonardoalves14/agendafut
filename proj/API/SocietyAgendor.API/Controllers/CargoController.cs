using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Models;
using SocietyAgendor.API.Services;

namespace SocietyAgendor.API.Controllers
{
    // TODO: RETORNAR 1 CARGO

    [Route("api/cargos")]
    public class CargoController : Controller
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly IMapper _mapper;

        public CargoController(ICargoRepository cargoRepository, IMapper mapper)
        {
            _cargoRepository = cargoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCargos()
        {
            var result = _mapper.Map<IEnumerable<CargoModel>>(_cargoRepository.GetAllCargos());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCargo([FromBody] CargoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cargo = _mapper.Map<Cargo>(model);
            model.Cargo_Id = _cargoRepository.CreateCargo(cargo);

            return Ok(model);
        }

        [HttpPut("{cargoId}")]
        public IActionResult UpdateCargo(int cargoId, [FromBody] CargoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_cargoRepository.CargoExists(cargoId))
                return NotFound();

            var cargo = _mapper.Map<Cargo>(model);
            _cargoRepository.UpdateCargo(cargo);

            return NoContent();
        }

        [HttpDelete("{cargoId}")]
        public IActionResult DeleteCargo(int cargoId)
        {
            if (!_cargoRepository.CargoExists(cargoId))
                return NotFound();

            _cargoRepository.DeleteCargo(cargoId);

            return NoContent();
        }
    }
}