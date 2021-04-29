ALTER TABLE [dbo].[City]
	ADD CONSTRAINT [CountryForeignKeyConstraint]
	FOREIGN KEY (CountryId)
	REFERENCES [Country] (Id)
