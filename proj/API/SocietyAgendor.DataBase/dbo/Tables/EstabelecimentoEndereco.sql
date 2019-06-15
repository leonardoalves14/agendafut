CREATE TABLE [dbo].[EstabelecimentoEndereco] (
    [EstabelecimentoEndereco_Id]          INT           NOT NULL,
    [EstabelecimentoEndereco_Logradouro]  VARCHAR (100) NOT NULL,
    [EstabelecimentoEndereco_Numero]      VARCHAR (10)  NOT NULL,
    [EstabelecimentoEndereco_Bairro]      VARCHAR (50)  NOT NULL,
    [EstabelecimentoEndereco_Cidade]      VARCHAR (100) NOT NULL,
    [EstabelecimentoEndereco_Estado]      CHAR (2)      NOT NULL,
    [EstabelecimentoEndereco_Complemento] VARCHAR (255) NOT NULL,
    [EstabelecimentoEndereco_CEP]         VARCHAR (20)  NOT NULL,
    CONSTRAINT [PK_EstabelecimentoEndereco] PRIMARY KEY CLUSTERED ([EstabelecimentoEndereco_Id] ASC)
);

