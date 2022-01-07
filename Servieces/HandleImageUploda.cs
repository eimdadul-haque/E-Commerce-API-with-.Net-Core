using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop_API.Servieces
{
    public class HandleImageUploda
    {
       private static HandleImageUploda obj = new HandleImageUploda();
        
       private  HandleImageUploda() { }

        public static HandleImageUploda getImgObject()
        {
            return obj;
        }

        public async Task<string> ImgHandel(IFormFile file, IWebHostEnvironment env)
        {

            if (file != null )
            {
                string imageName = new string(Path.GetFileNameWithoutExtension(file.FileName).Take(5).ToArray()).Replace(" ", "-");
                string imgExtention = Path.GetExtension(file.FileName);
                imageName = imageName + DateTime.Now.ToString("yy-MM-dd-hh-mm-ss-ff") + imgExtention;

                string path = Path.Combine(env.ContentRootPath, "Images", imageName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                    return imageName;
                }
            }
            else
            {
                return "default.jpg";
            }
            
        } 
    }
}
