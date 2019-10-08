using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore;
using erpc_system_backend.Models;
using erpc_system_backend.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace erpc_system_backend 
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RrhhController : TuturuControllerBase
    {

        private readonly ErpcDbContext _context;

        public RrhhController(ErpcDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            int companyId = int.Parse(GetTokenReadable().GetCompanyId());

            var interviews = await _context.Interviews.Where(e => e.Account.AccountId == companyId).ToListAsync();

            return (interviews != null) ? new JsonResult(interviews) {StatusCode = (int)HttpStatusCode.OK}
                : new JsonResult("No interviews") {StatusCode = (int)HttpStatusCode.NoContent};
        }

        public async Task<IActionResult> SetfromInterview(int id)
        {
            int companyId = int.Parse(GetTokenReadable().GetCompanyId());

            //Move employee from interview to employee
            //Get interview entitie
            var selected = _context.Interviews.FirstOrDefault(e => e.InterviewId == id);
            

            var toInsert = new Employee() 
            {
                Name = selected.FullName,
                DocumentNumber = selected.DocumentNumber,
                Email = selected.Email
            };

            await _context.Employees.AddAsync(toInsert);
            await _context.SaveChangesAsync();

            return Ok();
            
        }

        
    }
}