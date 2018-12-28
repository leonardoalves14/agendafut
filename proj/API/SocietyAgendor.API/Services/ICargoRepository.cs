using SocietyAgendor.API.Entities;
using System.Collections.Generic;

namespace SocietyAgendor.API.Services
{
    public interface ICargoRepository
    {
        List<Cargo> GetAllCargos();
        Cargo CreateCargo(Cargo model);
        void UpdateCargo(Cargo model);
        void DeleteCargo(int cargoId);
        bool CargoExists(int cargoId);
    }
}
