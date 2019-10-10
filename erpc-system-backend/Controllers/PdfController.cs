using DinkToPdf;
using DinkToPdf.Contracts;
using erpc_system_backend.Classes;
using Microsoft.AspNetCore.Mvc;
using System.IO;
 
namespace erpc_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfCreatorController : ControllerBase
    {
        private IConverter _converter;
 
        public PdfCreatorController(IConverter converter)
        {
            _converter = converter;
        }
 
        
    }
}