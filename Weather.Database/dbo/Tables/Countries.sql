﻿CREATE TABLE [dbo].[Country]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(255) NOT NULL, 
    [AlphaCode] NCHAR(10) NOT NULL, 
    [Version] INT NOT NULL, 
    [IsDeleted] BIT NOT NULL
)
