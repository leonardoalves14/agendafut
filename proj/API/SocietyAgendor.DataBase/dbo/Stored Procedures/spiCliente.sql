CREATE PROCEDURE spiCliente
  @Cliente_Id           INT OUTPUT,
  @Cliente_Nome         VARCHAR(255),
  @Cliente_CPF          VARCHAR(14),
  @Cliente_RG           VARCHAR(12),
  @Cliente_Email        VARCHAR(300),
  @Cliente_DtNascimento DATE,
  @Cliente_Telefone     VARCHAR(20),
  @Cliente_Celular      VARCHAR(20),
  @Endereco_Id          INT OUTPUT,
  @Endereco_Numero      VARCHAR(10),
  @Endereco_Logradouro  VARCHAR(100),  
  @Endereco_Bairro      VARCHAR(50),
  @Endereco_Complemento VARCHAR(255),
  @Endereco_Cidade      VARCHAR(100),
  @Endereco_Estado      CHAR(2),
  @Endereco_CEP         VARCHAR(20)
AS
BEGIN
  SELECT (SELECT ISNULL(MAX(Cliente_Id), 0) + 1 FROM Cliente)                 AS Cliente_Id,
         @Cliente_Nome                                                        AS Cliente_Nome,
         @Cliente_CPF                                                         AS Cliente_CPF,
         @Cliente_RG                                                          AS Cliente_RG,
         @Cliente_Email                                                       AS Cliente_Email,
         @Cliente_DtNascimento                                                AS Cliente_DtNascimento,
         @Cliente_Telefone                                                    AS Cliente_Telefone,
         @Cliente_Celular                                                     AS Cliente_Celular,
         (SELECT ISNULL(MAX(ClienteEndereco_Id), 0) + 1 FROM ClienteEndereco) AS Endereco_Id,
         @Endereco_Numero                                                     AS Endereco_Numero,
		 @Endereco_Logradouro                                                 AS Endereco_Logradouro,         
         @Endereco_Bairro                                                     AS Endereco_Bairro,
         ISNULL(@Endereco_Complemento,'')                                     AS Endereco_Complemento,
         @Endereco_Cidade                                                     AS Endereco_Cidade,
         @Endereco_Estado                                                     AS Endereco_Estado,
         @Endereco_CEP                                                        AS Endereco_CEP
    INTO #TabParametros
 
  INSERT INTO ClienteEndereco(ClienteEndereco_Id, ClienteEndereco_Logradouro, ClienteEndereco_Numero, ClienteEndereco_Bairro,
                              ClienteEndereco_Cidade, ClienteEndereco_Estado, ClienteEndereco_Complemento, ClienteEndereco_CEP)
  SELECT a.Endereco_Id, a.Endereco_Logradouro, a.Endereco_Numero, a.Endereco_Bairro,
         a.Endereco_Cidade, a.Endereco_Estado, a.Endereco_Complemento, a.Endereco_CEP
    FROM #TabParametros a
 
  INSERT INTO Cliente(Cliente_Id, Cliente_Nome, Cliente_CPF, Cliente_RG, Cliente_Email,
                      Cliente_DtNascimento, Cliente_Telefone, Cliente_Celular, ClienteEndereco_Id)
  SELECT a.Cliente_Id, a.Cliente_Nome, a.Cliente_CPF, a.Cliente_RG, a.Cliente_Email,
         a.Cliente_DtNascimento, a.Cliente_Telefone, a.Cliente_Celular, a.Endereco_Id
    FROM #TabParametros a
 
  SELECT @Cliente_Id  = a.Cliente_Id,
         @Endereco_Id = a.Endereco_Id
    FROM #TabParametros a
END