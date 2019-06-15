CREATE TABLE [dbo].[Funcionario] (
    [Funcionario_Id]           INT           NOT NULL,
    [Funcionario_Nome]         VARCHAR (255) NOT NULL,
    [Funcionario_CPF]          VARCHAR (14)  NULL,
    [Funcionario_RG]           VARCHAR (12)  NULL,
    [Funcionario_DtNascimento] DATE          NOT NULL,
    [Funcionario_Telefone]     VARCHAR (20)  NOT NULL,
    [Funcionario_Celular]      VARCHAR (20)  NOT NULL,
    [Funcionario_Email]        VARCHAR (300) NOT NULL,
    [FuncionarioEndereco_Id]   INT           NOT NULL,
    CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED ([Funcionario_Id] ASC),
    CONSTRAINT [FK_Funcionario_FuncionarioEndereco] FOREIGN KEY ([FuncionarioEndereco_Id]) REFERENCES [dbo].[FuncionarioEndereco] ([FuncionarioEndereco_Id])
);

