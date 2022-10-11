using BulkyBookWeb.Models;

namespace BulkyBookWeb.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(new List<Customer>()
                    {
                        new Customer()
                        {
                            Name = "Natasha Nice",
                            Email = "natanice@gmail.com",
                            Phone = "96385214"
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Kiwi",
                            Quantity = 50
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.CustomersProducts.Any())
                {

                    context.CustomersProducts.AddRange(new List<CustomerProduct>()
                    {
                        new CustomerProduct()
                        {
                            ProductId = 1,
                            CustomerId = 1
                        },
                        new CustomerProduct()
                        {
                            ProductId = 1,
                            CustomerId = 2
                        },
                        new CustomerProduct()
                        {
                            ProductId = 2,
                            CustomerId = 2
                        },
                        new CustomerProduct()
                        {
                            ProductId = 2,
                            CustomerId = 1
                        }
                    });


                    context.SaveChanges();
                }
            }
        }

    }
}
