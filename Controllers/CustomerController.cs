using Microsoft.AspNetCore.Mvc;
using CustomerOrderManager.Models;

namespace CustomerOrderManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private static List<Customer> _customers = new()
        {
            new Customer { Id = 1, Name = "Tomi", Email = "Tomi@example.com", Phone = "123-456-7890" },
            new Customer { Id = 2, Name = "Dénes", Email = "Denes@example.com", Phone = "987-654-3210" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAll() => Ok(_customers);

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            customer.Id = _customers.Count + 1;
            _customers.Add(customer);
            return CreatedAtAction(nameof(GetAll), new { id = customer.Id }, customer);
        }
    }
}