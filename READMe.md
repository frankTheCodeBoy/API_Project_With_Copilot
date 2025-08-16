# 🧑‍💻 User Management API — ASP.NET Core Project with Copilot

A secure, full-stack-ready ASP.NET Core Web API for managing users. Built with custom middleware for error handling, authentication, and logging. Designed for hands-on learning and production-grade practices.

![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-9.0-blue?logo=dotnet)
![Authentication](https://img.shields.io/badge/Auth-Bearer%20Token-green?logo=security)
![Status](https://img.shields.io/badge/Status-Active-brightgreen)
![Last Commit](https://img.shields.io/github/last-commit/frankTheCodeBoy/API_Project_With_Copilot)

---

## 🚀 Features

- ✅ **Custom Middleware Pipeline**
  - `ErrorHandlingMiddleware` — catches and formats exceptions
  - `AuthenticationMiddleware` — validates bearer tokens with selective bypass
  - `LoggingMiddleware` — logs request/response data

- 🔐 **Token-Based Authentication**
- 🧪 **Swagger UI** for testing endpoints
- 📦 **Modular Structure** for easy extension and maintenance

---

## 🧱 Project Structure

```bash
API_Project_With_Copilot/
├── Controllers/              # API endpoints
├── Middleware/               # Custom middleware components
├── Models/                   # Data models
├── Properties/
├── Program.cs                # Entry point
├── appsettings.json          # Configuration
├── UserManagementAPI.sln     # Solution file
├── UserManagementAPI.csproj  # Project file
└── README.md
```

---

## 🛠️ Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/frankTheCodeBoy/API_Project_With_Copilot.git
   cd API_Project_With_Copilot
   ```

2. **Open in Visual Studio or VS Code**

3. **Restore dependencies**
   ```bash
   dotnet restore
   ```

4. **Run the project**
   ```bash
   dotnet run
   ```

5. **Access Swagger UI**
   ```
   http://localhost:<port>/swagger
   ```

---

## 🔐 Authentication Notes

- The API uses a simple bearer token validation.
- Paths like `/swagger`, `/health`, and `/` are exempt from token checks.
- Update the token logic in `AuthenticationMiddleware.cs` to match your production needs.

---

## 📜 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## 🙋 Author

**Frank (Francis Olum)** — [GitHub Profile](https://github.com/frankTheCodeBoy)  
Full-Stack Developer | API Architect | Middleware Enthusiast

📧 Email: Olumfrank48@gmail.com  
📱 Tel: +254 734 633 607

---

