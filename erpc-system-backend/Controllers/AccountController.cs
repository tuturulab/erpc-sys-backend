using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using erpc_system_backend.Helpers;
using erpc_system_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace erpc_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ErpcDbContext _context;

        public AccountController(ErpcDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var Account = await _context.Accounts.ToListAsync();


            return new JsonResult(Account) { StatusCode = (int)HttpStatusCode.OK };
        }

        [HttpGet("plan/{id}/accounts")]
        public async Task<JsonResult> GetAllFromPlan(int id)
        {
            var Accounts = await _context.Accounts
                .Where(t => t.Plan.PlanId == id)
                .ToListAsync();

            return new JsonResult(Accounts) { StatusCode = (int)HttpStatusCode.OK };
        }

        [HttpGet("{id}")]
        public async Task<JsonResult> Detail(int id)
        {
            var Account = await _context.Accounts.FindAsync(id);

            

            if(Account == null)
            {
                return new JsonResult
                    ("Company doesn't exist or has been deleted")
                { StatusCode = (int)HttpStatusCode.NotFound };
            }
            return new JsonResult(Account) { StatusCode = (int)HttpStatusCode.OK };
        }


        [HttpPost("plan/{id}/accounts")]
        public async Task<JsonResult> Post([FromBody] AccountHelper account, int id)
        {
            //Test
            string jwt = Request.Headers["Authorize"];

            if(!ModelState.IsValid)
            {
                return new JsonResult(ModelState) { StatusCode = (int)HttpStatusCode.BadRequest };
            }

            var plan = await _context.Plans.FindAsync(id);

            if(plan == null)
            {
                return new JsonResult
                    ("Company doesn't exist or has been deleted")
                { StatusCode = (int)HttpStatusCode.NotFound };
            }

            var _account = new Account()
            {
                Features = account.Features
            };

            await _context.Accounts.AddAsync(_account);

            await _context.SaveChangesAsync();

            return new JsonResult(_account) { StatusCode = (int)HttpStatusCode.OK };
        }

        [HttpPut("plan/{id}/accounts/{id2}")]
        public async Task<JsonResult> Put(int id, int id2, [FromBody] AccountHelper account)
        {
            if(!ModelState.IsValid)
            {
                return new JsonResult(ModelState) { StatusCode = (int)HttpStatusCode.BadRequest };
            }

            var plan = await _context.Plans.FindAsync(id);

            if(plan == null)
            {
                return new JsonResult
                    ("Plan doesn't exist or has been deleted")
                { StatusCode = (int)HttpStatusCode.NotFound };
            }

            var _account = await _context.Accounts.FindAsync(id2);

            if(_account == null)
            {
                return new JsonResult
                    ("Account doesn't exist or has been deleted")
                { StatusCode = (int)HttpStatusCode.NotFound };
            }

            if(_account.Plan.PlanId != plan.PlanId)
            {
                return new JsonResult
                    ("You dont have the rights for accesing this")
                { StatusCode = (int)HttpStatusCode.Forbidden };
            }

            _account.Features = account.Features;

            await _context.SaveChangesAsync();
            return new JsonResult(_account) { StatusCode = (int)HttpStatusCode.OK };
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //It'LL NOT DELETE
        }
    }
}