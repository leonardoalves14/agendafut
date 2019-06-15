CREATE PROCEDURE spiUsuario
  @Usuario_Id    INT OUTPUT,
  @Usuario_Login VARCHAR(50)
AS
BEGIN
  SELECT (SELECT ISNULL(MAX(Usuario_Id),0) + 1 FROM Usuario) AS Usuario_Id,
         @Usuario_Login                                      AS Usuario_Login
    INTO #TabParametros
 
  INSERT INTO Usuario(Usuario_Id, Usuario_Login, Usuario_Senha)
  SELECT a.Usuario_Id, a.Usuario_Login, '1234567'
    FROM #TabParametros a
 
  SELECT @Usuario_Id = a.Usuario_Id
    FROM #TabParametros a
END