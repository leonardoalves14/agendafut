using Dapper;
using Microsoft.Extensions.Configuration;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Services;
using System;
using System.Collections.Generic;

namespace SocietyAgendor.API.Concrete
{
    public class HorarioRepository : Base.Base, IHorarioRepository
    {
        public HorarioRepository(IConfiguration configuration) : base(configuration) { }

        public List<Horario> GetAllHorarios()
        {
            return ExecuteSP<Horario>("spsHorario");
        }

        public List<HorarioDisponivel> GetHorariosDisponiveis(DateTime dia)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@DiaEscolhido", dia, System.Data.DbType.DateTime);

            return ExecuteSP<HorarioDisponivel>("spsHorarioDisponivel", parameters);
        }

        public int CreateHorario(Horario model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Horario_Id", model.Horario_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
            parameters.Add("@Horario_De", model.Horario_De, System.Data.DbType.Time);
            parameters.Add("@Horario_Ate", model.Horario_Ate, System.Data.DbType.Time);
            parameters.Add("@DiaSemana_Id", model.DiaSemana_Id, System.Data.DbType.Int32);

            ExecuteSP("spiHorario", parameters);

            return parameters.Get<int>("@Horario_Id");
        }

        public void UpdateHorario(Horario model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Horario_Id", model.Horario_Id, System.Data.DbType.Int32);
            parameters.Add("@Horario_De", model.Horario_De, System.Data.DbType.Time);
            parameters.Add("@Horario_Ate", model.Horario_Ate, System.Data.DbType.Time);
            parameters.Add("@DiaSemana_Id", model.DiaSemana_Id, System.Data.DbType.Int32);

            ExecuteSP("spuHorario", parameters);
        }

        public void DeleteHorario(int horarioId, int diaSemanaId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Horario_Id", horarioId, System.Data.DbType.Int32);
            parameters.Add("@DiaSemana_Id", diaSemanaId, System.Data.DbType.Int32);

            ExecuteSP("spdHorario", parameters);
        }
    }
}
