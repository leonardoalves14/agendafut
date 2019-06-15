CREATE PROCEDURE spsValidaLogin  
  @Usuario_Login VARCHAR(50),  
  @Usuario_Senha VARCHAR(200)  
AS  
BEGIN  
  SELECT @Usuario_Login AS Usuario_Login,  
         @Usuario_Senha AS Usuario_Senha  
    INTO #TabParametros  
   
  SELECT COUNT(*) AS ExisteLogin  
    INTO #Login  
    FROM Usuario             a  
         JOIN #TabParametros b ON a.Usuario_Login = b.Usuario_Login  
   
  SELECT a.Usuario_Id AS UsuarioId
    FROM Usuario             a  
         JOIN #TabParametros b ON a.Usuario_Login = b.Usuario_Login  
                              AND a.Usuario_Senha = b.Usuario_Senha  
         CROSS JOIN #Login   c  
   WHERE c.ExisteLogin > 0  
END