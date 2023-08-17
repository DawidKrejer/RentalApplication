using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RentalApplication.Models;

var builder = WebApplication.CreateBuilder(args);

// Dodaj serwisy do kontenera serwisów.
builder.Services.AddControllersWithViews();

// Rejestracja ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Konfiguracja plików cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.Lax; // lub SameSiteMode.None, jeœli to konieczne
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    // Inne opcje...
});

var app = builder.Build();

// Skonfiguruj œrodowisko deweloperskie, itp.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    // Konfiguracje dla œrodowisk produkcyjnych.
}

// Dodaj obs³ugê routingu, kontrolery, itp.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
