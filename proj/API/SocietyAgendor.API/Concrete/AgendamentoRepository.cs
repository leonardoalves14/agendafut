using Dapper;
using Microsoft.Extensions.Configuration;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Services;
using System.Collections.Generic;

namespace SocietyAgendor.API.Concrete
{
    public class AgendamentoRepository : Base.Base, IAgendamentoRepository
    {
        public AgendamentoRepository(IConfiguration configuration) : base(configuration) { }

        public List<Agendamento> GetAllAgendamentos()
        {
            return ExecuteSP<Agendamento>("spsAgendamento");
        }

        public Agendamento CreateAgendamento(Agendamento model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Agendamento_Id", model.AgendamentoId, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
            parameters.Add("@Agendamento_Descricao", model.AgendamentoDescricao, System.Data.DbType.String);
            parameters.Add("@Cliente_Id", model.ClienteId, System.Data.DbType.Int32);
            parameters.Add("@Estabelecimento_Id", model.EstabelecimentoId, System.Data.DbType.Int32);
            parameters.Add("@DataAgendamento", model.DataAgendamento, System.Data.DbType.DateTime);
            parameters.Add("@Horario_Id", model.HorarioId, System.Data.DbType.Int32);
            parameters.Add("@DiaSemana_Id", model.DiaSemanaId, System.Data.DbType.Int32);

            ExecuteSP("spiAgendamento", parameters);
            model.AgendamentoId = parameters.Get<int>("@Agendamento_Id");

            return model;
        }

        public void UpdateAgendamento(Agendamento model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Agendamento_Id", model.AgendamentoId, System.Data.DbType.Int32);
            parameters.Add("@Agendamento_Descricao", model.AgendamentoDescricao, System.Data.DbType.String);
            parameters.Add("@DataAgendamento", model.DataAgendamento, System.Data.DbType.DateTime);
            parameters.Add("@Horario_Id", model.HorarioId, System.Data.DbType.Int32);
            parameters.Add("@DiaSemana_Id", model.DiaSemanaId, System.Data.DbType.Int32);

            ExecuteSP("spuAgendamento", parameters);
        }

        public void DeleteAgendamento(int agendamentoId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Agendamento_Id", agendamentoId, System.Data.DbType.Int32);

            ExecuteSP("spdAgendamento", parameters);
        }
    }
}
