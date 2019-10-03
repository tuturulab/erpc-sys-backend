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

namespace erpc_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CalendarController : TuturuControllerBase
    {
        private readonly ErpcDbContext _context;
        //private readonly UserManager<AppUser> _userManager;

        public CalendarController(ErpcDbContext context)
        {
            _context = context;
        }

        //GET Events from a single company in a month
        [HttpGet]
        public async Task<JsonResult> GetAllFromCompanie()
        {
            string date = "";
            try {
                date = HttpContext.Request.Query["date"].ToString();
            } catch (Exception e) {
                new JsonResult (e.Message) {StatusCode = (int)HttpStatusCode.Unauthorized }; 

            }
            

            int companyId = int.Parse(GetTokenReadable().GetCompanyId());

            var Month = Convert.ToDateTime(date);
            

            var MyEvents = await _context.Events
                .Where(t => t.Company.AccountId == companyId )
                .Where(t => t.start.Month == Month.Month && t.start.Year == Month.Year )
                .ToListAsync();

            return new JsonResult (MyEvents) {StatusCode = (int)HttpStatusCode.OK}; 
        }

        [HttpPost() ]
        public async Task <JsonResult> Post ([FromBody] EventHelper myEvent ) 
        {
            int companyId = int.Parse(GetTokenReadable().GetCompanyId());

            //Viewmodel validations
            if (!ModelState.IsValid)
            {
                return new JsonResult(ModelState) { StatusCode = (int)HttpStatusCode.BadRequest };
            }

            var company = await _context.Accounts.FindAsync(companyId);

            //Creating the entity
            var _event = new Event()
            {
                description = myEvent.description,
                title = myEvent.title,
                start = myEvent.start??DateTime.Now ,
                end = myEvent.end??DateTime.Now.AddDays(1) ,
                Company = company
            };

            var newEvent = await _context.Events.AddAsync(_event);
            await _context.SaveChangesAsync();

            return new JsonResult (newEvent) {StatusCode = (int)HttpStatusCode.OK}; 
        }

    }
}
