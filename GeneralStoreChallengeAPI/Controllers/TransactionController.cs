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
    public class TransactionController : ApiController
    {
        private readonly ApplicationDbContext _transactionContext = new ApplicationDbContext();
        //Post
        [HttpPost]
        public async Task<IHttpActionResult> PostTransaction([FromBody] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _transactionContext.Transactions.Add(transaction);
                int changecount = await _transactionContext.SaveChangesAsync();

                return Ok("Transaction Created!");
            }

            return BadRequest(ModelState);
        }

        //Get All
        [HttpGet]
        public async Task<IHttpActionResult> GetAllTransactions()
        {
            var transactions = await _transactionContext.Transactions.ToListAsync();
            
            return Ok(transactions);
        }
        //Get by Id
        [HttpGet]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {
            Transaction transaction = await _transactionContext.Transactions.FindAsync(id);

            if(transaction != null)
            {
                return Ok(transaction);
            }

            return NotFound();

        }
    }
}
