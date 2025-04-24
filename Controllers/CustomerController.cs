using Microsoft.AspNetCore.Mvc;
using CustomerOrderManager.Models;
using CustomerOrderManager.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderManager.Controllers
{



   
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

          public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

           [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

          [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = customer.Id }, customer);
        }
       

       
    }

    
}