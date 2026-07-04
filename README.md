# eCommerceSolution.UsersService

A fast, lightweight user management and identity microservice built with **ASP.NET Core (C#)**. It utilizes **PostgreSQL** paired with **Dapper** (a high-performance Micro-ORM) to handle user data, authentication workflows, and profile management with lightning-fast query execution.

## 🛠️ Tech Stack & Infrastructure

* **Framework:** ASP.NET Core Web API (C#)
* **Database:** PostgreSQL
* **Data Access:** Dapper (Micro-ORM optimized for raw SQL query performance)
* **Containerization:** Docker (configured via the included `Dockerfile`)

## 🏗️ Architecture Role & Data Flow

This service acts as the central authority for user identity and account information within the eCommerce platform. 

* **High-Performance Storage:** PostgreSQL provides robust relational integrity for user accounts, while Dapper was chosen over a heavy ORM to maximize raw query speed and reduce overhead during high-throughput authentication flows.
* **Separation of Concerns:** The architecture follows a clean, N-tier structure separating API routing (`eCommerce.API`), core business logic (`eCommerce.Core`), and database interactions (`eCommerce.Infrastructure`).
* **Inter-Service Communication:** Other services in the ecosystem (like Orders) communicate with this service to verify user identities and fetch customer details.

## 📂 System Architecture Overview

This repository is part of a larger, decentralized eCommerce microservice ecosystem:

1. [eCommerceSolution.ProductsService](https://github.com/sonai21/eCommerceSolution.ProductsService) (Products Microservice)
2. **[eCommerceSolution.UsersService](https://github.com/sonai21/eCommerceSolution.UsersService)** (Users Microservice) - *You are here*
3. [eCommerceSolution.OrdersService](https://github.com/sonai21/eCommerceSolution.OrdersService) (Orders Microservice)

## 🚀 How to Run

### Local Development
1.  Clone the repository and navigate to the project directory:
    ```bash
    git clone [https://github.com/sonai21/eCommerceSolution.UsersService.git](https://github.com/sonai21/eCommerceSolution.UsersService.git)
    cd eCommerceSolution.UsersService
    ```
2.  Restore dependencies: 
    ```bash
    dotnet restore
    ```
3.  Update your PostgreSQL connection string in your `appsettings.json` or `appsettings.Development.json` file.
4.  Run the application: 
    ```bash
    dotnet run --project eCommerce.API
    ```

### Docker (Containerized)
To run this service in an isolated container:
```bash
docker build -t ecommercesolution-usersservice .
docker run -d -p 8080:80 ecommercesolution-usersservice
