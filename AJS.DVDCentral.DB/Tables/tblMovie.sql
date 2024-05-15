CREATE TABLE [dbo].[tblMovie]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Title] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(50) NOT NULL,
	[FormatId] INT NOT NULL, --fk
	[DirectorId] INT NOT NULL, --fk
	[RatingId] INT NOT NULL, --fk
	[Cost] float NOT NULL,
	[InStkQty] int NOT NULL,
	[ImagePath] VARCHAR(MAX) NOT NULL
)
