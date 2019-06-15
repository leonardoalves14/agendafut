CREATE PROCEDURE spiCargo
  @Cargo_Id  INT OUTPUT,
  @Cargo_Des VARCHAR(255)
AS
BEGIN
  SELECT (SELECT ISNULL(MAX(Cargo_Id),0) + 1 FROM Cargo) AS Cargo_Id,
         @Cargo_Des                                      AS Cargo_Des
	INTO #TabParametros
 
  INSERT INTO Cargo(Cargo_Id, Cargo_Desc)
  SELECT a.Cargo_Id, a.Cargo_Des
    FROM #TabParametros a
 
  SELECT @Cargo_Id = a.Cargo_Id
    FROM #TabParametros a
END