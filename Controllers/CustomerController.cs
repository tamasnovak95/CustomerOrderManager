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

       [HttpPut("{id}")]
public async Task<IActionResult> UpdateCustomer(int id, Customer updatedCustomer)
{
    var customer = await _context.Customers.FindAsync(id);
    if (customer == null)
        return NotFound();

    customer.Name = updatedCustomer.Name;
    customer.Email = updatedCustomer.Email;
    customer.Phone = updatedCustomer.Phone;

    await _context.SaveChangesAsync();
    return NoContent(); // 204 No Content = success, no return body
}

        [HttpDelete("{id}")]
public async Task<IActionResult> DeleteCustomer(int id)
{
    var customer = await _context.Customers.FindAsync(id);
    if (customer == null)
        return NotFound();

    _context.Customers.Remove(customer);
    await _context.SaveChangesAsync();
    return NoContent();
}
       
    }

    
}