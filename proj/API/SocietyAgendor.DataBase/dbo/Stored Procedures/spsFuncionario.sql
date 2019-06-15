CREATE PROCEDURE spsFuncionario    
AS    
BEGIN    
  SELECT CAST(NULL AS INT)          AS Funcionario_Id,    
         CAST(NULL AS VARCHAR(255)) AS Funcionario_Nome,    
         CAST(NULL AS VARCHAR(13))  AS Funcionario_CPF,      
         CAST(NULL AS VARCHAR(14))  AS Funcionario_RG,      
         CAST(NULL AS DATE)         AS Funcionario_DtNascimento,      
         CAST(NULL AS VARCHAR(20))  AS Funcionario_Celular,      
         CAST(NULL AS VARCHAR(20))  AS Funcionario_Telefone,      
         CAST(NULL AS VARCHAR(300)) AS Funcionario_Email,      
         CAST(NULL AS DATE)         AS FuncionarioDtAdmissao,      
         CAST(NULL AS INT)          AS Endereco_Id,      
         CAST(NULL AS VARCHAR(10))  AS Endereco_Numero,      
         CAST(NULL AS VARCHAR(100)) AS Endereco_Logradouro,      
         CAST(NULL AS VARCHAR(50))  AS Endereco_Bairro,      
         CAST(NULL AS VARCHAR(100)) AS Endereco_Cidade,      
         CAST(NULL AS CHAR(2))      AS Endereco_Estado,      
         CAST(NULL AS VARCHAR(255)) AS Endereco_Complemento,      
         CAST(NULL AS VARCHAR(20))  AS Endereco_CEP,      
         CAST(NULL AS INT)          AS Cargo_Id,      
         CAST(NULL AS VARCHAR(255)) AS Cargo_Desc,      
         CAST(NULL AS INT)          AS Estabelecimento_Id,      
         CAST(NULL AS VARCHAR(200)) AS Estabelecimento_Nome,      
         CAST(NULL AS INT)          AS Usuario_Id,      
         CAST(NULL AS VARCHAR(50))  AS Usuario_Login      
    INTO #Resultado      
   WHERE 1 = 0    
     
  INSERT INTO #Resultado (Funcionario_Id, Funcionario_Nome, Funcionario_CPF, Funcionario_RG, Funcionario_DtNascimento,      
                          Funcionario_Celular, Funcionario_Telefone, Funcionario_Email, Endereco_Id)      
  SELECT a.Funcionario_Id, a.Funcionario_Nome, a.Funcionario_CPF, a.Funcionario_RG, a.Funcionario_DtNascimento,      
         a.Funcionario_Celular, a.Funcionario_Telefone, a.Funcionario_Email, a.FuncionarioEndereco_Id      
    FROM Funcionario a    
     
  UPDATE a      
     SET Endereco_Numero      = b.FuncionarioEndereco_Numero,      
         Endereco_Logradouro  = b.FuncionarioEndereco_Logradouro,      
         Endereco_Bairro      = b.FuncionarioEndereco_Bairro,      
         Endereco_Cidade      = b.FuncionarioEndereco_Cidade,      
         Endereco_Estado      = b.FuncionarioEndereco_Estado,      
         Endereco_Complemento = b.FuncionarioEndereco_Complemento,      
         Endereco_CEP         = b.FuncionarioEndereco_CEP      
    FROM #Resultado               a      
         JOIN FuncionarioEndereco b ON a.Endereco_Id = b.FuncionarioEndereco_Id    
     
  UPDATE #Resultado      
     SET Cargo_Id               = b.Cargo_Id,       
         Cargo_Desc             = c.Cargo_Desc,      
         FuncionarioDtAdmissao  = b.FuncionarioCargo_DtAdmissao      
    FROM #Resultado            a      
         JOIN FuncionarioCargo b ON a.Funcionario_Id = b.Funcionario_Id      
         JOIN Cargo            c ON b.Cargo_Id       = c.Cargo_Id    
     
  UPDATE a      
     SET Estabelecimento_Id   = b.Estabelecimento_Id,      
         Estabelecimento_Nome = c.Estabelecimento_Nome      
    FROM #Resultado                      a      
         JOIN FuncionarioEstabelecimento b ON a.Funcionario_Id     = b.Funcionario_Id      
         JOIN Estabelecimento            c ON b.Estabelecimento_Id = c.Estabelecimento_Id       
     
  UPDATE a      
     SET Usuario_Id    = b.Usuario_Id,      
         Usuario_Login = c.Usuario_Login      
    FROM #Resultado              a      
         JOIN UsuarioFuncionario b ON a.Funcionario_Id = b.Funcionario_Id      
         JOIN Usuario            c ON b.Usuario_Id     = c.Usuario_Id    
     
  SELECT a.*      
    FROM #Resultado a      
   ORDER BY a.Funcionario_Nome ASC      
END