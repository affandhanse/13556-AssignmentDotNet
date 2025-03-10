CREATE DATABASE BookStoreDB;
USE BookStoreDB;

-- table constraints
CREATE TABLE Authors (
    AuthorID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Country NVARCHAR(100)
);

CREATE TABLE Books (
    BookID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    AuthorID INT,
    Price DECIMAL NOT NULL,
    PublishedYear INT,
    FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID)
);

CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    PhoneNumber NVARCHAR(15) UNIQUE NOT NULL
);

CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE NOT NULL DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderItems (
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT,
    BookID INT,
    Quantity INT NOT NULL,
    SubTotal DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);

INSERT INTO Authors (Name, Country) VALUES 
(N'J.K. Rowling', N'UK'),
(N'George R.R. Martin', N'USA'),
(N'J.R.R. Tolkien', N'UK'),
(N'Author new ', N'UK'),
(N'chetan bhagat', N'USA');

INSERT INTO Books (Title, AuthorID, Price, PublishedYear) VALUES 
(N'SQL Mastery', 1, 1500, 2020),
(N'Data Science Guide', 2, 2500, 2021),
(N'The Hobbit', 3, 1800, 1937),
(N'half girlfriend', 4, 2000, 2013),
(N'Dune', 5, 1700, 2011);

INSERT INTO Customers (Name, Email, PhoneNumber) VALUES 
('Pratik kithani', 'alice@example.com', '1234567890'),
('Nikhil Gangal', 'john@example.com', '0987654321'),
('Atharva Chaudhari', 'mary@example.com', '1122334455'),
('Sujit Ambole', 'david@example.com', '2233445566'),
('Harsh Jaiswal', 'emma@example.com', '3344556677');

INSERT INTO Orders (CustomerID, OrderDate, TotalAmount) VALUES 
(1, GETDATE(), 4000),
(2, GETDATE(), 1500),
(3, GETDATE(), 2500),
(4, GETDATE(), 1800),
(5, GETDATE(), 2000);

INSERT INTO OrderItems (OrderID, BookID, Quantity, SubTotal) VALUES 
(1, 2, 1, 2500),
(2, 1, 1, 1500),
(3, 3, 1, 1800),
(4, 4, 1, 2000),
(5, 5, 1, 1700);

UPDATE Books 
SET Price = Price * 1.1 WHERE Title = N'Dune';

DELETE FROM Customers WHERE NOT EXISTS (SELECT 1 FROM Orders WHERE Orders.CustomerID = Customers.CustomerID);

SELECT * FROM Books WHERE Price > 2000;

SELECT COUNT(*) AS TotalBooks FROM Books;

SELECT * FROM Books WHERE PublishedYear BETWEEN 2015 AND 2023;

SELECT DISTINCT Customers.* FROM Customers JOIN Orders ON Customers.CustomerID = Orders.CustomerID;

SELECT * FROM Books WHERE Title LIKE N'%SQL%';

SELECT TOP 1 * FROM Books ORDER BY Price DESC;

SELECT * FROM Customers WHERE Name LIKE N'A%' OR Name LIKE N'J%';

SELECT SUM(TotalAmount) AS TotalRevenue FROM Orders;

SELECT Books.Title, Authors.Name 
FROM Books JOIN Authors
ON Books.AuthorID = Authors.AuthorID;

SELECT Customers.Name, Orders.OrderID, Orders.OrderDate 
FROM Customers 
LEFT JOIN Orders 
ON Customers.CustomerID = Orders.CustomerID;

SELECT Books.* 
FROM Books 
LEFT JOIN OrderItems 
ON Books.BookID = OrderItems.BookID WHERE OrderItems.BookID IS NULL;

SELECT Customers.CustomerID, Customers.Name, COUNT(Orders.OrderID)
AS TotalOrders FROM Customers 
LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID 
GROUP BY Customers.Name,Customers.CustomerID;

SELECT Books.Title, OrderItems.Quantity 
FROM OrderItems 
JOIN Books ON OrderItems.BookID = Books.BookID;

SELECT Customers.Name, Orders.OrderID 
FROM Customers LEFT JOIN Orders 
ON Customers.CustomerID = Orders.CustomerID;

SELECT Authors.Name 
FROM Authors 
LEFT JOIN Books 
ON Authors.AuthorID = Books.AuthorID 
WHERE Books.AuthorID IS NULL;


-- Subqueries
SELECT Customers.* FROM Customers 
WHERE CustomerID = (SELECT TOP 1 CustomerID FROM Orders ORDER BY OrderDate ASC);

SELECT Customers.* FROM Customers 
WHERE CustomerID = (SELECT TOP 1 CustomerID FROM Orders GROUP BY CustomerID ORDER BY COUNT(OrderID) DESC);

SELECT * FROM Customers 
WHERE CustomerID NOT IN (SELECT DISTINCT CustomerID FROM Orders);

SELECT * FROM Books 
WHERE Price < (SELECT MAX(Price) FROM Books);

SELECT Customers.* FROM Customers 
WHERE (SELECT SUM(TotalAmount) FROM Orders WHERE Orders.CustomerID = Customers.CustomerID) > (SELECT AVG(TotalAmount) FROM Orders);

--stored procedures.
GO
create procedure GetCustomerOrders
@CustomerID INT
AS
BEGIN
    SELECT * FROM Orders WHERE CustomerID = @CustomerID;
END;
GO

CREATE PROCEDURE GetBooksByPriceRange @MinPrice DECIMAL(10,2), @MaxPrice DECIMAL(10,2)
AS
BEGIN
    SELECT * FROM Books WHERE Price BETWEEN @MinPrice AND @MaxPrice;
END;

-- Views
go
CREATE VIEW AvailableBooks AS
SELECT BookID, Title, AuthorID, Price, PublishedYear FROM Books WHERE BookID IN (SELECT DISTINCT BookID FROM OrderItems);
go