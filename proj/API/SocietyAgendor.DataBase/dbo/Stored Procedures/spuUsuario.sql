CREATE PROCEDURE spuUsuario
  @Usuario_Id    INT,
  @Usuario_Login VARCHAR(50)
AS
BEGIN
  SELECT @Usuario_Id    AS Usuario_Id,
         @Usuario_Login AS Usuario_Login
    INTO #TabParametros
 
  UPDATE Usuario
     SET Usuario_Id    = b.Usuario_Id, 
	     Usuario_Login = b.Usuario_Login
    FROM Usuario             a
	     JOIN #TabParametros b ON a.Usuario_Id = b.Usuario_Id
END