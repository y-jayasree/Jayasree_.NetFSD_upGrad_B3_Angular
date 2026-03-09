
CREATE DATABASE SalesDb
USE SalesDb;
-----------------------------Problem 1: Stored Procedures and User-Defined Functions
CREATE TABLE stores (
store_id INT PRIMARY KEY,
store_name VARCHAR(50)
);
CREATE TABLE products (
product_id INT PRIMARY KEY,
product_name VARCHAR(50),
price DECIMAL(10,2)
);
CREATE TABLE orders (
order_id INT PRIMARY KEY,
store_id INT,
order_date DATE,
FOREIGN KEY (store_id) REFERENCES stores(store_id)
);
CREATE TABLE order_items (
item_id INT PRIMARY KEY,
order_id INT,
product_id INT,
quantity INT,
discount DECIMAL(5,2),
FOREIGN KEY (order_id) REFERENCES orders(order_id),
FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO stores VALUES
(1,'Store1'),
(2,'Store2');
INSERT INTO products VALUES
(101,'Laptop',60000),
(102,'Mobile',20000),
(103,'Headphones',2000),
(104,'Keyboard',1500),
(105,'Mouse',800);
INSERT INTO orders VALUES
(1,1,'2026-03-01'),
(2,1,'2026-03-02'),
(3,2,'2026-03-03'),
(4,2,'2026-03-04');
INSERT INTO order_items VALUES
(1,1,101,1,10),
(2,1,105,2,5),
(3,2,102,1,0),
(4,3,103,3,5),
(5,4,101,1,15),
(6,4,104,2,0);

-- Create a stored procedure to generate total sales amount per store.
CREATE PROCEDURE total_sales
AS
BEGIN
SELECT 
s.store_id,
s.store_name,
SUM(oi.quantity * p.price) AS total_sales
FROM stores s
JOIN orders o 
ON s.store_id = o.store_id
JOIN order_items oi 
ON o.order_id = oi.order_id
JOIN products p 
ON oi.product_id = p.product_id
GROUP BY s.store_id, s.store_name
END
EXEC total_sales;

-- Create a stored procedure to retrieve orders by date range.
CREATE PROCEDURE orders_by_date
@start_date DATE,
@end_date DATE
AS
BEGIN
SELECT *
FROM orders
WHERE order_date BETWEEN @start_date AND @end_date
END
EXEC orders_by_date '2026-03-01','2026-03-04';

-- Create a scalar function to calculate total price after discount.
CREATE FUNCTION discount_price(
@price DECIMAL(10,2),
@discount DECIMAL(5,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
DECLARE @final_price DECIMAL(10,2)
SET @discount = ISNULL(@discount,0)
SET @final_price = @price - (@price * @discount / 100)
RETURN @final_price
END
SELECT dbo.discount_price(1000,10);

-- Create a table-valued function to return top 5 selling products.
CREATE FUNCTION top5_products()
RETURNS TABLE
AS
RETURN(
SELECT TOP 5
p.product_id,
p.product_name,
SUM(oi.quantity) AS total_sold
FROM products p
JOIN order_items oi
ON p.product_id = oi.product_id
GROUP BY p.product_id, p.product_name
ORDER BY total_sold DESC
)
SELECT * 
FROM dbo.top5_products();