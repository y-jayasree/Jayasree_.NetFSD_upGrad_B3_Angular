CREATE DATABASE EcommDb;
USE EcommDb;

----------------------- Problem 1: Basic Setup and Data Retrieval in EcommDb
CREATE TABLE categories(
category_id INT PRIMARY KEY,
category_name VARCHAR(50)
);
CREATE TABLE brands(
brand_id INT PRIMARY KEY,
brand_name VARCHAR(50)
);
CREATE TABLE products(
product_id INT PRIMARY KEY,
product_name VARCHAR(50),
brand_id INT,
category_id INT,
model_year INT,
list_price DECIMAL(10,2),
FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
FOREIGN KEY (category_id) REFERENCES categories(category_id)
);
CREATE TABLE customers(
customer_id INT PRIMARY KEY,
first_name VARCHAR(50),
last_name VARCHAR(50),
city VARCHAR(50)
);
CREATE TABLE stores(
store_id INT PRIMARY KEY,
store_name VARCHAR(50),
city VARCHAR(50)
);

INSERT INTO categories VALUES
(1,'A'),
(2,'B'),
(3,'C'),
(4,'D'),
(5,'E');
INSERT INTO brands VALUES
(1,'Toyota'),
(2,'Honda'),
(3,'Tesla'),
(4,'Ford'),
(5,'Hyundai');
INSERT INTO products VALUES
(1,'Fortuner',1,1,2023,45000),
(2,'City',2,2,2023,25000),
(3,'Model S',3,5,2024,80000),
(4,'F150',4,4,2023,50000),
(5,'i20',5,3,2023,20000);
INSERT INTO customers VALUES
(1,'MS','Dhoni','Delhi'),
(2,'Rohith','Sharma','Hyderabad'),
(3,'Surya','Kumar','Hyderabad'),
(4,'Thilak','Varma','Mumbai'),
(5,'KL','Rahul','Delhi');
INSERT INTO stores VALUES
(1,'AutoHub','Delhi'),
(2,'CarWorld','Hyderabad'),
(3,'DriveMart','Mumbai'),
(4,'SpeedMotors','Chennai'),
(5,'AutoZone','Bangalore');

SELECT * FROM customers;
SELECT * FROM stores;

--Write SELECT queries to retrieve all products with their brand and category names.
SELECT p.product_name,b.brand_name,c.category_name
FROM products p
JOIN brands b
ON p.brand_id = b.brand_id
JOIN categories c
ON p.category_id = c.category_id;
-- Retrieve all customers from a specific city.
SELECT *
FROM customers
WHERE city = 'Hyderabad';
-- Display total number of products available in each category.
SELECT c.category_name,
COUNT(p.product_id) AS total_products
FROM categories c
LEFT JOIN products p
ON c.category_id = p.category_id
GROUP BY c.category_name;




-----------------------------2.Creating Views and Indexes for Performance
CREATE TABLE staffs(
staff_id INT PRIMARY KEY,
first_name VARCHAR(50),
last_name VARCHAR(50)
);
CREATE TABLE orders(
order_id INT PRIMARY KEY,
customer_id INT,
store_id INT,
staff_id INT,
order_date DATE,
FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
FOREIGN KEY (store_id) REFERENCES stores(store_id),
FOREIGN KEY (staff_id) REFERENCES staffs(staff_id)
);
INSERT INTO staffs VALUES
(1,'John','David'),
(2,'Sara','Lee');
INSERT INTO orders VALUES
(1,1,1,1,'2024-01-10'),
(2,2,2,2,'2024-02-12');

--create a view that shows product name, brand name, category name, model year and list price.
CREATE VIEW vw_product AS
SELECT p.product_name,b.brand_name,c.category_name,p.model_year,p.list_price
FROM products p
JOIN brands b
ON p.brand_id = b.brand_id
JOIN categories c
ON p.category_id = c.category_id;
SELECT * FROM vw_product;
-- Create a view that shows order details with customer name, store name and staff name.
CREATE VIEW vw_order_details AS
SELECT o.order_id,c.first_name + c.last_name AS customer_name,s.store_name,st.first_name + st.last_name AS staff_name
FROM orders o
JOIN customers c
ON o.customer_id = c.customer_id
JOIN stores s
ON o.store_id = s.store_id
JOIN staffs st
ON o.staff_id = st.staff_id;
SELECT * FROM vw_order_details;
-- Create appropriate indexes on foreign key columns.
CREATE INDEX idx_customer_id
ON orders(customer_id);
CREATE INDEX idx_store_id
ON orders(store_id);
CREATE INDEX idx_staff_id
ON orders(staff_id);
-- Test performance improvement using execution plan.
sp_helpindex orders;
