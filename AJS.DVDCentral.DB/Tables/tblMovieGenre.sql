CREATE TABLE [dbo].[tblMovieGenre]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[MovieId] INT NOT NULL, --fk
	[GenreId] INT NOT NULL --fk
)
