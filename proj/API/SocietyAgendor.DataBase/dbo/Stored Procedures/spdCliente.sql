CREATE PROCEDURE spdCliente
  @Cliente_Id INT
AS
BEGIN
  SELECT @Cliente_Id                                                             AS Cliente_Id,
         (SELECT ClienteEndereco_Id FROM Cliente WHERE Cliente_Id = @Cliente_Id) AS ClienteEndereco_Id
	INTO #TabParametros

  DELETE Cliente
    FROM Cliente             a
	     JOIN #TabParametros b ON a.Cliente_Id = b.Cliente_Id
 
  DELETE ClienteEndereco
    FROM ClienteEndereco     a
	     JOIN #TabParametros b ON a.ClienteEndereco_Id = b.ClienteEndereco_Id
END