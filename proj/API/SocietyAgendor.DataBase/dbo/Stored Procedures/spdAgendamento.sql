CREATE PROCEDURE spdAgendamento  
  @Agendamento_Id INT  
AS  
BEGIN  
  SELECT @Agendamento_Id AS Agendamento_Id  
    INTO #TabParametros  
   
  DELETE FROM a  
    FROM AgendamentoDiaSemanaHorario a  
         JOIN #TabParametros         b ON a.Agendamento_Id = b.Agendamento_Id  
   
  DELETE FROM a
    FROM AgendaEstabelecimento a  
         JOIN #TabParametros   b ON a.Agendamento_Id = b.Agendamento_Id  
   
  DELETE FROM a
    FROM AgendamentoCliente  a  
         JOIN #TabParametros b ON a.Agendamento_Id = b.Agendamento_Id  
   
  DELETE FROM a
    FROM Agendamento         a  
         JOIN #TabParametros b ON a.Agendamento_Id = b.Agendamento_Id
END