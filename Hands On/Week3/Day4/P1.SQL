CREATE DATABASE AutoDb;
USE AutoDb;

-------- 1.Product Analysis Using Nested Queries ------
CREATE TABLE categories (
category_id INT PRIMARY KEY,
category_name VARCHAR(50)
);
CREATE TABLE products (
product_id INT PRIMARY KEY,
product_name VARCHAR(100),
category_id INT,
model_year INT,
list_price DECIMAL(10,2)
);

INSERT INTO categories VALUES (1, 'Mountain Bikes');
INSERT INTO categories VALUES (2, 'Road Bikes');
INSERT INTO categories VALUES (3, 'Electric Bikes');

INSERT INTO products VALUES (101, 'Trail Bike', 1, 2017, 1200);
INSERT INTO products VALUES (102, 'Rock Bike', 1, 2018, 1500);
INSERT INTO products VALUES (103, 'Hill Bike', 1, 2019, 900);

SELECT * FROM categories;
SELECT * FROM products;

--1. Retrieve product details (product_name, model_year, list_price).
SELECT product_name,model_year,list_price FROM products;
--2. Compare each product’s price with the average price of products in the same category using a nested query.
SELECT product_name, model_year, list_price,(
SELECT AVG(list_price)
FROM products p2
WHERE p2.category_id = p1.category_id
) AS category_avg_price
FROM products p1;
--3. Display only those products whose price is greater than the category average.
SELECT product_name, model_year, list_price
FROM products p1
WHERE list_price > (
SELECT AVG(list_price)
FROM products p2
WHERE p2.category_id = p1.category_id
);
--4. Show calculated difference between product price and category average.
SELECT product_name, model_year, list_price,
list_price - (
SELECT AVG(list_price)
FROM products p2
WHERE p2.category_id = p1.category_id
) AS price_difference
FROM products p1;
--5. Concatenate product name and model year as a single column (e.g., 'ProductName (2017)').
SELECT CONCAT(product_name, ' (', model_year, ')') AS product_details
FROM products;
