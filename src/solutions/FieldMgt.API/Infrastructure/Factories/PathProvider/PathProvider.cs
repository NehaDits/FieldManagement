using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace FieldMgt.API.Infrastructure.Factories.PathProvider
{
    public class PathProvider:IPathProvider
    {
        private IWebHostEnvironment _hostEnvironment;

        public PathProvider(IWebHostEnvironment environment)
        {
            _hostEnvironment = environment;
        }

        public string MapPath(string path)
        {
            string filePath = Path.Combine(_hostEnvironment.ContentRootPath, path);
            return filePath;
        }
    }
}
