CREATE TABLE [dbo].[FuncionarioEndereco] (
    [FuncionarioEndereco_Id]          INT           NOT NULL,
    [FuncionarioEndereco_Logradouro]  VARCHAR (100) NOT NULL,
    [FuncionarioEndereco_Numero]      VARCHAR (10)  NOT NULL,
    [FuncionarioEndereco_Bairro]      VARCHAR (50)  NOT NULL,
    [FuncionarioEndereco_Cidade]      VARCHAR (100) NOT NULL,
    [FuncionarioEndereco_Estado]      CHAR (2)      NOT NULL,
    [FuncionarioEndereco_Complemento] VARCHAR (255) NOT NULL,
    [FuncionarioEndereco_CEP]         VARCHAR (20)  NOT NULL,
    CONSTRAINT [PK_FuncionarioEndereco] PRIMARY KEY CLUSTERED ([FuncionarioEndereco_Id] ASC)
);

