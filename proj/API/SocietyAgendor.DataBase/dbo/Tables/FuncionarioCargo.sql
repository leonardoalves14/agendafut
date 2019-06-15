CREATE TABLE [dbo].[FuncionarioCargo] (
    [Funcionario_Id]              INT  NOT NULL,
    [Cargo_Id]                    INT  NOT NULL,
    [FuncionarioCargo_DtAdmissao] DATE NOT NULL,
    CONSTRAINT [PK_FuncionarioCargo] PRIMARY KEY CLUSTERED ([Funcionario_Id] ASC, [Cargo_Id] ASC),
    CONSTRAINT [FK_FuncionarioCargo_Cargo] FOREIGN KEY ([Cargo_Id]) REFERENCES [dbo].[Cargo] ([Cargo_Id]),
    CONSTRAINT [FK_FuncionarioCargo_Funcionario] FOREIGN KEY ([Funcionario_Id]) REFERENCES [dbo].[Funcionario] ([Funcionario_Id])
);

