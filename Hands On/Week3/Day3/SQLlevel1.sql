

CREATE DATABASE StoreDB;
USE StoreDB;

---- 1.order report -----
CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    order_status INT,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);

INSERT INTO customers VALUES
(1, 'Jaya', 'sree'),
(2, 'Raji', 'Sharma');

INSERT INTO orders VALUES
(101, 1, '2026-03-01', 1),
(102, 1, '2026-03-02', 4),
(103, 2, '2026-03-03', 4);

SELECT c.first_name,c.last_name,o.order_id,o.order_date,o.order_status
FROM customers AS c INNER JOIN orders AS o 
ON c.customer_id=o.customer_id
WHERE order_status IN (1,4)
ORDER BY order_date DESC;


--- 2.Product Price Listing by Category----
CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(50) NOT NULL
);

CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50) NOT NULL
);

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50) NOT NULL,
	model_year INT,
	list_price DECIMAL(10,2),
	brand_id INT,
	category_id INT,
	FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
	FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

INSERT INTO brands VALUES
(1, 'Nike'),
(2, 'Adidas');
INSERT INTO categories VALUES
(1, 'Shoes'),
(2, 'Clothing'),
(3, 'Electronics');
INSERT INTO products VALUES
(101, 'Shoes', 2024, 750, 1, 1),
(102, 'Bluetooth Speaker', 2023, 650, 2, 1),
(103, 'T-Shirt', 2024, 400.99, 2, 2),
(104, 'iPhone', 2024, 1200, 1, 3),
(105, 'MacBook', 2025, 1500, 2, 3);

select * from brands;
select * from categories;
select * from products;

SELECT P.product_name, B.brand_name, C.category_name, P.model_year, P.list_price
FROM products AS p 
INNER JOIN brands AS b ON P.brand_id=b.brand_id
INNER JOIN categories AS c ON p.category_id=c.category_id
WHERE P.list_price>500
ORDER BY p.list_price ASC;