CREATE TABLE [dbo].[tblOrderItem]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[OrderId] INT NOT NULL, --fk
	[Quantity] INT NOT NULL,
	[MovieId] INT NOT NULL, --fk
	[Cost] float NOT NULL
)
