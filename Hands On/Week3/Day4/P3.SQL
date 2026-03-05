--------------------- 3. Store Performance and Stock Validation
CREATE TABLE stores (
store_id INT PRIMARY KEY,
store_name VARCHAR(50)
);
CREATE TABLE order_items (
order_id INT,
product_id INT,
quantity INT,
discount DECIMAL(10,2)
);
CREATE TABLE stocks (
store_id INT,
product_id INT,
quantity INT
);

INSERT INTO stores VALUES (1,'Store1');
INSERT INTO stores VALUES (2,'Store2');
INSERT INTO order_items VALUES (1,101,2,100);
INSERT INTO order_items VALUES (2,102,1,50);
INSERT INTO order_items VALUES (3,103,3,200);
INSERT INTO stocks VALUES (1,101,5);
INSERT INTO stocks VALUES (1,102,0);
INSERT INTO stocks VALUES (2,103,0);

ALTER TABLE order_items
ADD store_id INT;
UPDATE order_items
SET store_id = 1
WHERE order_id IN (1,2);
UPDATE order_items
SET store_id = 2
WHERE order_id = 3;

--1. Identify products sold in each store using nested queries.
SELECT store_id, product_id
FROM order_items;
--2. Compare sold products with current stock using INTERSECT and EXCEPT operators.
SELECT product_id
FROM order_items
INTERSECT
SELECT product_id
FROM stocks;
--3. Display store_name, product_name, total quantity sold.
SELECT s.store_name, p.product_name, SUM(i.quantity) AS total_quantity
FROM order_items i
JOIN stores s ON i.store_id = s.store_id
JOIN products p ON i.product_id = p.product_id
GROUP BY s.store_name, p.product_name;
--4. Calculate total revenue per product (quantity × list_price – discount).
SELECT p.product_name,
SUM((i.quantity * p.list_price) - i.discount) AS total_revenue
FROM order_items i
JOIN products p ON i.product_id = p.product_id
GROUP BY p.product_name;
--5. Update stock quantity to 0 for discontinued products (simulation).
UPDATE stocks
SET quantity = 0
WHERE product_id = 102;
