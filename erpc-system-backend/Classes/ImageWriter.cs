using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using erpc_system_backend.Helpers;
using erpc_system_backend.Interface;
using Microsoft.AspNetCore.Http;

namespace erpc_system_backend.Classes
{
    public class ImageWriter : IImageWriter 
    {
        public async Task<string> UploadImage (IFormFile file) 
        {
            if (CheckIfImageFile(file) ) 
            {
                return await WriteFile(file);
            }

            return "Invalid image file";
        }    

        private bool CheckIfImageFile(IFormFile file) 
        {
            byte[] fileBytes;

            using (var ms = new MemoryStream() )
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return WriterHelper.GetImageFormat(fileBytes) != WriterHelper.ImageFormat.unknown;
        }

        public async Task<string> WriteFile (IFormFile file)
        {
            string fileName;

            try 
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length  - 1 ];

                fileName = Guid.NewGuid().ToString() + extension;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName  );

                using (var bits = new FileStream(path, FileMode.Create) )
                {
                    await file.CopyToAsync(bits);
                }


            } 
            catch (Exception e) 
            {
                return e.Message;
            }

            return fileName;
        }

    }
}