CREATE PROCEDURE spsCliente
AS
BEGIN
  SELECT a.Cliente_Id,
	     a.Cliente_Nome,
		 a.Cliente_CPF,
		 a.Cliente_RG,
		 a.Cliente_Email,
		 a.Cliente_DtNascimento,
		 a.Cliente_Telefone,
		 a.Cliente_Celular,
		 a.ClienteEndereco_Id	       AS Endereco_Id,
		 b.ClienteEndereco_Logradouro  AS Endereco_Logradouro,
		 b.ClienteEndereco_Numero      AS Endereco_Numero,
		 b.ClienteEndereco_Bairro      AS Endereco_Bairro,
		 b.ClienteEndereco_Cidade      AS Endereco_Cidade,
		 b.ClienteEndereco_Estado      AS Endereco_Estado,
		 b.ClienteEndereco_Complemento AS Endereco_Complemento,
		 b.ClienteEndereco_CEP         AS Endereco_CEP
    FROM Cliente               a
	     JOIN ClienteEndereco  b ON a.ClienteEndereco_Id = b.ClienteEndereco_Id
   ORDER BY a.Cliente_Nome ASC
END