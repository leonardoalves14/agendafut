CREATE PROCEDURE spiFuncionario  
  @Funcionario_Id           INT OUTPUT,  
  @Funcionario_Nome         VARCHAR(255),  
  @Funcionario_CPF          VARCHAR(14),  
  @Funcionario_RG           VARCHAR(12),  
  @Funcionario_DtNascimento DATE,  
  @Funcionario_Celular      VARCHAR(20),  
  @Funcionario_Telefone     VARCHAR(20),  
  @Funcionario_Email        VARCHAR(300),  
  @Cargo_Id                 INT,  
  @Funcionario_DtAdmissao   DATE,  
  @Estabelecimento_Id       INT,  
  @Endereco_Id              INT OUTPUT,  
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
  SELECT (SELECT ISNULL(MAX(Funcionario_Id),0) + 1 FROM Funcionario)                 AS Funcionario_Id,  
         (SELECT ISNULL(MAX(FuncionarioEndereco_Id),0) + 1 FROM FuncionarioEndereco) AS Endereco_Id,  
         @Funcionario_Nome                                                           AS Funcionario_Nome,  
         @Funcionario_CPF                                                            AS Funcionario_CPF,  
         @Funcionario_RG                                                             AS Funcionario_RG,  
         @Funcionario_DtNascimento                                                   AS Funcionario_DtNascimento,  
         @Funcionario_Celular                                                        AS Funcionario_Celular,  
         @Funcionario_Telefone                                                       AS Funcionario_Telefone,  
         @Funcionario_Email                                                          AS Funcionario_Email,  
         @Cargo_Id                                                                   AS Cargo_Id,  
         @Funcionario_DtAdmissao                                                     AS Funcionario_DtAdmissao,  
         @Estabelecimento_Id                                                         AS Estabelecimento_Id,  
         @Endereco_Numero                                                            AS Endereco_Numero,  
         @Endereco_Logradouro                                                        AS Endereco_Logradouro,  
         @Endereco_Bairro                                                            AS Endereco_Bairro,  
         ISNULL(@Endereco_Complemento,'')                                            AS Endereco_Complemento,  
         @Endereco_Cidade                                                            AS Endereco_Cidade,  
         @Endereco_Estado                                                            AS Endereco_Estado,  
         @Endereco_CEP                                                               AS Endereco_CEP,  
         @Usuario_Id                                                                 AS Usuario_Id  
    INTO #TabParametros  
   
  INSERT INTO FuncionarioEndereco(FuncionarioEndereco_Id, FuncionarioEndereco_Logradouro, FuncionarioEndereco_Numero,  
                                  FuncionarioEndereco_Bairro, FuncionarioEndereco_Cidade, FuncionarioEndereco_Estado,  
                                  FuncionarioEndereco_Complemento, FuncionarioEndereco_CEP)  
  SELECT a.Endereco_Id, a.Endereco_Logradouro, a.Endereco_Numero, a.Endereco_Bairro,  
         a.Endereco_Cidade, a.Endereco_Estado, a.Endereco_Complemento, a.Endereco_CEP  
    FROM #TabParametros a  
   
  INSERT INTO Funcionario(Funcionario_Id, Funcionario_Nome, Funcionario_CPF, Funcionario_RG, Funcionario_DtNascimento,  
                          Funcionario_Telefone, Funcionario_Celular, Funcionario_Email, FuncionarioEndereco_Id)  
  SELECT a.Funcionario_Id, a.Funcionario_Nome, a.Funcionario_CPF, a.Funcionario_RG, a.Funcionario_DtNascimento,  
        a.Funcionario_Telefone, a.Funcionario_Celular, a.Funcionario_Email, a.Endereco_Id  
    FROM #TabParametros a  
   
  INSERT INTO FuncionarioCargo(Funcionario_Id, FuncionarioCargo_DtAdmissao, Cargo_Id)  
  SELECT a.Funcionario_Id, a.Funcionario_DtAdmissao, a.Cargo_Id  
    FROM #TabParametros a  
   
  INSERT INTO FuncionarioEstabelecimento(Funcionario_Id, Estabelecimento_Id)  
  SELECT a.Funcionario_Id, a.Estabelecimento_Id  
    FROM #TabParametros a  
   
  INSERT INTO UsuarioFuncionario(Usuario_Id, Funcionario_Id)  
  SELECT a.Usuario_Id, a.Funcionario_Id  
    FROM #TabParametros a  
   
  SELECT @Funcionario_Id = a.Funcionario_Id,  
         @Endereco_Id    = a.Endereco_Id  
    FROM #TabParametros a  
END