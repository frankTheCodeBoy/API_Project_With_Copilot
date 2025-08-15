# 📘 `README.md` — User Management API

```markdown
# 🧑‍💻 User Management API

A secure, full-stack-ready ASP.NET Core Web API for managing users, built with custom middleware for error handling, authentication, and logging. Designed for hands-on learning and production-grade practices.

---

## 🚀 Features

- ✅ Custom middleware pipeline:
  - `ErrorHandlingMiddleware` – catches and formats exceptions
  - `AuthenticationMiddleware` – validates bearer tokens with selective bypass
  - `LoggingMiddleware` – logs request/response data
- 🔐 Token-based authentication
- 🧪 Swagger UI for testing endpoints
- 📦 Modular structure for easy extension

---

## 🧱 Middleware Overview

### 🔐 `AuthenticationMiddleware.cs`

```csharp
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace UserManagementAPI.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLower();

            var exemptPaths = new[]
            {
                "/", "/swagger", "/swagger/index.html", "/swagger/v1/swagger.json", "/health"
            };

            if (exemptPaths.Any(p => path.StartsWith(p)))
            {
                await _next(context);
                return;
            }

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?
                .Split(" ").Last() ?? string.Empty;

            if (string.IsNullOrEmpty(token) || token != "your-secure-token")
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            await _next(context);
        }
    }
}
```

---

## ⚙️ `Program.cs`

```csharp
using UserManagementAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Register services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🚀 Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🧱 Custom Middleware Pipeline (order matters!)
app.UseMiddleware<ErrorHandlingMiddleware>();       // 1️⃣ Catch exceptions
app.UseMiddleware<AuthenticationMiddleware>();      // 2️⃣ Validate tokens
app.UseMiddleware<LoggingMiddleware>();             // 3️⃣ Log requests/responses

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.Run();
```

---

## 🧪 Testing the API

### 🔹 Using Postman or curl

Send a request with a valid token:

```http
GET https://localhost:5182/api/users
Authorization: Bearer your-secure-token
```

### 🔸 Unauthorized Access

- No token → `401 Unauthorized`
- Wrong token → `401 Unauthorized`
- Swagger and root (`/`) → ✅ Allowed without token

---

## 📁 Folder Structure

```UserManagementAPI/
├── Controllers/
├── Middleware/
│   ├── AuthenticationMiddleware.cs
│   ├── ErrorHandlingMiddleware.cs
│   └── LoggingMiddleware.cs
├── Program.cs
└── README.md
```

---

## 📚 Notes

- Replace `"your-secure-token"` with a secure value or integrate JWT for production.
- Customize `exemptPaths` to allow public endpoints.
- Use this project as a foundation for full-stack integration with Blazor or other frontends.

---

## 🛠️ Author & Credits

Built by **Frank** with support from Microsoft Copilot 🤝  
Part of the Microsoft Full-Stack Development course on Coursera.```

---
