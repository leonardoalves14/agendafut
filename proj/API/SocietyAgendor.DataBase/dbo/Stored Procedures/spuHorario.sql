CREATE PROCEDURE spuHorario
  @Horario_Id   INT,
  @Horario_De   TIME(0),
  @Horario_Ate  TIME(0),
  @DiaSemana_Id INT
AS
BEGIN
  SELECT @Horario_Id   AS Horario_Id,
         @Horario_De   AS Horario_De,
		 @Horario_Ate  AS Horario_Ate,
		 @DiaSemana_Id AS DiaSemana_Id
    INTO #TabParametros
 
  UPDATE Horario
     SET Horario_De  = a.Horario_De,
	     Horario_Ate = a.Horario_Ate
	FROM Horario             a
	     JOIN #TabParametros b ON a.Horario_Id = b.Horario_Id
 
  DELETE DiaSemanaHorario
    FROM DiaSemanaHorario    a
	     JOIN #TabParametros b ON a.Horario_Id = b.Horario_Id
   WHERE a.DiaSemana_Id <> b.DiaSemana_Id
	     
  INSERT INTO DiaSemanaHorario(DiaSemana_Id, Horario_Id)
  SELECT a.DiaSemana_Id, a.Horario_Id
    FROM #TabParametros             a
	     LEFT JOIN DiaSemanaHorario b ON a.Horario_Id = b.Horario_Id
   WHERE a.DiaSemana_Id IS NOT NULL
     AND b.Horario_Id IS NULL
END