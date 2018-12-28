using System;

namespace SocietyAgendor.API.Entities
{
    public class Horario
    {
        public int? HorarioId { get; set; }
        public TimeSpan HorarioDe { get; set; }
        public TimeSpan HorarioAte { get; set; }
        public int? DiaSemanaId { get; set; }
        public string DiaSemanaDesc { get; set; }
    }

    public class HorarioDisponivel
    {
        public int HorarioId { get; set; }
        public string HorarioDesc { get; set; }
    }
}
