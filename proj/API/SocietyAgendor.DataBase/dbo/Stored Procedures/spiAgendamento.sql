CREATE PROCEDURE spiAgendamento
  @Agendamento_Id        INT OUTPUT,
  @Agendamento_Descricao VARCHAR(200),
  @Cliente_Id            INT,
  @Estabelecimento_Id    INT,
  @DataAgendamento       DATETIME,
  @Horario_Id            INT,
  @DiaSemana_Id          INT
AS
BEGIN
  SELECT (SELECT ISNULL(MAX(Agendamento_Id),0) + 1 FROM Agendamento) AS Agendamento_Id,
         @Agendamento_Descricao                                      AS Agendamento_Descricao,
         @Cliente_Id                                                 AS Cliente_Id,
         @Estabelecimento_Id                                         AS Estabelecimento_Id,
         @Horario_Id                                                 AS Horario_Id,
         @DiaSemana_Id                                               AS DiaSemana_Id,
         CONVERT(DATETIME, CONVERT(VARCHAR, @DataAgendamento, 112))  AS DataAgendamento
    INTO #TabParametros
         
  INSERT INTO Agendamento(Agendamento_Id, Agendamento_Desc, Agendamento_DataCadastro)
  SELECT a.Agendamento_Id, a.Agendamento_Descricao, GETDATE()
    FROM #TabParametros a
         
  INSERT INTO AgendamentoCliente(Agendamento_Id, Cliente_Id)
  SELECT a.Agendamento_Id, a.Cliente_Id
    FROM #TabParametros a
         
  INSERT INTO AgendaEstabelecimento(Agendamento_Id, Estabelecimento_Id)
  SELECT a.Agendamento_Id, a.Estabelecimento_Id
    FROM #TabParametros a
         
  INSERT INTO AgendamentoDiaSemanaHorario(Agendamento_Id, Horario_Id, DiaSemana_Id, AgendamentoDiaSemanaHorario_Data)
  SELECT a.Agendamento_Id, a.Horario_Id, a.DiaSemana_Id, a.DataAgendamento
    FROM #TabParametros a
         
  SELECT @Agendamento_Id = a.Agendamento_Id
    FROM #TabParametros a
END