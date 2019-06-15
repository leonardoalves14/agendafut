CREATE TABLE [dbo].[AgendaEstabelecimento] (
    [Agendamento_Id]     INT NOT NULL,
    [Estabelecimento_Id] INT NOT NULL,
    CONSTRAINT [PK_AgendaEstabelecimento] PRIMARY KEY CLUSTERED ([Agendamento_Id] ASC, [Estabelecimento_Id] ASC),
    CONSTRAINT [FK_AgendaEstabelecimento_Agendamento] FOREIGN KEY ([Agendamento_Id]) REFERENCES [dbo].[Agendamento] ([Agendamento_Id]),
    CONSTRAINT [FK_AgendaEstabelecimento_Estabelecimento] FOREIGN KEY ([Estabelecimento_Id]) REFERENCES [dbo].[Estabelecimento] ([Estabelecimento_Id])
);

