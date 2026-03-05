---------------------Problem 4 – Order Cleanup and Data Maintenance
ALTER TABLE orders
ADD order_status INT,        
    order_date DATE,
    shipped_date DATE,
    required_date DATE;

UPDATE orders
SET order_status = 4, order_date = '2025-02-01', shipped_date = '2025-02-03', required_date = '2025-02-05'
WHERE order_id = 101;
UPDATE orders
SET order_status = 3, order_date = '2024-01-15', shipped_date = NULL, required_date = '2024-01-20'
WHERE order_id = 102;
UPDATE orders
SET order_status = 4, order_date = '2025-01-10', shipped_date = '2025-01-12', required_date = '2025-01-15'
WHERE order_id = 103;
UPDATE orders
SET order_status = 2, order_date = '2025-02-10', shipped_date = NULL, required_date = '2025-02-20'
WHERE order_id = 104;


CREATE TABLE archived_orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_value DECIMAL(10,2),
    order_status INT,
    order_date DATE,
    shipped_date DATE,
    required_date DATE
);

--1. Insert archived records into a new table (archived_orders) using INSERT INTO SELECT.
INSERT INTO archived_orders (order_id, customer_id, order_value, order_status, order_date, shipped_date, required_date)
SELECT order_id, customer_id, order_value, order_status, order_date, shipped_date, required_date
FROM orders
WHERE order_status = 4;
--2. Delete orders where order_status = 3 (Rejected) and older than 1 year.
DELETE FROM orders
WHERE order_status = 3
AND order_date < '2024-03-05';
--3. Use nested query to identify customers whose all orders are completed.
SELECT *
FROM customers c
WHERE NOT EXISTS (
    SELECT 1
    FROM orders o
    WHERE o.customer_id = c.customer_id
      AND o.order_status != 4
);
--4. Display order processing delay (DATEDIFF between shipped_date and order_date).
SELECT order_id,
       customer_id,
       order_date,
       shipped_date,
       DATEDIFF(day, order_date, shipped_date) AS processing_delay
FROM orders
WHERE shipped_date IS NOT NULL;
--5. Mark orders as 'Delayed' or 'On Time' using CASE expression based on required_date.
SELECT order_id,customer_id,order_date,required_date,shipped_date,
CASE 
WHEN shipped_date IS NULL THEN 'Pending'
WHEN shipped_date > required_date THEN 'Delayed'
ELSE 'On Time'
END AS order_status
FROM orders;
