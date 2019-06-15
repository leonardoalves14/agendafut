CREATE PROCEDURE spsHorarioDisponivel
  @DiaEscolhido DATETIME
AS
BEGIN
  SELECT CAST(NULL AS INT)                                           AS DiaSemana,
         CONVERT(DATETIME, CONVERT(VARCHAR(20), @DiaEscolhido, 112)) AS DiaEscolhido
    INTO #TabParametros
 
  UPDATE #TabParametros
     SET DiaSemana = DATEPART(WEEKDAY, a.DiaEscolhido)
    FROM #TabParametros a
 
  SELECT a.Horario_Id,
         CAST(a.Horario_De AS CHAR(8)) + ' - ' + CAST(a.Horario_Ate AS CHAR(8)) AS Horario_Desc
    FROM Horario                               a
         JOIN DiaSemanaHorario                 b ON a.Horario_Id   = b.Horario_Id
		 JOIN #TabParametros                   c ON b.DiaSemana_Id = c.DiaSemana
		 LEFT JOIN AgendamentoDiaSemanaHorario d ON b.Horario_Id   = d.Horario_Id
		                                        AND b.DiaSemana_Id = d.DiaSemana_Id
                                                AND c.DiaEscolhido = d.AgendamentoDiaSemanaHorario_Data
   WHERE d.Horario_Id IS NULL
   ORDER BY a.Horario_De ASC
END