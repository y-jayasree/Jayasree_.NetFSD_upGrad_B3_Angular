
----------------------------------Problem 4: Cursor-Based Revenue Calculation
CREATE TABLE #temp_revenue
(
order_id INT,
store_id INT,
revenue DECIMAL(10,2)
);
DECLARE @order_id INT;
DECLARE @store_id INT;
DECLARE @revenue DECIMAL(10,2);

-- Use a cursor to iterate through completed orders (order_status = 4).
DECLARE order_cursor CURSOR
FOR
SELECT order_id, store_id
FROM orders
WHERE order_status = 4;

-- Store computed revenue in a temporary table.
BEGIN TRY
BEGIN TRANSACTION
OPEN order_cursor;
FETCH NEXT FROM order_cursor INTO @order_id, @store_id;
WHILE @@FETCH_STATUS = 0
BEGIN
SELECT @revenue = SUM(oi.quantity * p.price)
FROM order_items oi
JOIN products p
ON oi.product_id = p.product_id
WHERE oi.order_id = @order_id;
INSERT INTO #temp_revenue
VALUES(@order_id, @store_id, @revenue);
FETCH NEXT FROM order_cursor INTO @order_id, @store_id;
END
CLOSE order_cursor;
DEALLOCATE order_cursor;
COMMIT TRANSACTION;
END TRY
BEGIN CATCH
ROLLBACK;
PRINT 'Error occurred';
END CATCH
-- Display store-wise revenue summary.
SELECT store_id,
SUM(revenue) AS total_revenue
FROM #temp_revenue
GROUP BY store_id;
