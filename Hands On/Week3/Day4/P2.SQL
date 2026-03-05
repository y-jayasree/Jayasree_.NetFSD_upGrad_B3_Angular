-------------- 2. Customer Activity Classification
CREATE TABLE customers (
customer_id INT PRIMARY KEY,
first_name VARCHAR(50),
last_name VARCHAR(50)
);
CREATE TABLE orders (
order_id INT PRIMARY KEY,
customer_id INT,
order_value DECIMAL(10,2)
);

INSERT INTO customers VALUES (1,'A','aa');
INSERT INTO customers VALUES (2,'B','bb');
INSERT INTO customers VALUES (3,'C','cc');
INSERT INTO customers VALUES (4,'D','dd');

INSERT INTO orders VALUES (101,1,6000);
INSERT INTO orders VALUES (102,1,5000);
INSERT INTO orders VALUES (103,2,3000);
INSERT INTO orders VALUES (104,2,1000);

SELECT * FROM customers;
SELECT * FROM orders;
--1. Use nested query to calculate total order value per customer.
SELECT customer_id,(
SELECT SUM(order_value)
FROM orders o
WHERE o.customer_id = c.customer_id
) AS total_order
FROM customers c;
--2. Classify customers using conditional logic:
   -- 'Premium' if total order value > 10000
   -- 'Regular' if total order value between 5000 and 10000
   -- 'Basic' if total order value < 5000
SELECT customer_id,
CASE
WHEN SUM(order_value) > 10000 THEN 'Premium'
WHEN SUM(order_value) BETWEEN 5000 AND 10000 THEN 'Regular'
ELSE 'Basic'
END AS customer_type
FROM orders
GROUP BY customer_id;
--3. Use UNION to display customers with orders and customers without orders.
SELECT c.customer_id, c.first_name, c.last_name, 'With Orders' AS order_status
FROM customers c
JOIN orders o
ON c.customer_id = o.customer_id
UNION
SELECT c.customer_id, c.first_name, c.last_name, 'Without Orders' AS order_status
FROM customers c
WHERE c.customer_id NOT IN (SELECT customer_id FROM orders);

--4. Display full name using string concatenation.
SELECT first_name + last_name AS full_name
FROM customers;
--5. Handle NULL cases appropriately.
SELECT c.customer_id,
ISNULL(SUM(o.order_value),0) AS total_order_value
FROM customers c
LEFT JOIN orders o
ON c.customer_id = o.customer_id
GROUP BY c.customer_id;
