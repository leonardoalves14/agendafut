CREATE TABLE [dbo].[Cliente] (
    [Cliente_Id]           INT           NOT NULL,
    [Cliente_Nome]         VARCHAR (255) NOT NULL,
    [Cliente_CPF]          VARCHAR (14)  NULL,
    [Cliente_RG]           VARCHAR (12)  NULL,
    [Cliente_DtNascimento] DATE          NOT NULL,
    [Cliente_Telefone]     VARCHAR (20)  NOT NULL,
    [Cliente_Celular]      VARCHAR (20)  NOT NULL,
    [Cliente_Email]        VARCHAR (300) NOT NULL,
    [ClienteEndereco_Id]   INT           NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED ([Cliente_Id] ASC),
    CONSTRAINT [FK_Cliente_ClienteEndereco] FOREIGN KEY ([ClienteEndereco_Id]) REFERENCES [dbo].[ClienteEndereco] ([ClienteEndereco_Id])
);

