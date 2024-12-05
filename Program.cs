using Microsoft.EntityFrameworkCore;
using EmployeeManagementApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext with SQL Server configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Production Error Handling
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HTTP Strict Transport Security for production
}

// Enforce HTTPS in production
app.UseHttpsRedirection();
app.UseRouting();

// Enable authorization middleware (if needed)
app.UseAuthorization();

// Configure default routing and map static assets
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Add support for serving static files (if you have assets like CSS, JS, images)
app.MapStaticAssets();

// Run the application
app.Run();
