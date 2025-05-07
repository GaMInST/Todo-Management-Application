# 📝 TodoApp — ASP.NET Core 8 MVC Todo Manager

A simple Todo Management web application built using **ASP.NET Core 8 MVC**, **Entity Framework Core**, and **SQLite**.  
This project is focused on clean structure, basic CRUD operations, and demonstrates a working knowledge of .NET Core MVC concepts.

---

## 🚀 Tech Stack

- [.NET 8 (ASP.NET Core MVC)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/) with SQLite
- [Bootstrap (via CDN)](https://getbootstrap.com/)
- [Swagger / Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) for API documentation

---

## 📁 Project Structure
TodoApp/
├── Controllers/
│ ├── HomeController.cs
│ └── TodosController.cs
├── Data/
│ └── AppDbContext.cs
├── Migrations/
│ ├── 20250506182855_InitialCreate.cs
│ └── AppDbContextModelSnapshot.cs
├── Models/
│ ├── ErrorViewModel.cs
│ └── Todo.cs
├── Views/
│ ├── Home/
│ │ ├── Index.cshtml
│ │ └── Privacy.cshtml
│ ├── Shared/
│ │ ├── _Layout.cshtml
│ │ ├── _ValidationScriptsPartial.cshtml
│ │ └── Error.cshtml
│ └── Todos/
│ ├── Index.cshtml
│ ├── Create.cshtml
│ ├── Edit.cshtml
│ ├── Details.cshtml
│ └── Delete.cshtml
├── Program.cs
├── TodoApp.csproj
├── appsettings.json
├── todo.db*
├── README.md

---

## ⚙️ Setup Instructions

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Visual Studio 2022+ or VS Code
- Git

### Clone the Repository
```bash
git clone https://github.com/GaMInST/Todo-Management-Application.git
cd Todo-Management-Application
```
### Restore & Run
```bash
dotnet restore
dotnet ef database update
dotnet run
```
Open your browser and navigate to:
👉 https://localhost:5001 or http://localhost:5000
or `https://localhost:7272` (or the port shown in your browser when running from Visual Studio)

### Features Implemented
✅ Basic CRUD for Todos
✅ SQLite database with EF Core
✅ Swagger API documentation (/swagger)
✅ Server-side validation
✅ MVC Views for Create/Edit/Delete/Details
✅ Proper error handling
✅ Clean code organization
✅ Bootstrap UI via layout
✅ Enum values rendered as dropdown in forms

## 📘 API Documentation with Swagger

This project includes a Web API alongside the MVC views to allow interaction with Todo items programmatically.

### 🔗 Accessing Swagger

After running the project (via Visual Studio), open your browser and go to: 
``` https://localhost:7272/swagger```

> ⚠️ Note: Make sure the app is running in **HTTPS mode** as `https://localhost:7272`.

---

### 📂 Available API Endpoints

A separate API controller (`TodosApiController`) has been added to provide JSON-based endpoints for working with Todos. You can use Swagger UI or Postman to interact with the following endpoints:

| Method | Endpoint                  | Description             |
|--------|---------------------------|-------------------------|
| GET    | /api/TodosApi             | Get all todos           |
| GET    | /api/TodosApi/{id}        | Get a specific todo     |
| POST   | /api/TodosApi             | Create a new todo       |
| PUT    | /api/TodosApi/{id}        | Update an existing todo |
| DELETE | /api/TodosApi/{id}        | Delete a todo           |

---

### 🧪 Testing the API

You can test the API in two ways:

#### ✅ Swagger UI
Visit: `https://localhost:7272/swagger`  
Try each operation directly from your browser.

#### ✅ Postman
Use the above routes (e.g., `GET https://localhost:7272/api/TodosApi`) to test the API.

---

### 📌 Notes

- These API endpoints are **separate** from the MVC views rendered by `TodosController.cs`.
- The API controller returns `JSON` and follows RESTful conventions.
- This setup allows the app to support both web frontend views and external API consumers.

 ### Known Limitations / Challenges
 - No user authentication or authorization (for simplicity)
 - No pagination or filtering
 - SQLite is used for quick setup; not ideal for production
 - No client-side interactivity or JS enhancements
   
### 📌 Notes
This project was built in under 4 hours as part of a coding challenge.
Focus was placed on code clarity, simplicity, and functionality — not completeness or complexity.
