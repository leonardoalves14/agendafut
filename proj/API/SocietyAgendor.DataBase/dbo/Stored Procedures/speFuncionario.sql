CREATE PROCEDURE speFuncionario
  @Funcionario_Id INT
AS
BEGIN
  SELECT @Funcionario_Id AS Funcionario_Id
    INTO #TabParametros
 
  SELECT (CASE WHEN (SELECT a.Funcionario_Id
	                   FROM Funcionario         a
                            JOIN #TabParametros b ON a.Funcionario_Id = b.Funcionario_Id) > 0
	      THEN 1 ELSE 0 END) AS [Exists]
END