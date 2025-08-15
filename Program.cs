using UserManagementAPI.Middleware; // 👈 Add this to access your middleware classes

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
app.UseMiddleware<ErrorHandlingMiddleware>();       // 1️⃣ First: catch exceptions
app.UseMiddleware<AuthenticationMiddleware>();      // 2️⃣ Second: validate tokens
app.UseMiddleware<LoggingMiddleware>();             // 3️⃣ Third: log requests/responses

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.Run();
