CREATE PROCEDURE spuFuncionario
  @Funcionario_Id			INT,
  @Funcionario_Nome			VARCHAR(255),
  @Funcionario_CPF			VARCHAR(14),
  @Funcionario_RG			VARCHAR(12),
  @Funcionario_DtNascimento DATETIME,
  @Funcionario_Celular      VARCHAR(20),
  @Funcionario_Telefone     VARCHAR(20),
  @Funcionario_Email        VARCHAR(300),
  @Cargo_Id					INT,
  @Funcionario_DtAdmissao   DATE,
  @Estabelecimento_Id       INT,
  @Endereco_Id              INT,
  @Endereco_Numero          VARCHAR(10),
  @Endereco_Logradouro      VARCHAR(50),  
  @Endereco_Bairro          VARCHAR(50),
  @Endereco_Complemento     VARCHAR(255),
  @Endereco_Cidade          VARCHAR(100),
  @Endereco_Estado          CHAR(2),
  @Endereco_CEP             VARCHAR(20),
  @Usuario_Id               INT
AS
BEGIN
  SELECT @Funcionario_Id				  AS Funcionario_Id,
		 @Funcionario_Nome				  AS Funcionario_Nome,
		 @Funcionario_CPF				  AS Funcionario_CPF,
		 @Funcionario_RG				  AS Funcionario_RG,
		 @Funcionario_DtNascimento		  AS Funcionario_DtNascimento,
		 @Funcionario_Celular			  AS Funcionario_Celular,
		 @Funcionario_Telefone			  AS Funcionario_Telefone,
		 @Funcionario_Email				  AS Funcionario_Email,
		 @Cargo_Id						  AS Cargo_Id,
		 @Funcionario_DtAdmissao          AS Funcionario_DtAdmissao,
		 @Estabelecimento_Id			  AS Estabelecimento_Id,
		 @Endereco_Id					  AS Endereco_Id,
		 @Endereco_Numero                 AS Endereco_Numero,
		 @Endereco_Logradouro             AS Endereco_Logradouro,         
         @Endereco_Bairro                 AS Endereco_Bairro,
         ISNULL(@Endereco_Complemento,'') AS Endereco_Complemento,
         @Endereco_Cidade                 AS Endereco_Cidade,
         @Endereco_Estado                 AS Endereco_Estado,
         @Endereco_CEP                    AS Endereco_CEP,
		 @Usuario_Id                      AS Usuario_Id
    INTO #TabParametros
 
  UPDATE Funcionario
     SET Funcionario_Nome         = b.Funcionario_Nome,
	     Funcionario_CPF          = b.Funcionario_CPF,
		 Funcionario_RG           = b.Funcionario_RG,
		 Funcionario_DtNascimento = b.Funcionario_DtNascimento,
		 Funcionario_Telefone     = b.Funcionario_Telefone,
		 Funcionario_Celular      = b.Funcionario_Celular,
		 Funcionario_Email        = b.Funcionario_Email
    FROM Funcionario         a
	     JOIN #TabParametros b ON a.Funcionario_Id = b.Funcionario_Id
 
  UPDATE FuncionarioCargo
     SET Cargo_Id					 = b.Cargo_Id,
	     FuncionarioCargo_DtAdmissao = b.Funcionario_DtAdmissao
    FROM FuncionarioCargo    a
	     JOIN #TabParametros b ON a.Funcionario_Id = b.Funcionario_Id 
 
  UPDATE a
     SET FuncionarioEndereco_Logradouro  = b.Endereco_Logradouro,
	     FuncionarioEndereco_Numero      = b.Endereco_Numero,
		 FuncionarioEndereco_Bairro      = b.Endereco_Bairro,
		 FuncionarioEndereco_Cidade      = b.Endereco_Cidade,
		 FuncionarioEndereco_Estado      = b.Endereco_Estado,
		 FuncionarioEndereco_Complemento = b.Endereco_Complemento,
		 FuncionarioEndereco_CEP         = b.Endereco_CEP
	FROM FuncionarioEndereco a
	     JOIN #TabParametros b ON a.FuncionarioEndereco_Id = b.Endereco_Id
 
  DELETE FuncionarioEstabelecimento
    FROM FuncionarioEstabelecimento a
	     JOIN #TabParametros        b ON a.Funcionario_Id = b.Funcionario_Id
   WHERE a.Estabelecimento_Id <> b.Estabelecimento_Id
 
  INSERT INTO FuncionarioEstabelecimento(Funcionario_Id, Estabelecimento_Id)
  SELECT a.Funcionario_Id, a.Estabelecimento_Id
    FROM #TabParametros                       a
	     LEFT JOIN FuncionarioEstabelecimento b ON a.Funcionario_Id     = b.Funcionario_Id
		                                       AND a.Estabelecimento_Id = b.Estabelecimento_Id
   WHERE a.Estabelecimento_Id IS NOT NULL
     AND (b.Funcionario_Id IS NULL AND b.Estabelecimento_Id IS NULL)
 
  DELETE UsuarioFuncionario
    FROM UsuarioFuncionario  a
	     JOIN #TabParametros b ON a.Funcionario_Id = b.Funcionario_Id
   WHERE a.Usuario_Id <> b.Usuario_Id
 
  INSERT INTO UsuarioFuncionario(Usuario_Id, Funcionario_Id)
  SELECT a.Usuario_Id, a.Funcionario_Id
   FROM #TabParametros                a
	     LEFT JOIN UsuarioFuncionario b ON a.Funcionario_Id = b.Funcionario_Id
   WHERE a.Usuario_Id IS NOT NULL
     AND b.Funcionario_Id IS NULL
END