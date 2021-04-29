CREATE TABLE [dbo].[Countries] (
    [Id]        UNIQUEIDENTIFIER           NOT NULL,
    [Name]      VARCHAR (255) NOT NULL,
    [AlphaCode] NCHAR (10)    NOT NULL,
    [Version]   INT           NOT NULL,
    [IsDeleted] BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

