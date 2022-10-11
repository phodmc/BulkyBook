using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{

    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Customer> objCustomerList = _db.Customers;
            return View(objCustomerList);
        }

        // Get - return the create new customer form
        public IActionResult Create()
        {
            return View();
        }

        // Post - Adds new customer to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer obj)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Customer " + obj.Name + " created successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        // 
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // Customer customer = _db.Customers.SingleOrDefault(x => x.Id == id);
            // Customer customer = _db.Customers.FirstOrDefault(x => x.Id == id);
            var customer = _db.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer obj)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Customer " + obj.Name + " updated successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // Customer customer = _db.Customers.SingleOrDefault(x => x.Id == id);
            // Customer customer = _db.Customers.FirstOrDefault(x => x.Id == id);
            var customer = _db.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
            // _db.Customers.Remove(customer);
            // _db.SaveChanges();
            // return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(Customer obj)
        {
            var customerName = obj.Name;
            _db.Customers.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Customer " + customerName + " deleted successfully";
            return RedirectToAction("Index");
        }


    }
}
