CREATE PROCEDURE spiEstabelecimento
  @Estabelecimento_Id       INT OUTPUT,
  @Estabelecimento_Nome     VARCHAR(200),
  @Estabelecimento_CNPJ     VARCHAR(18),
  @Endereco_Id              INT OUTPUT,
  @Endereco_Numero          VARCHAR(10),
  @Endereco_Logradouro      VARCHAR(100),  
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
  SELECT (SELECT ISNULL(MAX(Estabelecimento_Id),0) + 1 FROM Estabelecimento)                  AS Estabelecimento_Id,
         @Estabelecimento_Nome                                                                AS Estabelecimento_Nome,
		 @Estabelecimento_CNPJ                                                                AS Estabelecimento_CNPJ,
		 (SELECT ISNULL(MAX(EstabelecimentoEndereco_Id),0) + 1 FROM EstabelecimentoEndereco)  AS Endereco_Id,
		 @Endereco_Numero                                                                     AS Endereco_Numero,
		 @Endereco_Logradouro                                                                 AS Endereco_Logradouro,		 
		 @Endereco_Bairro                                                                     AS Endereco_Bairro,
		 ISNULL(@Endereco_Complemento,'')                                                     AS Endereco_Complemento,
		 @Endereco_CEP                                                                        AS Endereco_CEP,
		 @Endereco_Cidade                                                                     AS Endereco_Cidade,
		 @Endereco_Estado                                                                     AS Endereco_Estado,
		 @Estabelecimento_Celular                                                             AS Celular,
		 @Estabelecimento_Email                                                               AS Email,
		 @Estabelecimento_Telefone                                                            AS Telefone
    INTO #TabParametros
 
  INSERT INTO EstabelecimentoEndereco(EstabelecimentoEndereco_Id, EstabelecimentoEndereco_Logradouro, EstabelecimentoEndereco_Numero, EstabelecimentoEndereco_Bairro,
                                      EstabelecimentoEndereco_Cidade, EstabelecimentoEndereco_Estado, EstabelecimentoEndereco_Complemento, EstabelecimentoEndereco_CEP)
  SELECT a.Endereco_Id, a.Endereco_Logradouro, a.Endereco_Numero, a.Endereco_Bairro,
         a.Endereco_Cidade, a.Endereco_Estado, a.Endereco_Complemento, a.Endereco_CEP
    FROM #TabParametros a
 
  INSERT INTO Estabelecimento(Estabelecimento_Id, Estabelecimento_Nome, Estabelecimento_CNPJ, Estabelecimento_Telefone,
                              Estabelecimento_Celular, Estabelecimento_Email, EstabelecimentoEndereco_Id)
  SELECT a.Estabelecimento_Id, a.Estabelecimento_Nome, a.Estabelecimento_CNPJ, a.Telefone, a.Celular, a.Email, a.Endereco_Id
    FROM #TabParametros a
 
  SELECT @Estabelecimento_Id = a.Estabelecimento_Id,
         @Endereco_Id        = a.Endereco_Id
    FROM #TabParametros a
END