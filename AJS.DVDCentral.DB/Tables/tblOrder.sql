CREATE TABLE [dbo].[tblOrder]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[CustomerId] INT NOT NULL, --fk
	[OrderDate] DATETIME NOT NULL,
	[UserId] INT NOT NULL, --fk
	[ShipDate] DATETIME NOT NULL
)
