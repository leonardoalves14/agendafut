using SocietyAgendor.UI.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SocietyAgendor.UI.Service
{
    public interface ICargoService
    {
        Task<List<CargoModel>> GetCargosAsync();
        Task<CargoModel> CreateHorarioAsync(CargoModel model);
        Task<HttpStatusCode> UpdateCargoAsync(CargoModel model);
        Task<HttpStatusCode> DeleteCargoAsync(int cargoId);
    }
}
