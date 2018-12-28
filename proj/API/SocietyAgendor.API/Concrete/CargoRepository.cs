using Dapper;
using Microsoft.Extensions.Configuration;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Services;
using System.Collections.Generic;
using System.Linq;

namespace SocietyAgendor.API.Concrete
{
    public class CargoRepository : Base.Base, ICargoRepository
    {
        public CargoRepository(IConfiguration configuration) : base(configuration) { }

        public List<Cargo> GetAllCargos()
        {
            return ExecuteSP<Cargo>("spsCargo");
        }

        public Cargo CreateCargo(Cargo model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Cargo_Id", model.CargoId, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
            parameters.Add("@Cargo_Des", model.CargoDesc, System.Data.DbType.String);

            ExecuteSP("spiCargo", parameters);
            model.CargoId = parameters.Get<int>("@Cargo_Id");

            return model;
        }

        public void UpdateCargo(Cargo model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Cargo_Id", model.CargoId, System.Data.DbType.Int32);
            parameters.Add("@Cargo_Des", model.CargoDesc, System.Data.DbType.String);

            ExecuteSP("spuCargo", parameters);
        }

        public void DeleteCargo(int cargoId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Cargo_Id", cargoId, System.Data.DbType.Int32);

            ExecuteSP("spdCargo", parameters);
        }

        public bool CargoExists(int cargoId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Cargo_Id", cargoId, System.Data.DbType.Int32);

            var cargos = new List<HelperEntity>();
            var list = ExecuteSP<HelperEntity>("speCargo", parameters);

            foreach (var cargo in list)
            {
                cargos.Add(cargo);
            }

            if (cargos.FirstOrDefault().Exists)
                return true;
            else
                return false;
        }
    }
}
