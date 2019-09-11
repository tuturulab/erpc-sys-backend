using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using erpc_system_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using erpc_system_backend.Helpers;

namespace erpc_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyController : ControllerBase
    {
        private readonly ErpcDbContext _context;
        //private readonly UserManager<AppUser> _userManager;

        public CompanyController(ErpcDbContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var Companies = await _context.Companies.ToListAsync();

            return new JsonResult (Companies) {StatusCode = (int)HttpStatusCode.OK}; 
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Detail(int id)
        {
            var Company = await _context.Companies.FindAsync(id);
        
            if (Company == null) 
            {
                 return new JsonResult 
                    ( "Company doesn't exist or has been deleted" ) 
                    {StatusCode = (int)HttpStatusCode.NotFound}; 
            }

            return new JsonResult (Company) {StatusCode = (int)HttpStatusCode.OK}; 
            
        }

        // POST api/values
        [HttpPost]
        public async Task<JsonResult> Post([FromBody] CompanyHelper company)
        {   
            //Viewmodel validations
            if (!ModelState.IsValid)
            {
                return new JsonResult ( ModelState ) {StatusCode = (int)HttpStatusCode.BadRequest}; 
            }

             //Creating the entity
            var _company = new Company()
            {
               Description = company.Description,
               Name = company.Name
            };

            //Finally add
            await _context.Companies.AddAsync(_company);

            await _context.SaveChangesAsync();

            return new JsonResult( _company ) { StatusCode = (int)HttpStatusCode.OK };

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<JsonResult> Put(int id, [FromBody] CompanyHelper company)
        {
            //Viewmodel validations
            if (!ModelState.IsValid)
            {
                return new JsonResult ( ModelState ) {StatusCode = (int)HttpStatusCode.BadRequest}; 
            }

            var _company = await _context.Companies.FindAsync(id);

            //Return if error
            if (_company == null)
            {
                return new JsonResult 
                    ( "Company doesn't exist or has been deleted" ) 
                    {StatusCode = (int)HttpStatusCode.NotFound}; 

            }
            
            _company.Name = company.Name;
            _company.Description = company.Description;
            await _context.SaveChangesAsync();

            return new JsonResult( _company ) { StatusCode = (int)HttpStatusCode.OK };
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //It'LL NOT DELETE
        }
    }
}
