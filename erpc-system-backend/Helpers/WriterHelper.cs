using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace erpc_system_backend.Helpers
{
    public class WriterHelper 
    {
        public enum ImageFormat 
        {
            bmp,
            jpeg,
            gif,
            png,
            unknown
        }

        public static ImageFormat GetImageFormat (byte[] bytes)
        {
            var bmp = Encoding.ASCII.GetBytes("BM");
            var gif = Encoding.ASCII.GetBytes("GIF");
            var png = new byte[] { 137, 80, 78, 71};
            var jpeg = new byte[] { 255, 216, 255, 224};

            if (bmp.SequenceEqual (bytes.Take(bmp.Length) ) )
                return ImageFormat.bmp;
            
            if (gif.SequenceEqual (bytes.Take(gif.Length) ) )
                return ImageFormat.gif;

            if (png.SequenceEqual (bytes.Take(png.Length) ) )
                return ImageFormat.png;
            
            if (jpeg.SequenceEqual (bytes.Take(jpeg.Length) ) )
                return ImageFormat.jpeg;

            return ImageFormat.unknown;
        }

    }
}