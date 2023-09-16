using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace _0_Framework.Application
{
    public interface IFileUploader
    {
        List<string> UploadFile(List<IFormFile> files, string path);
        string Upload(IFormFile file, string path);
        string UploadIcon(IFormFile file, string path);
        string UploadMyPath(IFormFile file, string path);
    }

    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string UploadMyPath(IFormFile file, string path)
        {
            if (file == null) return "";

            var directoryPath = $"{_webHostEnvironment.WebRootPath}\\ViewPicture\\{path}";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var fileName = $"{CodeGenerators.FileCode()}-{file.FileName}";
            var filePath = $"{directoryPath}//{fileName}";
            using var output = File.Create(filePath);
            file.CopyTo(output);
            return $"{path}/{fileName}";
        }

        public string Upload(IFormFile file, string path)
        {
            if (file == null) return "";

            var directoryPath = $"{_webHostEnvironment.WebRootPath}\\ViewPicture\\{path}";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath); 

            var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            var filePath = $"{directoryPath}//{fileName}";
            using var output = File.Create(filePath);
            file.CopyTo(output);
            return $"{path}/{fileName}";
        }
        public string UploadIcon(IFormFile file, string path)
        {
            if (file == null) return "";

            var directoryPath = $"{_webHostEnvironment.WebRootPath}\\ViewPicture\\{path}";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath); 

            var fileName = $"IconSite.ico";
            var filePath = $"{directoryPath}//{fileName}";
            using var output = File.Create(filePath);
            file.CopyTo(output);
            return $"{path}/{fileName}";
        }
        public List<string> UploadFile(List<IFormFile> files, string path)
        {
            List<string> fileNames = new List<string>();
            string fileName = "";
            string rootPath = Directory.GetCurrentDirectory() + "\\wwwroot";

            foreach (var itm in files)
            {
                fileName = Guid.NewGuid().ToString().Replace("-", "").ToLower() + Path.GetExtension(itm.FileName);
                string currentPath = rootPath + path + fileName;

                using (var fs = new FileStream(currentPath, FileMode.Create))
                {
                    itm.CopyTo(fs);
                }

                fileNames.Add(fileName);
                fileName = "";
            }

            return fileNames;
        }
    }
}
