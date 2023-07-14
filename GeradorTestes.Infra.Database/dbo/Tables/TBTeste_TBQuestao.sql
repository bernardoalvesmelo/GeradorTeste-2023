CREATE TABLE [dbo].[TBTeste_TBQuestao] (
    [Teste_Id]   INT NOT NULL,
    [Questao_Id] INT NOT NULL,
    CONSTRAINT [FK_TBTeste_TBQuestaoTBTeste] FOREIGN KEY ([Teste_Id]) REFERENCES [dbo].[TBTeste] ([Id]),
    CONSTRAINT [FK_TBTesteTBQuestao_TBQuestao] FOREIGN KEY ([Questao_Id]) REFERENCES [dbo].[TBQuestao] ([Id])
);

