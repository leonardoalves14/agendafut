CREATE PROCEDURE spuCargo
  @Cargo_Id  INT,
  @Cargo_Des VARCHAR(255)
AS
BEGIN
  SELECT @Cargo_Id  AS Cargo_Id,
         @Cargo_Des AS Cargo_Des
	INTO #TabParametros
 
  UPDATE Cargo
     SET Cargo_Desc = b.Cargo_Des
    FROM Cargo               a
         JOIN #TabParametros b ON a.Cargo_Id = b.Cargo_Id
END