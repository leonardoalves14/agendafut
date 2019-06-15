CREATE TABLE [dbo].[Estabelecimento] (
    [Estabelecimento_Id]         INT           NOT NULL,
    [Estabelecimento_Nome]       VARCHAR (200) NOT NULL,
    [Estabelecimento_CNPJ]       VARCHAR (18)  NULL,
    [Estabelecimento_Telefone]   VARCHAR (20)  NOT NULL,
    [Estabelecimento_Celular]    VARCHAR (20)  NOT NULL,
    [Estabelecimento_Email]      VARCHAR (300) NOT NULL,
    [EstabelecimentoEndereco_Id] INT           NOT NULL,
    CONSTRAINT [PK_Estabelecimento] PRIMARY KEY CLUSTERED ([Estabelecimento_Id] ASC),
    CONSTRAINT [FK_Estabelecimento_EstabelecimentoEndereco] FOREIGN KEY ([EstabelecimentoEndereco_Id]) REFERENCES [dbo].[EstabelecimentoEndereco] ([EstabelecimentoEndereco_Id])
);

