using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploadExample.Models
{
    public class FileHelper
    {
        /// <summary>
        /// save file to file system
        /// </summary>
        /// <param name="file">File to be saved</param>
        /// <param name="name">The unique file name to save the file as</param>
        /// <param name="path">The absolute path to save this file</param>
        /// <exception cref="ArgumentNullException">Thrown when file name is null</exception>"
        /// <returns></returns>
        public static async Task SaveFile(IFormFile file, string name, string path)
        {
            if (name is null)
                throw new ArgumentNullException($"{nameof(name)} cannot be null.")
        }
    }
}
