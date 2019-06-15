CREATE PROCEDURE spdHorario
  @Horario_Id   INT,
  @DiaSemana_Id INT
AS
BEGIN
  SELECT @Horario_Id   AS Horario_Id,
         @DiaSemana_Id AS DiaSemana_Id
	INTO #TabParametros
 
  DELETE DiaSemanaHorario
    FROM DiaSemanaHorario    a
	     JOIN #TabParametros b ON a.Horario_Id   = b.Horario_Id
		                      AND a.DiaSemana_Id = b.DiaSemana_Id
 
  DELETE Horario
    FROM Horario             a
	     JOIN #TabParametros b ON a.Horario_Id = b.Horario_Id
END