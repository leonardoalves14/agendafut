CREATE TABLE [dbo].[AgendamentoCliente] (
    [Agendamento_Id] INT NOT NULL,
    [Cliente_Id]     INT NOT NULL,
    CONSTRAINT [PK_AgendamentoCliente] PRIMARY KEY CLUSTERED ([Agendamento_Id] ASC, [Cliente_Id] ASC),
    CONSTRAINT [FK_AgendamentoCliente_Agendamento] FOREIGN KEY ([Agendamento_Id]) REFERENCES [dbo].[Agendamento] ([Agendamento_Id]),
    CONSTRAINT [FK_AgendamentoCliente_Cliente] FOREIGN KEY ([Cliente_Id]) REFERENCES [dbo].[Cliente] ([Cliente_Id])
);

