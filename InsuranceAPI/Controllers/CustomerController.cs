using InsuranceAPI.Data;
using InsuranceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsuranceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomerDbContext customerDbContext;
        public CustomerController(CustomerDbContext customerDbContext)
        {
            this.customerDbContext=customerDbContext;
        }




        //get all customers
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers=await customerDbContext.Customers.ToListAsync();
            return Ok(customers);
        }

        //get a single customer
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCustomers")]
        public async Task<IActionResult> GetCustomers([FromRoute] Guid id)
        {
            var customers = await customerDbContext.Customers.FirstOrDefaultAsync(x=>x.customer_id==id);
            if (customers != null)
            {
                return Ok(customers);
            }
            return NotFound("Customer not found");
        }


        //get a single customer
        [HttpPost]
       
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            customer.customer_id = Guid.NewGuid();
           await customerDbContext.Customers.AddAsync(customer);
            await customerDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomers), new { id = customer.customer_id }, customer);
        }

    }
}
