CREATE PROCEDURE spsEstabelecimento
AS
BEGIN
  SELECT a.Estabelecimento_Id,
         a.Estabelecimento_Nome,
		 a.Estabelecimento_CNPJ,
		 a.EstabelecimentoEndereco_Id           AS Endereco_Id,
		 b.EstabelecimentoEndereco_Logradouro   AS Endereco_Logradouro,
		 b.EstabelecimentoEndereco_Numero       AS Endereco_Numero,
		 b.EstabelecimentoEndereco_Bairro       AS Endereco_Bairro,
		 b.EstabelecimentoEndereco_Complemento  AS Endereco_Complemento,
		 b.EstabelecimentoEndereco_CEP          AS Endereco_CEP,
		 b.EstabelecimentoEndereco_Cidade       AS Endereco_Cidade,
		 b.EstabelecimentoEndereco_Estado       AS Endereco_Estado,
		 a.Estabelecimento_Celular,
		 a.Estabelecimento_Email,
		 a.Estabelecimento_Telefone
    FROM Estabelecimento              a
	     JOIN EstabelecimentoEndereco b ON a.EstabelecimentoEndereco_Id = b.EstabelecimentoEndereco_Id
END