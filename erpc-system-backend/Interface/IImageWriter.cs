using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace erpc_system_backend.Interface
{

    public interface IImageWriter 
    {
        Task<string> UploadImage (IFormFile file);
    }
}