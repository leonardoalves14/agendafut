CREATE TABLE [dbo].[Usuario] (
    [Usuario_Id]    INT           NOT NULL,
    [Usuario_Login] VARCHAR (50)  NOT NULL,
    [Usuario_Senha] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([Usuario_Id] ASC)
);

