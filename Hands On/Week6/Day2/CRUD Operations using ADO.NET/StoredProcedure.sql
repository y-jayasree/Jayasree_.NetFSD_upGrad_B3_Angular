use StoreDB;

CREATE TABLE Products1 (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);
INSERT INTO Products1(ProductName, Category, Price)
VALUES ('Mobile', 'Electronics', 20000),
('Laptop', 'Electronics', 50000),
('Chair', 'Furniture', 3000),
('Table', 'Furniture', 7000);

SELECT * FROM Products1;

---- stored procedures
CREATE PROCEDURE sp_InsertProduct
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Products1(ProductName, Category, Price)
    VALUES (@ProductName, @Category, @Price)
END
-------------
CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT * FROM Products1
END
-------
CREATE PROCEDURE sp_UpdateProduct
    @ProductId INT,
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    UPDATE Products1
    SET ProductName = @ProductName,
        Category = @Category,
        Price = @Price
    WHERE ProductId = @ProductId
END
----------
CREATE PROCEDURE sp_DeleteProduct
    @ProductId INT
AS
BEGIN
    DELETE FROM Products1 WHERE ProductId = @ProductId
END


CREATE PROCEDURE sp_GetProductById
    @ProductId INT
AS
BEGIN
    SELECT * FROM Products1
    WHERE ProductId = @ProductId
END
