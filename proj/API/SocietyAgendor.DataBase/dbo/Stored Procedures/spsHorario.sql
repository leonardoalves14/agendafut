CREATE PROCEDURE spsHorario
AS
BEGIN
  SELECT a.Horario_Id,
         a.Horario_De,
		 a.Horario_Ate,
		 b.DiaSemana_Id,
		 c.DiaSemana_Desc
    FROM Horario               a
	     JOIN DiaSemanaHorario b ON a.Horario_Id   = b.Horario_Id
		 JOIN DiaSemana        c ON b.DiaSemana_Id = c.DiaSemana_Id
   ORDER BY c.DiaSemana_Id, a.Horario_De
END