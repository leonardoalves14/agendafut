CREATE PROCEDURE speEstabelecimento
  @Estabelecimento_Id INT
AS
BEGIN
  SELECT @Estabelecimento_Id AS Estabelecimento_Id
    INTO #TabParametros
 
  SELECT (CASE WHEN (SELECT a.Estabelecimento_Id
                       FROM Estabelecimento     a
                            JOIN #TabParametros b ON a.Estabelecimento_Id = b.Estabelecimento_Id) > 0
          THEN 1 ELSE 0 END) AS [Exists]
END