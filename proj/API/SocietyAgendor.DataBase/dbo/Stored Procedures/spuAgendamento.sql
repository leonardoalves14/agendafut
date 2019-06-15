CREATE PROCEDURE spuAgendamento
  @Agendamento_Id        INT,
  @Agendamento_Descricao VARCHAR(200),
  @DataAgendamento       DATETIME,
  @Horario_Id            INT,
  @DiaSemana_Id          INT
AS
BEGIN
  SELECT @Agendamento_Id                                            AS Agendamento_Id,
         @Agendamento_Descricao                                     AS Agendamento_Descricao,
		 CONVERT(DATETIME, CONVERT(VARCHAR, @DataAgendamento, 112)) AS DataAgendamento,
		 @Horario_Id                                                AS Horario_Id,
		 @DiaSemana_Id                                              AS DiaSemana_Id
    INTO #TabParametros
 
  UPDATE a
     SET Agendamento_Desc = b.Agendamento_Descricao
    FROM Agendamento         a
	     JOIN #TabParametros b ON a.Agendamento_Id = b.Agendamento_Id
   WHERE a.Agendamento_Desc <> b.Agendamento_Descricao
 
  DELETE FROM a
    FROM AgendamentoDiaSemanaHorario a
	     JOIN #TabParametros         b ON a.Agendamento_Id = b.Agendamento_Id
   WHERE a.DiaSemana_Id <> b.DiaSemana_Id
      OR a.Horario_Id   <> b.Horario_Id
 
  UPDATE a
     SET AgendamentoDiaSemanaHorario_Data = b.DataAgendamento
    FROM AgendamentoDiaSemanaHorario a
         JOIN #TabParametros         b ON a.Agendamento_Id = b.Agendamento_Id
   WHERE a.AgendamentoDiaSemanaHorario_Data <> b.DataAgendamento
 
  INSERT INTO AgendamentoDiaSemanaHorario (Agendamento_Id, DiaSemana_Id, Horario_Id, AgendamentoDiaSemanaHorario_Data)
  SELECT a.Agendamento_Id, a.DiaSemana_Id, a.Horario_Id, a.DataAgendamento
    FROM #TabParametros                        a
	     LEFT JOIN AgendamentoDiaSemanaHorario b ON a.Agendamento_Id = b.Agendamento_Id
   WHERE b.Agendamento_Id IS NULL
END