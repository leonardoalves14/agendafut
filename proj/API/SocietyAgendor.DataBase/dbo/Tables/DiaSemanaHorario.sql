CREATE TABLE [dbo].[DiaSemanaHorario] (
    [DiaSemana_Id] INT NOT NULL,
    [Horario_Id]   INT NOT NULL,
    CONSTRAINT [PK_DiaSemanaHorario] PRIMARY KEY CLUSTERED ([DiaSemana_Id] ASC, [Horario_Id] ASC),
    CONSTRAINT [FK_DiaSemanaHorario_DiaSemana] FOREIGN KEY ([DiaSemana_Id]) REFERENCES [dbo].[DiaSemana] ([DiaSemana_Id]),
    CONSTRAINT [FK_DiaSemanaHorario_Horario] FOREIGN KEY ([Horario_Id]) REFERENCES [dbo].[Horario] ([Horario_Id])
);

