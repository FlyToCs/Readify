

using Microsoft.AspNetCore.Http;

namespace Readify.Domain.Core.File.Services
{
    public interface IFileService
    {
        public string Upload(IFormFile file, string folder);
        public void Delete(string fileName);
    }
}
