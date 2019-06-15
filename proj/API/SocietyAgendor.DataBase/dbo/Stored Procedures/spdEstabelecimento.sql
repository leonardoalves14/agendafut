CREATE PROCEDURE spdEstabelecimento
  @Estabelecimento_Id       INT  
AS
BEGIN
  SELECT @Estabelecimento_Id                               AS Estabelecimento_Id,
         (SELECT EstabelecimentoEndereco_Id 
		    FROM Estabelecimento 
		   WHERE Estabelecimento_Id = @Estabelecimento_Id) AS EstabelecimentoEndereco_Id
    INTO #TabParametros
 
  DELETE Estabelecimento
	FROM Estabelecimento     a
	     JOIN #TabParametros b ON a.Estabelecimento_Id = b.Estabelecimento_Id  
  
  DELETE EstabelecimentoEndereco
    FROM EstabelecimentoEndereco  a
	     JOIN #TabParametros      b ON a.EstabelecimentoEndereco_Id = b.EstabelecimentoEndereco_Id
END