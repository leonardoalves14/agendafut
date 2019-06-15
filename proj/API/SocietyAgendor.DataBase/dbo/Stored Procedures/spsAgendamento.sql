CREATE PROCEDURE spsAgendamento
AS
BEGIN
  SELECT CAST(NULL AS INT)          AS Agendamento_Id,
         CAST(NULL AS VARCHAR(200)) AS Agendamento_Descricao,
		 CAST(NULL AS DATETIME)     AS DataAgendamento,
		 CAST(NULL AS INT)          AS Dia_SemanaId,
		 CAST(NULL AS VARCHAR(13))  AS DiaSemana_Desc,
		 CAST(NULL AS INT)          AS Horario_Id,
		 CAST(NULL AS VARCHAR(19))  AS Horario_Desc,
		 CAST(NULL AS INT)          AS Cliente_Id,
		 CAST(NULL AS VARCHAR(255)) AS Cliente_Nome,
		 CAST(NULL AS INT)          AS Estabelecimento_Id,
		 CAST(NULL AS VARCHAR(200)) AS Estabelecimento_Nome
    INTO #Resultado
   WHERE 1 = 0
 
  INSERT INTO #Resultado (Agendamento_Id, Agendamento_Descricao, DataAgendamento, Dia_SemanaId, Horario_Id)
  SELECT a.Agendamento_Id, a.Agendamento_Desc, b.AgendamentoDiaSemanaHorario_Data, b.DiaSemana_Id, b.Horario_Id
    FROM Agendamento                      a
	     JOIN AgendamentoDiaSemanaHorario b ON a.Agendamento_Id = b.Agendamento_Id
 
  UPDATE a
     SET DiaSemana_Desc = b.DiaSemana_Desc
	FROM #Resultado     a
	     JOIN DiaSemana b ON a.Dia_SemanaId = b.DiaSemana_Id
 
  UPDATE a
     SET Horario_Desc = CAST(b.Horario_De AS VARCHAR(8)) + ' - ' + CAST(b.Horario_Ate AS VARCHAR(8))
	FROM #Resultado   a
	     JOIN Horario b ON a.Horario_Id = b.Horario_Id
 
  UPDATE a
     SET Cliente_Id   = b.Cliente_Id,
	     Cliente_Nome = c.Cliente_Nome
    FROM #Resultado              a
	     JOIN AgendamentoCliente b ON a.Agendamento_Id = b.Agendamento_Id
		 JOIN Cliente            c ON b.Cliente_Id     = c.Cliente_Id
 
  UPDATE a
     SET Estabelecimento_Id   = b.Estabelecimento_Id,
	     Estabelecimento_Nome = c.Estabelecimento_Nome
   FROM #Resultado                 a
        JOIN AgendaEstabelecimento b ON a.Agendamento_Id     = b.Agendamento_Id
		JOIN Estabelecimento       c ON b.Estabelecimento_Id = c.Estabelecimento_Id
 
  SELECT a.*
    FROM #Resultado a
	ORDER BY a.Agendamento_Id ASC
END