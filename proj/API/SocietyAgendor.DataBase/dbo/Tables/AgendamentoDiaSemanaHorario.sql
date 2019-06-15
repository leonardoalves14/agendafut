CREATE TABLE [dbo].[AgendamentoDiaSemanaHorario] (
    [Agendamento_Id]                   INT      NOT NULL,
    [DiaSemana_Id]                     INT      NOT NULL,
    [Horario_Id]                       INT      NOT NULL,
    [AgendamentoDiaSemanaHorario_Data] DATETIME NOT NULL,
    CONSTRAINT [PK_AgendamentoDiaSemanaHorario] PRIMARY KEY CLUSTERED ([Agendamento_Id] ASC, [DiaSemana_Id] ASC, [Horario_Id] ASC),
    CONSTRAINT [FK_AgendamentoDiaSemanaHorario_Agendamento] FOREIGN KEY ([Agendamento_Id]) REFERENCES [dbo].[Agendamento] ([Agendamento_Id]),
    CONSTRAINT [FK_AgendamentoDiaSemanaHorario_DiaSemana] FOREIGN KEY ([DiaSemana_Id]) REFERENCES [dbo].[DiaSemana] ([DiaSemana_Id]),
    CONSTRAINT [FK_AgendamentoDiaSemanaHorario_Horario] FOREIGN KEY ([Horario_Id]) REFERENCES [dbo].[Horario] ([Horario_Id])
);

