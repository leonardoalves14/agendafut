using System;

namespace SocietyAgendor.API.Entities
{
    public class Horario
    {
        public int? Horario_Id { get; set; }
        public TimeSpan Horario_De { get; set; }
        public TimeSpan Horario_Ate { get; set; }
        public int? DiaSemana_Id { get; set; }
        public string DiaSemana_Desc { get; set; }
    }
}
