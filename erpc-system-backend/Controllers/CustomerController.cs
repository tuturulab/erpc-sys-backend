﻿using System;
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
    public class CustomerController : Controller
    {
        private readonly ErpcDbContext _context;

        public CustomerController(ErpcDbContext context)
        {
            _context = context;
            
        }

        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var Customer = await _context.Customers.ToListAsync();

            return new JsonResult(Customer) { StatusCode = (int)HttpStatusCode.OK };
        }

        [HttpGet("account/{id}/customers")]
        public async Task<JsonResult> GetAllFromPlan(int id)
        {
            var Customers = await _context.Customers
                .Where(t => t.Account.AccountId == id)
                .ToListAsync();

            return new JsonResult(Customers) { StatusCode = (int)HttpStatusCode.OK };
        }

        [HttpGet("{id}")]
        public async Task<JsonResult> Detail(int id)
        {
            var Customer = await _context.Customers.FindAsync(id);

            if (Customer == null)
            {
                return new JsonResult
                    ("Company doesn't exist or has been deleted")
                { StatusCode = (int)HttpStatusCode.NotFound };
            }
            return new JsonResult(Customer) { StatusCode = (int)HttpStatusCode.OK };
        }


        [HttpPost("plan/{id}/accounts")]
        public async Task<JsonResult> Post([FromBody] CustomerHelper customer, int id)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(ModelState) { StatusCode = (int)HttpStatusCode.BadRequest };
            }

            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return new JsonResult
                    ("Company doesn't exist or has been deleted")
                { StatusCode = (int)HttpStatusCode.NotFound };
            }

            var _customer = new Customer()
            {
                Name = customer.Name,
                Email = customer.Email,
                Document = customer.Document,
                Cellphone = customer.Cellphone,
            };

            await _context.Customers.AddAsync(_customer);

            await _context.SaveChangesAsync();

            return new JsonResult(_customer) { StatusCode = (int)HttpStatusCode.OK };
        }

        [HttpPut("account/{id}/customers/{id2}")]
        public async Task<JsonResult> Put(int id, int id2, [FromBody] CustomerHelper customer)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(ModelState) { StatusCode = (int)HttpStatusCode.BadRequest };
            }

            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return new JsonResult
                    ("Plan doesn't exist or has been deleted")
                { StatusCode = (int)HttpStatusCode.NotFound };
            }

            var _customer = await _context.Customers.FindAsync(id2);

            if (_customer == null)
            {
                return new JsonResult
                    ("Account doesn't exist or has been deleted")
                { StatusCode = (int)HttpStatusCode.NotFound };
            }

            if (_customer.Account.AccountId != account.AccountId)
            {
                return new JsonResult
                    ("You dont have the rights for accesing this")
                { StatusCode = (int)HttpStatusCode.Forbidden };
            }

            _customer.Name = customer.Name;
            _customer.Document = customer.Document;
            _customer.Cellphone = customer.Cellphone;
            _customer.Email = customer.Email;


            await _context.SaveChangesAsync();
            return new JsonResult(_customer) { StatusCode = (int)HttpStatusCode.OK };
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //It'LL NOT DELETE
        }
    }
}