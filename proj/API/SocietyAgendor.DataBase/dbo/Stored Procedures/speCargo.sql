CREATE PROCEDURE speCargo
  @Cargo_Id INT
AS
BEGIN
  SELECT @Cargo_Id AS Cargo_Id
    INTO #TabParametros
 
  SELECT (CASE WHEN (SELECT a.Cargo_Id
	                   FROM Cargo               a
                            JOIN #TabParametros b ON a.Cargo_Id = b.Cargo_Id) > 0
	      THEN 1 ELSE 0 END) AS [Exists]
END