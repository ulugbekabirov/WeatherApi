Alter TABLE [dbo].[Cities]
	ADD CONSTRAINT [CountriesForeignKeyConstraint]
	FOREIGN KEY (CountryId)
	REFERENCES [Countries] (Id)
