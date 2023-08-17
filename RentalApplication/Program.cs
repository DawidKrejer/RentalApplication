using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RentalApplication.Models;

var builder = WebApplication.CreateBuilder(args);

// Dodaj serwisy do kontenera serwis�w.
builder.Services.AddControllersWithViews();

// Rejestracja ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Konfiguracja plik�w cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.Lax; // lub SameSiteMode.None, je�li to konieczne
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    // Inne opcje...
});

var app = builder.Build();

// Skonfiguruj �rodowisko deweloperskie, itp.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    // Konfiguracje dla �rodowisk produkcyjnych.
}

// Dodaj obs�ug� routingu, kontrolery, itp.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
