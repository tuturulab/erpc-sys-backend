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
            int companyId = int.Parse(GetTokenReadable().GetCompanyId());

            //var products = await _context.Products.Where(p => p.Account.AccountId == companyId).ToListAsync();
            //var products = await _context. .ToListAsync();

            var sales = await _context.Sales.ToListAsync();


            return new JsonResult (sales) {StatusCode = (int)HttpStatusCode.OK}; 
        }

 
        // POST product of company
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ProductHelper product)
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
            var _product = new Product()
            {
                ProductId = product.Id,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                Account = company,
                Stock = product.Stock,
            };

            if (product.Picture != null)
            {
                string picture = await _imageHandler.UploadImage(product.Picture);
                _product.Picture = picture;
            }
            else
            {
                _product.Picture = "productdefault.png";
            }

            //Finally add
            await _context.Products.AddAsync(_product);

            await _context.SaveChangesAsync();

            return Ok();

        }


    }
}