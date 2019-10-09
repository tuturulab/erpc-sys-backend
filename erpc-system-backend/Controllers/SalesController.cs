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
    public class SalesController : TuturuControllerBase
    {
        private readonly ErpcDbContext _context;
        //private readonly UserManager<AppUser> _userManager;

        private readonly IImageHandler _imageHandler;
        public SalesController(ErpcDbContext context, IImageHandler imageHandler)
        {
            _context = context;
            _imageHandler = imageHandler;
        }

        // GET api/values
        // ECOMMERCE
        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            //int companyId = int.Parse(GetTokenReadable().GetCompanyId());
        
            //var products = await _context.Products.Where(p => p.Account.AccountId == companyId).ToListAsync();
            //var products = await _context. .ToListAsync();

            var salesPEPEPGA = await _context.Sales.ToListAsync();            

            return new JsonResult (salesPEPEGA) {StatusCode = (int)HttpStatusCode.OK}; 
        }

 
        // POST product of company
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] SalesHelper sale)
        {
            var costumer = await _context.Customers.FindAsync (sale.CustomerId);

            var sale = new Sale() 
            {
                Date = new DateTime(),
                Type = "Contado",
                Code = "1",
                Customer = costumer,
            };


            var sale = await _context.Sales.AddAsync(sale);

            
            foreach (var i in sale.ProductsBought ) 
            {
                var product =  await _context.Products.findAsync ( sale.productBought.id );

                var productBought = new SpecsProduct() 
                {
                    Product = product , 
                    Descripcion = "hola mundo",
                    Sale = sale
                };

                await _context.SpecsProduct.AddAsync(productBought);

                await _context.SaveChangesAsync();

            }

            return Ok();

        }

    }
}