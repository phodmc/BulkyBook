using BulkyBookWeb.Models;

namespace BulkyBookWeb.Data.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ApplicationDbContext _db;
        public CustomersService(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            var result = _db.Customers;
            return result;
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Update(int id, Customer newCustomer)
        {
            throw new NotImplementedException();
        }
    }
}
