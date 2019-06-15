CREATE PROCEDURE spsDiaSemana
AS  
BEGIN	
  SELECT a.DiaSemana_Id, a.DiaSemana_Desc
    FROM DiaSemana a
   ORDER BY a.DiaSemana_Id
END