CREATE PROCEDURE spsUsuario
AS
BEGIN
  SELECT a.Usuario_Id    AS UsuarioId,
         a.Usuario_Login AS UsuarioLogin
    FROM Usuario a
   ORDER BY a.Usuario_Login ASC
END