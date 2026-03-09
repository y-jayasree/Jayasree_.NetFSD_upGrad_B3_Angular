
--------------------------------- Problem 3: Order Status Validation Trigger
ALTER TABLE orders
ADD order_status INT,
shipped_date DATE;
UPDATE orders
SET order_status = 1,
    shipped_date = NULL
WHERE order_id = 1;
UPDATE orders
SET order_status = 2,
    shipped_date = '2026-03-03'
WHERE order_id = 2;
UPDATE orders
SET order_status = 1,
    shipped_date = NULL
WHERE order_id = 3;
UPDATE orders
SET order_status = 3,
    shipped_date = '2026-03-05'
WHERE order_id = 4;

-- Create an AFTER UPDATE trigger on orders.
CREATE TRIGGER trg_order_status
ON orders
AFTER UPDATE
AS
BEGIN
BEGIN TRY
IF EXISTS(
SELECT 1
FROM inserted
WHERE order_status = 4
AND shipped_date IS NULL
)
BEGIN
ROLLBACK;
THROW 50002,'Shipped date must not be NULL when order status is Completed',1;
END
END TRY
BEGIN CATCH
THROW;
END CATCH
END

-- Validate that shipped_date is NOT NULL when order_status = 4.
UPDATE orders
SET order_status = 4
WHERE order_id = 1;

UPDATE orders
SET shipped_date = '2026-03-10',
order_status = 4
WHERE order_id = 1;
-- Prevent update if condition fails.
SELECT * FROM orders WHERE order_id = 1;
