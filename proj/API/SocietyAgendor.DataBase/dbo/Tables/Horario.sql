CREATE TABLE [dbo].[Horario] (
    [Horario_Id]  INT      NOT NULL,
    [Horario_De]  TIME (0) NOT NULL,
    [Horario_Ate] TIME (0) NOT NULL,
    CONSTRAINT [PK_Horario] PRIMARY KEY CLUSTERED ([Horario_Id] ASC)
);

