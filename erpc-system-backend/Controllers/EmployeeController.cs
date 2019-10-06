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
using erpc_system_backend.Handler;
using erpc_system_backend.Utils;
using System.IdentityModel.Tokens.Jwt;

namespace erpc_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : TuturuControllerBase
    {
        private readonly ErpcDbContext _context;

        private readonly IImageHandler _imageHandler;

        public EmployeeController(ErpcDbContext context, IImageHandler imageHandler)
        {
            _context = context;
            _imageHandler = imageHandler;
        }

        // GET api/values
        // ECOMMERCE
        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            int companyId = int.Parse(GetTokenReadable().GetCompanyId());

            //var employees = await _context.Employees.Where(p => p.Account.AccountId == companyId).ToListAsync();

            var employees = await _context.Employees.ToListAsync();

            return new JsonResult (employees) {StatusCode = (int)HttpStatusCode.OK}; 
        }

        // POST employee of company
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] EmployeeHelper employee)
        {
            int companyId = int.Parse(GetTokenReadable().GetCompanyId());

            //Viewmodel validations
            if (!ModelState.IsValid)
            {
                return new JsonResult(ModelState) { StatusCode = (int)HttpStatusCode.BadRequest };
            }

            var company = await _context.Accounts.FindAsync(companyId);

            if (company == null)
            {
                return new JsonResult
                    ("Company doesn't exist or has been deleted")
                    { StatusCode = (int)HttpStatusCode.NotFound };
            }

            //Creating the entity
            var _employee = new Employee()
            {
                Name = employee.Name,
                Email = employee.Email,
                Cellphone = employee.Cellphone,
                DocumentNumber = employee.DocumentNumber,
                Description = employee.Description,
                Account = company
            };

            if (employee.Picture != null)
            {
                string picture = await _imageHandler.UploadImage(employee.Picture);
                _employee.Picture = picture;
            }
            else
            {
                _employee.Picture = "employeedefault.png";
            }


            //Finally add
            await _context.Employees.AddAsync(_employee);

            await _context.SaveChangesAsync();
        

            return Ok();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //It'LL NOT DELETE
        }
    }
}