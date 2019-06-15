CREATE PROCEDURE speCliente
  @Cliente_Id INT
AS
BEGIN
  SELECT @Cliente_Id AS Cliente_Id
    INTO #TabParametros
 
  SELECT (CASE WHEN (SELECT a.Cliente_Id
                       FROM Cliente             a
                            JOIN #TabParametros b ON a.Cliente_Id = b.Cliente_Id) > 0
          THEN 1 ELSE 0 END) AS [Exists]
END