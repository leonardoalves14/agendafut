CREATE PROCEDURE spdCargo
  @Cargo_Id  INT
AS
BEGIN
  SELECT @Cargo_Id  AS Cargo_Id
	INTO #TabParametros
 
  DELETE Cargo
    FROM Cargo a
	     JOIN #TabParametros b ON a.Cargo_Id = b.Cargo_Id
END