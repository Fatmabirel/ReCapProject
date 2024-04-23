using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelperService
    {
        // Dosyayı yükler ve yüklenen dosyanın yolunu döndürür
        string Upload(IFormFile file, string root);

        // Belirtilen dosyayı siler
        void Delete(string filePath);

        // Mevcut dosyayı günceller ve güncellenen dosyanın yolunu döndürür
        string Update(IFormFile file, string filePath, string root);
    }
}

