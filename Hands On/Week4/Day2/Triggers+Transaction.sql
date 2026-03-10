
CREATE DATABASE AutoretailDb;
USE AutoretailDb
----------------Problem 1: Transactions and Trigger Implementation
CREATE TABLE stores(
store_id INT PRIMARY KEY,
store_name VARCHAR(50)
);
CREATE TABLE products(
product_id INT PRIMARY KEY,
product_name VARCHAR(50),
price DECIMAL(10,2)
);
CREATE TABLE stocks(
store_id INT,
product_id INT,
quantity INT,
PRIMARY KEY(store_id,product_id),
FOREIGN KEY(store_id) REFERENCES stores(store_id),
FOREIGN KEY(product_id) REFERENCES products(product_id)
);
CREATE TABLE orders(
order_id INT PRIMARY KEY,
store_id INT,
order_date DATE,
order_status INT,
FOREIGN KEY(store_id) REFERENCES stores(store_id)
);
CREATE TABLE order_items(
item_id INT PRIMARY KEY,
order_id INT,
product_id INT,
quantity INT,
discount DECIMAL(5,2),
FOREIGN KEY(order_id) REFERENCES orders(order_id),
FOREIGN KEY(product_id) REFERENCES products(product_id)
);
INSERT INTO stores VALUES
(1,'Store1'),
(2,'Store2');
INSERT INTO products VALUES
(101,'Laptop',60000),
(102,'Mobile',20000),
(103,'Headphones',2000);
INSERT INTO stocks VALUES
(1,101,10),
(1,102,15),
(1,103,20);

-- Write a transaction to insert data into orders and order_items tables.
BEGIN TRANSACTION
INSERT INTO orders
VALUES (1,1,GETDATE(),1)
INSERT INTO order_items
VALUES (1,1,101,2,0)
COMMIT

SELECT * FROM orders;
--- Check stock availability before confirming order.
SELECT quantity
FROM stocks
WHERE product_id = 101 AND store_id = 1;
--- Create a trigger to reduce stock quantity after order insertion.
CREATE TRIGGER trg_reduce_stock
ON order_items
AFTER INSERT
AS
BEGIN
UPDATE s
SET s.quantity = s.quantity - i.quantity
FROM stocks s
JOIN inserted i
ON s.product_id = i.product_id
END
SELECT * FROM stocks;
--- Rollback transaction if stock quantity is insufficient.
BEGIN TRANSACTION
IF (SELECT quantity FROM stocks 
WHERE product_id = 101 AND store_id = 1) >= 2
BEGIN
INSERT INTO orders
VALUES (2,1,GETDATE(),1)
INSERT INTO order_items
VALUES (2,2,101,2,0)
COMMIT
END
ELSE
BEGIN
PRINT 'Stock Not Available'
ROLLBACK
END

SELECT * FROM stocks;
SELECT * FROM orders
SELECT * FROM order_items


--------------------------------Problem 2: Atomic Order Cancellation with SAVEPOINT
BEGIN TRANSACTION
BEGIN TRY
-- SAVEPOINT before restoring stock
SAVE TRANSACTION sp_restore

-- Restore stock
UPDATE s
SET s.quantity = s.quantity + oi.quantity
FROM stocks s
JOIN order_items oi ON s.product_id = oi.product_id
JOIN orders o ON o.order_id = oi.order_id
WHERE oi.order_id = 1
AND s.store_id = o.store_id

-- Update order status to Rejected
UPDATE orders
SET order_status = 3
WHERE order_id = 1

COMMIT TRANSACTION
END TRY
BEGIN CATCH

-- If error happens rollback to savepoint
ROLLBACK TRANSACTION sp_restore
PRINT ERROR_MESSAGE()
ROLLBACK TRANSACTION
END CATCH

SELECT * FROM orders;
SELECT * FROM stocks;

/*Begin transaction 

Restore stock 

Update order status 

Use SAVEPOINT 

Rollback if failure 

Commit only if success */
