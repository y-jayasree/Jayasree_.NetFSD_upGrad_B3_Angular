
CREATE DATABASE BookMart;
USE BookMart

CREATE TABLE Books(
    BookID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(150) NOT NULL,
    Stock INT NOT NULL CHECK (Stock >= 0),
    Price DECIMAL(10,2) NOT NULL
);
CREATE TABLE Orders(
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    BookID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    OrderDate DATETIME2 DEFAULT SYSDATETIME(),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);

-----Task 1: Stored Procedure to Add a Book  
CREATE PROCEDURE sp_AddNewBook
    @Title NVARCHAR(150),
    @Stock INT,
    @Price DECIMAL(10,2)
AS
BEGIN

    BEGIN TRY

        INSERT INTO Books (Title, Stock, Price)
        VALUES (@Title, @Stock, @Price);

        PRINT 'Book added successfully';

    END TRY

    BEGIN CATCH

        PRINT 'Error: ' + ERROR_MESSAGE();

    END CATCH

END
-----Task 2: Main Stored Procedure – Place Order with Transaction  
CREATE PROCEDURE sp_PlaceOrder
    @BookID INT,
    @Quantity INT
AS
BEGIN

    SET XACT_ABORT ON;

    BEGIN TRY

        BEGIN TRANSACTION;

        -- Check book exists and stock available
        IF NOT EXISTS
        (
            SELECT 1
            FROM Books
            WHERE BookID = @BookID
            AND Stock >= @Quantity
        )
        BEGIN
            RAISERROR('Not enough stock or book not found.',16,1);
        END

        -- Reduce stock
        UPDATE Books
        SET Stock = Stock - @Quantity
        WHERE BookID = @BookID;

        -- Insert order
        INSERT INTO Orders(BookID, Quantity)
        VALUES(@BookID, @Quantity);

        COMMIT TRANSACTION;

        PRINT 'Order placed successfully.';

    END TRY

    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        PRINT 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR)
              + ': ' + ERROR_MESSAGE();

    END CATCH

END

EXEC sp_AddNewBook 'SQL', 10, 499.00;
EXEC sp_AddNewBook 'C# Programming', 5, 599.00;
EXEC sp_AddNewBook 'Web Development', 8, 450.00;
EXEC sp_AddNewBook 'Python', 6, 550.00;

--1.	Successful order → stock decreases, order is inserted.
EXEC sp_PlaceOrder 1, 2;
EXEC sp_PlaceOrder 4, 1;
--2.	Insufficient stock → error message, no change in stock or orders table.
EXEC sp_PlaceOrder 2, 20;
--3.	Invalid BookID (book does not exist) → error, rollback happens.
EXEC sp_PlaceOrder 100, 1;



SELECT * FROM Orders;
SELECT * FROM Books;
 
 
