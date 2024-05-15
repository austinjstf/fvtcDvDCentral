BEGIN
INSERT INTO tblOrder (Id, CustomerId, OrderDate, UserId, ShipDate)
VALUES
(1, 1, '2016-01-01', 1, '2016-01-01'),
(2, 2, '2016-02-02', 2, '2016-02-02'),
(3, 3, '2016-03-03', 3, '2016-03-03')
END;