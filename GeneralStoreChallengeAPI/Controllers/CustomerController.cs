using GeneralStoreChallengeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GeneralStoreChallengeAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ApplicationDbContext _customersContext = ApplicationDbContext.Create();

        [HttpPost]
        public async Task<IHttpActionResult> PostTransaction([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customersContext.Customers.Add(customer);
                int changecount = await _customersContext.SaveChangesAsync();

                return Ok("Customer Created!");
            }

            return BadRequest(ModelState);
        }

        //Get All
        [HttpGet]
        public async Task<IHttpActionResult> GetAllCustomers()
        {
            var customers = await _customersContext.Customers.ToListAsync();

            return Ok(customers);
        }
        //Get by Id
        [HttpGet]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {
            Customer customer = await _customersContext.Customers.FindAsync(id);

            if (customer != null)
            {
                return Ok(customer);
            }

            return NotFound();
        }
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCustomerById([FromUri] int id)
        {
            Customer customer = await _customersContext.Customers.FindAsync(id);
            if (customer is null)
                return NotFound();

            _customersContext.Customers.Remove(customer);

            if(await _customersContext.SaveChangesAsync() == 1)
            {
                return Ok("The Customer was Removed.");
            }
            return InternalServerError();
        }
    }
}
