CREATE TABLE [dbo].[ClienteEndereco] (
    [ClienteEndereco_Id]          INT           NOT NULL,
    [ClienteEndereco_Logradouro]  VARCHAR (100) NOT NULL,
    [ClienteEndereco_Numero]      VARCHAR (10)  NOT NULL,
    [ClienteEndereco_Bairro]      VARCHAR (50)  NOT NULL,
    [ClienteEndereco_Cidade]      VARCHAR (100) NOT NULL,
    [ClienteEndereco_Estado]      CHAR (2)      NOT NULL,
    [ClienteEndereco_Complemento] VARCHAR (255) NOT NULL,
    [ClienteEndereco_CEP]         VARCHAR (20)  NOT NULL,
    CONSTRAINT [PK_ClienteEndereco] PRIMARY KEY CLUSTERED ([ClienteEndereco_Id] ASC)
);

