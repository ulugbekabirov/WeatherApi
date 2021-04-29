﻿CREATE TABLE [dbo].[City]
(
	[Id] UNIQUEIDENTIFIER NOT NULL ,
    [CountryId] INT NOT NULL,
    [Name] VARCHAR(255) NOT NULL, 
    [Version] INT NOT NULL, 
    [IsDeleted] BIT NOT NULL, 
    PRIMARY KEY ([Id])
)
