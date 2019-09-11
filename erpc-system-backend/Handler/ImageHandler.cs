using System.Threading.Tasks;
using erpc_system_backend.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace erpc_system_backend.Handler 
{
    public interface IImageHandler 
    {
        Task<string> UploadImage (IFormFile file);
    }
    
    public class ImageHandler : IImageHandler 
    {
        private readonly IImageWriter _imageWriter;

        public ImageHandler (IImageWriter imageWriter) 
        {
            _imageWriter = imageWriter;
        }

        public async Task<string> UploadImage (IFormFile file)
        {
            var result = await _imageWriter.UploadImage(file);

            return result;
        }
    }
}