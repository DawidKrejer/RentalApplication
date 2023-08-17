using Microsoft.EntityFrameworkCore;
using RentalApplication.Models;

namespace RentalApplication.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set;}
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Rental> Rental { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-G14VAC0; Initial Catalog=Rent; User Id=sa; password=student; TrustServerCertificate= True");
        }
    }
}
