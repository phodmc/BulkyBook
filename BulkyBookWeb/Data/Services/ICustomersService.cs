using BulkyBookWeb.Models;

namespace BulkyBookWeb.Data.Services
{
    public interface ICustomersService
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        void Add(Customer customer);
        Customer Update(int id, Customer newCustomer);
        Customer Delete(int id);
    }
}
