CREATE TABLE [dbo].[TBQuestao] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Enunciado]   VARCHAR (500) NOT NULL,
    [JaUtilizada] BIT           CONSTRAINT [DF_TBQuestao_JaUtilizada] DEFAULT ((0)) NOT NULL,
    [Materia_Id]  INT           NOT NULL,
    CONSTRAINT [PK_TBQuestao] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBQuestao_TBMateria] FOREIGN KEY ([Materia_Id]) REFERENCES [dbo].[TBMateria] ([Id])
);



