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
    public class ProductController : TuturuControllerBase
    {
        private readonly ErpcDbContext _context;
        //private readonly UserManager<AppUser> _userManager;

        private readonly IImageHandler _imageHandler;
        public ProductController(ErpcDbContext context, IImageHandler imageHandler)
        {
            _context = context;
            _imageHandler = imageHandler;
        }

        // GET api/values
        // ECOMMERCE
        [HttpGet("all")]
        public async Task<JsonResult> GetAll()
        {
            int companyId = int.Parse(GetTokenReadable().GetCompanyId());

            var products = await _context.Products.Where(p => p.Account.AccountId == companyId).ToListAsync();

            return new JsonResult (products) {StatusCode = (int)HttpStatusCode.OK}; 
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> GetEcomproducts()
        {
            var ecomProducts = await _context.Products.Where(p => p.Ecommerce == true).ToListAsync();

            return new JsonResult(ecomProducts) { StatusCode = (int)HttpStatusCode.OK };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Detail(int id)
        {
            var Product = await _context.Products.FindAsync(id);
        
            if (Product == null) 
            {
                 return new JsonResult 
                    ( "Company doesn't exist or has been deleted" ) 
                    {StatusCode = (int)HttpStatusCode.NotFound}; 
            }

            return new JsonResult (Product) {StatusCode = (int)HttpStatusCode.OK}; 
            
        }

        // POST product of company
        [HttpPost("company/{id}/products")]
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
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                Account = company,
                Stock = product.Stock
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

        // PUT api/values/5
        [HttpPut("company/products/{id2}")]
        public async Task<IActionResult> Put(int id2, [FromBody] ProductHelper product)
        {
            //Viewmodel validations
            if (!ModelState.IsValid)
            {
                return new JsonResult(ModelState) { StatusCode = (int)HttpStatusCode.BadRequest };
            }

            int companyId = int.Parse(GetTokenReadable().GetCompanyId());

            var company = await _context.Accounts.FindAsync(companyId);

            if (company == null)
            {
                return new JsonResult
                    ("Company doesn't exist or has been deleted")
                { StatusCode = (int)HttpStatusCode.NotFound };
            }

            var _product = await _context.Products.FindAsync(id2);

            if (_product == null)
            {
                return new JsonResult
                   ("Product doesn't exist or has been deleted")
                { StatusCode = (int)HttpStatusCode.NotFound };
            }

            //Editing the entity

            _product.Description = product.Description;
            _product.Name = product.Name;
            _product.Price = product.Price;
            _product.Stock = product.Stock;

            //Finally add

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