CREATE PROCEDURE spiHorario
  @Horario_Id   INT OUTPUT,
  @Horario_De   TIME(0),
  @Horario_Ate  TIME(0),
  @DiaSemana_Id INT
AS
BEGIN
  SELECT (SELECT ISNULL(MAX(Horario_Id), 0) + 1 FROM Horario) AS Horario_Id,
         @Horario_De                                          AS Horario_De,
		 @Horario_Ate                                         AS Horario_Ate,
		 @DiaSemana_Id                                        AS DiaSemana_Id
    INTO #TabParametros
 
  INSERT INTO Horario(Horario_Id, Horario_De, Horario_Ate)
  SELECT a.Horario_Id, a.Horario_De, a.Horario_Ate
    FROM #TabParametros a
 
  INSERT INTO DiaSemanaHorario(DiaSemana_Id, Horario_Id)
  SELECT a.DiaSemana_Id, a.Horario_Id
    FROM #TabParametros a
 
  SELECT @Horario_Id = a.Horario_Id
    FROM #TabParametros a
END