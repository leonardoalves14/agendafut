CREATE PROCEDURE reset_user_password
  @Usuario_Id INT
AS
BEGIN
  SELECT @Usuario_Id AS Usuario_Id
    INTO #TabParametros
 
  UPDATE Usuario
     SET Usuario_Senha = '1234567'
    FROM Usuario             a
	     JOIN #TabParametros b ON a.Usuario_Id= b.Usuario_Id
END