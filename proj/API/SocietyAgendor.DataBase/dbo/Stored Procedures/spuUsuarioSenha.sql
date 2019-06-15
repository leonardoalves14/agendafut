CREATE PROCEDURE [spuUsuarioSenha]
  @Usuario_Id    INT,
  @Usuario_Senha VARCHAR(50)
AS
BEGIN
  SELECT @Usuario_Id    AS Usuario_Id,
         @Usuario_Senha AS Usuario_Senha
    INTO #TabParametros
 
  UPDATE Usuario
     SET Usuario_Senha = b.Usuario_Senha
	FROM Usuario             a
	     JOIN #TabParametros b ON a.Usuario_Id = b.Usuario_Id
END