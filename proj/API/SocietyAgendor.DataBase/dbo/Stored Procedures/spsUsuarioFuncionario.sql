CREATE PROCEDURE spsUsuarioFuncionario
  @Usuario_Id INT
AS
BEGIN
--drop table #Result
  SELECT CAST(NULL AS VARCHAR(50))  AS Usuario_Login,
         CAST(NULL AS INT)          AS Funcionario_Id,
	     CAST(NULL AS VARCHAR(255)) AS Funcionario_Nome,
	     CAST(NULL AS VARCHAR(300)) AS Funcionario_Email,
	     CAST(NULL AS VARCHAR(13))  AS Funcionario_CPF,
	     CAST(NULL AS VARCHAR(14))  AS Funcionario_RG,
	     CAST(NULL AS DATE)         AS Funcionario_DtNascimento,
	     CAST(NULL AS VARCHAR(255)) AS Cargo_Desc,
	     CAST(NULL AS VARCHAR(200)) AS Estabelecimento_Nome
    INTO #Result
   WHERE 1 = 0

  --drop table #TabParametros
  SELECT @Usuario_Id AS Usuario_Id
    INTO #TabParametros
 
  --drop table #Usuario
  SELECT a.Usuario_Id, a.Usuario_Login
    INTO #Usuario
    FROM Usuario             a
         JOIN #TabParametros b ON a.Usuario_Id = b.Usuario_Id
 
  INSERT INTO #Result (Usuario_Login, Funcionario_Id, Funcionario_Nome, Funcionario_Email,
                       Funcionario_CPF, Funcionario_RG, Funcionario_DtNascimento)
  SELECT a.Usuario_Login, c.Funcionario_Id, c.Funcionario_Nome, c.Funcionario_Email,
         c.Funcionario_CPF, c.Funcionario_RG, c.Funcionario_DtNascimento
    FROM #Usuario                 a
         JOIN UsuarioFuncionario  b ON a.Usuario_Id     = b.Usuario_Id
	     JOIN Funcionario         c ON b.Funcionario_Id = c.Funcionario_Id
 
  UPDATE #Result
     SET Cargo_Desc = c.Cargo_Desc
    FROM #Result               a
         JOIN FuncionarioCargo b ON a.Funcionario_Id = b.Funcionario_Id
	     JOIN Cargo            c ON b.Cargo_Id       = c.Cargo_Id
 
  UPDATE #Result
     SET Estabelecimento_Nome = c.Estabelecimento_Nome
    FROM #Result                         a
         JOIN FuncionarioEstabelecimento b ON a.Funcionario_Id     = b.Funcionario_Id
	     JOIN Estabelecimento            c ON b.Estabelecimento_Id = c.Estabelecimento_Id
 
  SELECT a.Usuario_Login as UsuarioLogin, 
         a.Funcionario_Nome as FuncionarioNome, 
	     a.Funcionario_Email as FuncionarioEmail,
	     a.Funcionario_CPF as FuncionarioCPF,
	     a.Funcionario_RG as FuncionarioRG,
	     a.Funcionario_DtNascimento as FuncionarioDtNascimento,
	     a.Estabelecimento_Nome as EstabelecimentoNome, 
	     a.Cargo_Desc as CargoDesc
    FROM #Result a
END