CREATE PROCEDURE spuEstabelecimento
  @Estabelecimento_Id       INT,
  @Estabelecimento_Nome     VARCHAR(200),
  @Estabelecimento_CNPJ     VARCHAR(18),
  @Endereco_Id              INT,
  @Endereco_Numero          VARCHAR(10),
  @Endereco_Logradouro      VARCHAR(50),  
  @Endereco_Bairro          VARCHAR(50),
  @Endereco_Complemento     VARCHAR(255),
  @Endereco_Cidade          VARCHAR(100),
  @Endereco_Estado          CHAR(2),
  @Endereco_CEP             VARCHAR(20),
  @Estabelecimento_Celular  VARCHAR(20),
  @Estabelecimento_Email    VARCHAR(300),
  @Estabelecimento_Telefone VARCHAR(20)
AS
BEGIN
  SELECT @Estabelecimento_Id              AS Estabelecimento_Id,
         @Estabelecimento_Nome            AS Estabelecimento_Nome,
		 @Estabelecimento_CNPJ            AS Estabelecimento_CNPJ,
		 @Endereco_Id                     AS Endereco_Id,
		 @Endereco_Numero                 AS Endereco_Numero,
		 @Endereco_Logradouro             AS Endereco_Logradouro,		 
		 @Endereco_Bairro                 AS Endereco_Bairro,
		 ISNULL(@Endereco_Complemento,'') AS Endereco_Complemento,
		 @Endereco_CEP                    AS Endereco_CEP,
		 @Endereco_Cidade                 AS Endereco_Cidade,
		 @Endereco_Estado                 AS Endereco_Estado,
		 @Estabelecimento_Celular         AS Estabelecimento_Celular,
		 @Estabelecimento_Email           AS Estabelecimento_Email,
		 @Estabelecimento_Telefone        AS Estabelecimento_Telefone
    INTO #TabParametros
 
  UPDATE Estabelecimento
     SET Estabelecimento_Nome     = b.Estabelecimento_Nome,
	     Estabelecimento_CNPJ     = b.Estabelecimento_CNPJ,
		 Estabelecimento_Telefone = b.Estabelecimento_Telefone,
		 Estabelecimento_Celular  = b.Estabelecimento_Celular,
		 Estabelecimento_Email    = b.Estabelecimento_Email
	FROM Estabelecimento     a
	     JOIN #TabParametros b ON a.Estabelecimento_Id = b.Estabelecimento_Id
 
  UPDATE a
     SET EstabelecimentoEndereco_Logradouro  = b.Endereco_Logradouro,
	     EstabelecimentoEndereco_Numero      = b.Endereco_Numero,
		 EstabelecimentoEndereco_Bairro      = b.Endereco_Bairro,
		 EstabelecimentoEndereco_Cidade      = b.Endereco_Cidade,
		 EstabelecimentoEndereco_Estado      = b.Endereco_Estado,
		 EstabelecimentoEndereco_Complemento = b.Endereco_Complemento,
		 EstabelecimentoEndereco_CEP         = b.Endereco_CEP
    FROM EstabelecimentoEndereco a
	     JOIN #TabParametros     b ON a.EstabelecimentoEndereco_Id = b.Endereco_Id
END