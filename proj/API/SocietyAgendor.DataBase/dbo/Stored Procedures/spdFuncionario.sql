CREATE PROCEDURE spdFuncionario
  @Funcionario_Id INT
AS
BEGIN
  SELECT @Funcionario_Id                           AS Funcionario_Id,
         (SELECT FuncionarioEndereco_Id FROM Funcionario 
		   WHERE Funcionario_Id = @Funcionario_Id) AS FuncionarioEndereco_Id
    INTO #TabParametros
 
  DELETE UsuarioFuncionario
    FROM UsuarioFuncionario  a
	     JOIN #TabParametros b ON a.Funcionario_Id = b.Funcionario_Id
 
  DELETE FuncionarioEstabelecimento
    FROM FuncionarioEstabelecimento a
	     JOIN #TabParametros        b ON a.Funcionario_Id = b.Funcionario_Id
 
  DELETE FuncionarioCargo
    FROM FuncionarioCargo    a
	     JOIN #TabParametros b ON a.Funcionario_Id = b.Funcionario_Id
 
  DELETE Funcionario
    FROM Funcionario         a
	     JOIN #TabParametros b ON a.Funcionario_Id = b.Funcionario_Id
 
  DELETE FuncionarioEndereco
    FROM FuncionarioEndereco a
	     JOIN #TabParametros b ON a.FuncionarioEndereco_Id = b.FuncionarioEndereco_Id
END