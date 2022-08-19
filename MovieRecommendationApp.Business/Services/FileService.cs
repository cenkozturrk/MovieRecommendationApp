//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using MovieRecommendationApp.DataAccess.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MovieRecommendationApp.Business.Services
//{
//    public class FileService : IFileService
//    {
//        readonly IWebHostEnvironment _webHostEnvironment;

//        public FileService(IWebHostEnvironment webHostEnvironment)
//        {
//            _webHostEnvironment = webHostEnvironment;
//        }

//        public async Task<bool> CopyFileAsync(string path, IFormFile file)
//        {
//            try
//            {
//                await using FileStream fileStream = new(path,
//                FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
//                return true;
//            }
//            catch (Exception ex)
//            {                
//                throw ex;
//            }
//        }

//        public Task<string> FileRenameAsync(string fileName)
//        {
//             throw new NotImplementedException();
//        }

//        public async Task<List<(string fileName, string path)>> UploadAsync(string patch, IFormFileCollection files)
//        {
//            // Kombinleme işlemi...
//            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, patch);

//            // Eger bu path yoksa yani uploadPath e karsı bir pathin yoksa gir oluştur.
//            if (!Directory.Exists(uploadPath))
//                Directory.CreateDirectory(uploadPath);


//            List<(string fileName, string path)> datas =new();
//            List<bool> results = new();
//            foreach (IFormFile file in files)
//            {
//                string fileNewName = await FileRenameAsync(file.FileName);

//                bool result = await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
//                datas.Add((fileNewName, $"{uploadPath}\\{ fileNewName}"));
//                results.Add(result);
//            }

//            if (results.TrueForAll(r => r.Equals(true)))
//                return datas;

//            return null;
//        }
//    }
//}
