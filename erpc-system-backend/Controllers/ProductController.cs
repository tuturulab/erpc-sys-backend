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
    public class ProductController : ControllerBase
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
        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var Products = await _context.Products.ToListAsync();

            return new JsonResult (Products) {StatusCode = (int)HttpStatusCode.OK}; 
        }

        //GET Products from a single company
        [HttpGet("company/{id}/products")]
        public async Task<JsonResult> GetAllFromCompanie( int id )
        {
            var Products = await _context.Products
                .Where(t => t.Company.CompanyId == id  )
                .ToListAsync();

            return new JsonResult (Products) {StatusCode = (int)HttpStatusCode.OK}; 
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
        public async Task<JsonResult> Post([FromForm] ProductHelper product, int id)
        {   
            //Viewmodel validations
            if (!ModelState.IsValid)
            {
                return new JsonResult ( ModelState ) {StatusCode = (int)HttpStatusCode.BadRequest}; 
            }

            var company = await _context.Companies.FindAsync(id);

            if (company == null) 
            {
                return new JsonResult 
                    ( "Company doesn't exist or has been deleted" ) 
                    {StatusCode = (int)HttpStatusCode.NotFound}; 
            } 
            
             //Creating the entity
            var _product = new Product()
            {
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                Company = company,
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

            return new JsonResult( _product ) { StatusCode = (int)HttpStatusCode.OK };

        }

        // PUT api/values/5
        [HttpPut("company/{id}/products/{id2}")]
        public async Task<JsonResult> Put(int id, int id2, [FromBody] ProductHelper product)
        {
             //Viewmodel validations
            if (!ModelState.IsValid)
            {
                return new JsonResult ( ModelState ) {StatusCode = (int)HttpStatusCode.BadRequest}; 
            }

            var company = await _context.Companies.FindAsync(id);

            if (company == null) 
            {
                return new JsonResult 
                    ( "Company doesn't exist or has been deleted" ) 
                    {StatusCode = (int)HttpStatusCode.NotFound}; 
            } 
            
            var _product = await _context.Products.FindAsync(id2);

            if (_product == null) 
            {
                 return new JsonResult 
                    ( "Product doesn't exist or has been deleted" ) 
                    {StatusCode = (int)HttpStatusCode.NotFound}; 
            }
            
            if (_product.Company.CompanyId != company.CompanyId ) 
            {
                return new JsonResult 
                    ( "You dont have the rights for this" ) 
                    {StatusCode = (int)HttpStatusCode.Forbidden }; 
            }

            //Editing the entity
            
            _product.Description = product.Description;
            _product.Name  =  product.Name;
            _product.Price = product.Price;
            _product.Stock = product.Stock;
            

            //Finally add

            await _context.SaveChangesAsync();

            return new JsonResult( _product ) { StatusCode = (int)HttpStatusCode.OK };

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //It'LL NOT DELETE
        }
    }
}
