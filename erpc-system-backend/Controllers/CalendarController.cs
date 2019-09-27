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

namespace erpc_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ErpcDbContext _context;
        //private readonly UserManager<AppUser> _userManager;

        public CalendarController(ErpcDbContext context)
        {
            _context = context;
        }

        /* 
        //GET Events from a single company in a month
        [HttpGet("company/{id}/calendar")]
        public async Task<JsonResult> GetAllFromCompanie( int id )
        {
            string date = HttpContext.Request.Query["date"].ToString();

            

           

            //return new JsonResult (Events) {StatusCode = (int)HttpStatusCode.OK}; 
        }
        */
        
       
        

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //It'LL NOT DELETE
        }
    }
}
