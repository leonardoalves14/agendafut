CREATE TABLE [dbo].[UsuarioFuncionario] (
    [Usuario_Id]     INT NOT NULL,
    [Funcionario_Id] INT NOT NULL,
    CONSTRAINT [PK_UsuarioFuncionario] PRIMARY KEY CLUSTERED ([Usuario_Id] ASC, [Funcionario_Id] ASC),
    CONSTRAINT [FK_UsuarioFuncionario_Funcionario] FOREIGN KEY ([Funcionario_Id]) REFERENCES [dbo].[Funcionario] ([Funcionario_Id]),
    CONSTRAINT [FK_UsuarioFuncionario_Usuario] FOREIGN KEY ([Usuario_Id]) REFERENCES [dbo].[Usuario] ([Usuario_Id])
);

