BEGIN
INSERT INTO tblCustomer (Id, FirstName, LastName, UserId, Address, City, State, ZIP, Phone)
VALUES
(1, 'John', 'Doe', 1, '123 Main St', 'New York', 'NY', '10001', '555-123-4567'),
(2, 'Jane', 'Smith', 2, '456 Elm St', 'Los Angeles', 'CA', '90001', '555-987-6543'),
(3, 'Robert', 'Johnson', 3, '789 Oak Ave', 'Chicago', 'IL', '60601', '555-789-1234')
END;