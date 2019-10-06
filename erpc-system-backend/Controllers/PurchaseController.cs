using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using erpc_system_backend.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace erpc_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : TuturuControllerBase
    {
        private readonly IHostingEnvironment _host;

        public PurchaseController(IHostingEnvironment host)
        {
            _host = host;
        }

        [HttpGet("getPdf64Test")]
        public JsonResult GetPdf64()
        {
            Document doc = new Document();
            string path = _host.WebRootPath;

            Span<int> numbers = new int[] { 3, 14, 15, 92, 6 };

            using (var stream = new FileStream(path + "/Doc1.pdf", FileMode.Create))
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, stream);

                doc.Open();
                numbers.ToArray().AsEnumerable().ToList().ForEach(e => doc.Add(new Paragraph("PAGE1,,,: " + e.ToString())));
                doc.NewPage();
                numbers.ToArray().AsEnumerable().ToList().ForEach(e => doc.Add(new Paragraph("PAGE2,,,: " + e.ToString())));
                doc.Close();
            }

            var pdfBytes = System.IO.File.ReadAllBytes(path + "/Doc1.pdf");

            string docBase64 = "data:aplication/pdf;base64," + Convert.ToBase64String(pdfBytes);

            return new JsonResult(new PdfDataHelper { SomeInfo = "testing", Pdf64 = docBase64}) 
            { StatusCode = (int)HttpStatusCode.OK };
        }

    }

    class PdfDataHelper
    {
        public string SomeInfo { get; set; }
        public string Pdf64 { get; set; }
    }
}