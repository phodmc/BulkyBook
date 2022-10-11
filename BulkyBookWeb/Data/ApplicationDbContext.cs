using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerProduct>().HasKey(cm => new
            {
                cm.ProductId,
                cm.CustomerId
            });

            modelBuilder.Entity<CustomerProduct>().HasOne(p => p.Product).WithMany(cm => cm.CustomerProducts).HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<CustomerProduct>().HasOne(c => c.Customer).WithMany(cm => cm.CustomerProducts).HasForeignKey(c => c.CustomerId);



            base.OnModelCreating(modelBuilder);
        }
            
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerProduct> CustomersProducts { get; set; }



    }
}
