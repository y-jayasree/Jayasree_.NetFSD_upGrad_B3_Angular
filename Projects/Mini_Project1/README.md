###                                   ShopEZ - E-Commerce Backend API



###### ---> Project Overview

ShopEZ is a backend REST API for an e-commerce system built using ASP.NET Core Web API.

It supports user authentication, product management, and order processing.

###### ---> Technologies Used

-> ASP.NET Core Web API

-> Entity Framework Core

-> SQL Server

-> JWT Authentication

-> Repository,Service Pattern

-> BCrypt Password Hashing

-> DTOs

-> Custom Exception Middleware

-> Swagger,Postman (API Testing)


###### ---> Customer/User Roles

-> Register/Login

-> View products

-> Place orders

-> View order details(only my-orders)

###### ---> Admin

-> Register/Login

-> Add products

-> Update products

-> Delete products

-> View all orders

###### ---> API Endpoints
--> Auth APIs

POST /api/auth/register

POST /api/auth/register-admin

POST /api/auth/login {both logins}



GET /api/products

GET /api/products/{id}

POST /api/products (Admin only)

PUT /api/products/{id} (Admin only)

DELETE /api/products/{id} (Admin only)



POST /api/orders (Place order - Customer)

GET /api/orders (Admin - view all orders)

GET /api/orders/{id} (View order by ID)

GET /api/orders/my-orders {customer orders only(my-orders)}

###### ---> Authentication

-> JWT token-based authentication

-> Role-based authorization (Admin / Customer)

-> Global Exception Handling

###### ---> Architecture
-> Controller Layer (API endpoints)

-> Service Layer (Business logic)

-> Repository Layer (Data access)

-> DTO Layer (Data transfer)

-> Middleware (Global error handling)

