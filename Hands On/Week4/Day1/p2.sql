
---------------------------------Problem 2: Stock Auto-Update Trigger
CREATE TABLE stocks(
product_id INT PRIMARY KEY,
quantity INT
);
INSERT INTO stocks VALUES
(101,50),
(102,40),
(103,30),
(104,20),
(105,10);
-- Create an AFTER INSERT trigger on order_items.
CREATE TRIGGER trg_update_stock
ON order_items
AFTER INSERT
AS
BEGIN
BEGIN TRY
IF EXISTS (
SELECT 1
FROM inserted i
JOIN stocks s
ON i.product_id = s.product_id
WHERE s.quantity < i.quantity
)
BEGIN
RAISERROR('Insufficient stock available',16,1);
ROLLBACK TRANSACTION;
RETURN;
END
UPDATE s
SET s.quantity = s.quantity - i.quantity
FROM stocks s
JOIN inserted i
ON s.product_id = i.product_id;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    THROW;
END CATCH
END;

-- Prevent stock from becoming negative.
SELECT * FROM stocks WHERE product_id = 101;
INSERT INTO order_items VALUES (9,1,101,2,0);
SELECT * FROM stocks WHERE product_id = 101;

-- If stock is insufficient, rollback the transaction with a custom error message.
INSERT INTO order_items VALUES (10,1,101,2,0);
SELECT * FROM order_items WHERE product_id = 101;
SELECT * FROM stocks WHERE product_id = 101;
INSERT INTO stocks VALUES (101,50);
