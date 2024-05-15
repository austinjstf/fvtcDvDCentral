BEGIN
INSERT INTO tblMovie (Id, Title, Description, FormatId, DirectorId, RatingId, Cost, InStkQty, ImagePath)
VALUES
(1, 'The Lost World', 'An action-packed movie.', 1, 1, 1, 1, 1, 'fantasy.jpg'),
(2, 'Galactic Odyssey', 'A science fiction movie.', 2, 2, 2, 2, 2, 'horror.jpg'),
(3, 'Fantasy Quest', 'An epic adventure film.', 3, 3, 3, 3, 3, 'mystery.jpg');
END;