CREATE PROCEDURE spuCliente
  @Cliente_Id           INT,
  @Cliente_Nome         VARCHAR(255),
  @Cliente_CPF          VARCHAR(14),
  @Cliente_RG           VARCHAR(12),
  @Cliente_Email        VARCHAR(300),
  @Cliente_DtNascimento DATE,
  @Cliente_Telefone     VARCHAR(20),
  @Cliente_Celular      VARCHAR(20),
  @Endereco_Id          INT,
  @Endereco_Numero      VARCHAR(10),
  @Endereco_Logradouro  VARCHAR(100),  
  @Endereco_Bairro      VARCHAR(50),
  @Endereco_Complemento VARCHAR(255),
  @Endereco_Cidade      VARCHAR(100),
  @Endereco_Estado      CHAR(2),
  @Endereco_CEP         VARCHAR(20)
AS
BEGIN
  SELECT @Cliente_Id                      AS Cliente_Id,
         @Cliente_Nome                    AS Cliente_Nome,		 
         @Cliente_CPF                     AS Cliente_CPF,
         @Cliente_RG                      AS Cliente_RG,
         @Cliente_Email                   AS Cliente_Email,
         @Cliente_DtNascimento            AS Cliente_DtNascimento,
         @Cliente_Telefone                AS Cliente_Telefone,
         @Cliente_Celular                 AS Cliente_Celular,
         @Endereco_Id                     AS Endereco_Id,
         @Endereco_Numero                 AS Endereco_Numero,
		 @Endereco_Logradouro             AS Endereco_Logradouro,         
         @Endereco_Bairro                 AS Endereco_Bairro,
         ISNULL(@Endereco_Complemento,'') AS Endereco_Complemento,
         @Endereco_Cidade                 AS Endereco_Cidade,
         @Endereco_Estado                 AS Endereco_Estado,
         @Endereco_CEP                    AS Endereco_CEP
    INTO #TabParametros
 
  UPDATE Cliente
     SET Cliente_Nome         = b.Cliente_Nome,
	     Cliente_CPF          = b.Cliente_CPF,
		 Cliente_RG           = b.Cliente_RG,
		 Cliente_Email        = b.Cliente_Email,
		 Cliente_DtNascimento = b.Cliente_DtNascimento,
		 Cliente_Telefone     = b.Cliente_Telefone,
		 Cliente_Celular      = b.Cliente_Celular
	FROM Cliente             a
	     JOIN #TabParametros b ON a.Cliente_Id = b.Cliente_Id 
 
  UPDATE a
     SET ClienteEndereco_Logradouro  = b.Endereco_Logradouro,
	     ClienteEndereco_Numero      = b.Endereco_Numero,
		 ClienteEndereco_Cidade      = b.Endereco_Cidade,
		 ClienteEndereco_Estado      = b.Endereco_Estado,
		 ClienteEndereco_Complemento = b.Endereco_Complemento,
		 ClienteEndereco_CEP         = b.Endereco_CEP
    FROM ClienteEndereco     a
	     JOIN #TabParametros b ON a.ClienteEndereco_Id = b.Endereco_Id
END