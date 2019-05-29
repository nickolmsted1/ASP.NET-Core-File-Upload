using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUploadExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace FileUploadExample.Controllers
{
    public class SingleFileController : Controller
    {
        private readonly IHostingEnvironment _env;

        public SingleFileController(IHostingEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Food item)
        {
            //Either use a viewmodel or remove photoURL. URL will
            //be generated programmatically
            ModelState.Remove(nameof(Food.PhotoUrl));
            item.Id = 0; //SQL Server will generate a new ID

            if (ModelState.IsValid)
            {
                var photo = item.Photo;
                //Check file extension is a photo
                string extension = 
                       Path.GetExtension(photo.FileName);
                if (extension == ".png" || extension == ".jpg")
                {


                    //reduce photo size
                    // Use ImagSharp to resize image

                    //generate unique name to retrieve later
                    string newFileName = Guid.NewGuid().ToString();

                    //store photo on file system and reference in DB
                    if (photo.Length > 0) // Ensure file is not empty
                    {
                        string filePath = Path.Combine(_env.WebRootPath, "images", newFileName + extension);

                        // save location to database(in URL format)
                        item.PhotoUrl = "images/" + newFileName + extension;
                        // write file to file system
                        using (FileStream fs = new FileStream(filePath, FileMode.Create))
                        {
                            await photo.CopyToAsync(fs);
                        }
                    }
                }
            }

            return View();
        }
    }
}