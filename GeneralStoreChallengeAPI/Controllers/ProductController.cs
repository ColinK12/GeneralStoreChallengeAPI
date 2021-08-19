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
    public class ProductController : ApiController
    {
        private readonly ApplicationDbContext _productContext = ApplicationDbContext.Create();

        [HttpPost]
        public async Task<IHttpActionResult> PostProduct([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _productContext.Products.Add(product);
                int changecount = await _productContext.SaveChangesAsync();

                return Ok("Product Created!");
            }

            return BadRequest(ModelState);
        }

        //Get All
        [HttpGet]
        public async Task<IHttpActionResult> GetAllTransactions()
        {
            var products = await _productContext.Products.ToListAsync();

            return Ok(products);
        }
        //Get by Id
        [HttpGet]
        public async Task<IHttpActionResult> GetById([FromUri] string SKU)
        {
            Product product = await _productContext.Products.FindAsync(SKU);

            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();

        }




    }
}
