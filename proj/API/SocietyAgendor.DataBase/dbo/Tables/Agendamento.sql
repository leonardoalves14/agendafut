CREATE TABLE [dbo].[Agendamento] (
    [Agendamento_Id]           INT           NOT NULL,
    [Agendamento_Desc]         VARCHAR (200) NOT NULL,
    [Agendamento_DataCadastro] DATETIME      NOT NULL,
    CONSTRAINT [PK_Agendamento] PRIMARY KEY CLUSTERED ([Agendamento_Id] ASC)
);

