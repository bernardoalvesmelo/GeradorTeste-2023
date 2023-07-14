CREATE TABLE [dbo].[TBTeste] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [Titulo]             VARCHAR (250) NOT NULL,
    [QuantidadeQuestoes] INT           NOT NULL,
    [DataGeracao]        DATETIME      NOT NULL,
    [Provao]             BIT           NOT NULL,
    [Materia_Id]         INT           NULL,
    [Disciplina_Id]      INT           NOT NULL,
    CONSTRAINT [PK_TBTeste] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBTeste_TBDisciplina] FOREIGN KEY ([Disciplina_Id]) REFERENCES [dbo].[TBDisciplina] ([Id]),
    CONSTRAINT [FK_TBTeste_TBMateria] FOREIGN KEY ([Materia_Id]) REFERENCES [dbo].[TBMateria] ([Id])
);

