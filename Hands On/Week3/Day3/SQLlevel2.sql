
--- LEVEL 2
--1. Store Wise Sales Summary
USE StoreDB;

CREATE TABLE stores(
store_id INT PRIMARY KEY,
store_name varchar(50)NOT NULL);

CREATE TABLE order_items (
order_item_id INT PRIMARY KEY,
order_id INT,
quantity INT,
list_price DECIMAL(10,2),
discount DECIMAL(10,2),
FOREIGN KEY (order_id) REFERENCES orders(order_id)
);

SELECT * FROM orders;
ALTER TABLE orders
ADD store_id INT;
ALTER TABLE orders
ADD FOREIGN KEY (store_id) REFERENCES stores(store_id);
UPDATE orders
SET store_id = 1
WHERE order_id = 101;
UPDATE orders
SET store_id = 2
WHERE order_id = 102;
UPDATE orders
SET store_id = 2
WHERE order_id = 103;

SELECT * FROM order_items;

INSERT INTO stores VALUES
(1, 'Store1'),
(2, 'Store2');
INSERT INTO order_items VALUES
(1, 101, 2, 1000, 100),
(2, 101, 1, 500, 50),
(3, 103, 3, 800, 0);

SELECT s.store_name, SUM((i.list_price-i.discount)*i.quantity) AS total_sales
FROM stores AS s
INNER JOIN orders AS o
ON s.store_id=o.store_id
INNER JOIN order_items AS i
ON i.order_id=o.order_id
WHERE o.order_status=4
GROUP BY s.store_name
ORDER BY total_sales DESC;

---- 2 - Product Stock and Sales Analysis
CREATE TABLE stocks (
    stock_id INT PRIMARY KEY,
    store_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO stocks (stock_id, store_id, product_id, quantity) VALUES
(1, 1, 101, 50),
(2, 1, 102, 30),
(3, 2, 103, 40),
(4, 1, 104, 20),
(5, 2, 105, 15);

UPDATE order_items SET product_id = 101 WHERE order_item_id = 1;
UPDATE order_items SET product_id = 101 WHERE order_item_id = 2;
UPDATE order_items SET product_id = 103 WHERE order_item_id = 3;


SELECT 
    s.store_name,
    ISNULL(SUM(oi.quantity * (oi.list_price - oi.discount)), 0) AS total_sales
FROM stores s
LEFT JOIN orders o 
    ON s.store_id = o.store_id
LEFT JOIN order_items oi 
    ON oi.order_id = o.order_id
   AND o.order_status = 4      
GROUP BY s.store_name
ORDER BY s.store_name;           

