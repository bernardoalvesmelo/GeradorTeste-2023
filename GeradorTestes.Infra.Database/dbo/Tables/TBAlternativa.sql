CREATE TABLE [dbo].[TBAlternativa] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Letra]      CHAR (1)      NOT NULL,
    [Resposta]   VARCHAR (100) NOT NULL,
    [Correta]    BIT           NOT NULL,
    [Questao_Id] INT           NOT NULL,
    CONSTRAINT [PK_TBAlternativa] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBAlternativa_TBQuestao] FOREIGN KEY ([Questao_Id]) REFERENCES [dbo].[TBQuestao] ([Id])
);

