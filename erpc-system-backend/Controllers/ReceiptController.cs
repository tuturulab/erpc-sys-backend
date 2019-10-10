using DinkToPdf;
using DinkToPdf.Contracts;
using erpc_system_backend.Classes;
using erpc_system_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace erpc_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly ErpcDbContext _context;
 
        public ReceiptController(ErpcDbContext context)
        {
            _context = context;
        }

        
        [HttpGet("{id}")]
        public async Task< FileContentResult > Receipt(int id)
        {
            var client = new HttpClient();

            var compra = await _context.Sales
            .Include(co => co.Customer )
             
            .Include(z=> z.SpecsProducts )
            .ThenInclude (y=> y.Product)

            .FirstOrDefaultAsync( x=> x.SaleId == id);


            //return compra.Customer.CustomerId.ToString() ;

            var items = new List<ProductRecibos> ();

            foreach (var i in compra.SpecsProducts ) 
            {
                var hola = new ProductRecibos();

                hola.name = i.Product.Name;
                hola.description = i.Product.Description;
                hola.quantity = 1;
                hola.unit_cost = i.Product.Price;

                items.Add(hola);
            }



            var model = new{
                logo = "https://scontent.fmga2-1.fna.fbcdn.net/v/t1.0-9/70189104_111141573614713_3779271792539992064_n.png?_nc_cat=109&_nc_oc=AQng1UNS37kFPG0BQRSGEjrQn-DTubbhqnpJxdpqm2Cc1LUruMk03KOPRfRm4dP3x7E&_nc_ht=scontent.fmga2-1.fna&oh=58a992262204e952e30ab7e56a52549b&oe=5E3D788D" ,
                to = compra.Customer.Name ,
                number = compra.Customer.Cellphone,
                notes = "Gracias por su compra!" ,
                header = "Tuturu Labs",
                items = items
            };
            var json = JsonConvert.SerializeObject(model);



            var location_content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://invoice-generator.com", location_content);

            //var contentStream = await content.ReadAsStreamAsync(); // get the actual content stream
            //return contentStream;

            //var message = Request.CreateResponse(HttpStatusCode.OK);
            //message.Content = response.Content;
            //return File(contentStream, "application/pdf");
            return new FileContentResult(await response.Content.ReadAsByteArrayAsync(), response.Content.Headers.ContentType.MediaType);

            //var responseString = await response.Content.ReadAsStringAsync();

           //return (responseString) ;
        }
 
        
    }
}