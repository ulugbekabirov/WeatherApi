CREATE TABLE [dbo].[Cities] (
    [Id]        UNIQUEIDENTIFIER           NOT NULL,
    [CountryId] UNIQUEIDENTIFIER           NOT NULL,
    [Name]      VARCHAR (255) NOT NULL,
    [Version]   INT           NOT NULL,
    [IsDeleted] BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CountryForeignKeyConstraint] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([Id])
);

