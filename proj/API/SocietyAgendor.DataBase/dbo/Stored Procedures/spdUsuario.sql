CREATE PROCEDURE spdUsuario
  @Usuario_Id INT
AS
BEGIN
  SELECT @Usuario_Id    AS Usuario_Id
    INTO #TabParametros
 
  DELETE Usuario     
    FROM Usuario             a
	     JOIN #TabParametros b ON a.Usuario_Id = b.Usuario_Id
END