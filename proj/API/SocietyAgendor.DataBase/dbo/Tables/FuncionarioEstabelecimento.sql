CREATE TABLE [dbo].[FuncionarioEstabelecimento] (
    [Funcionario_Id]     INT NOT NULL,
    [Estabelecimento_Id] INT NOT NULL,
    CONSTRAINT [PK_FuncionarioEstabelecimento] PRIMARY KEY CLUSTERED ([Funcionario_Id] ASC, [Estabelecimento_Id] ASC),
    CONSTRAINT [FK_FuncionarioEstabelecimento_Estabelecimento] FOREIGN KEY ([Estabelecimento_Id]) REFERENCES [dbo].[Estabelecimento] ([Estabelecimento_Id]),
    CONSTRAINT [FK_FuncionarioEstabelecimento_Funcionario] FOREIGN KEY ([Funcionario_Id]) REFERENCES [dbo].[Funcionario] ([Funcionario_Id])
);

