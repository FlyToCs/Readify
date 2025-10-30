
using Microsoft.AspNetCore.Http;

namespace Readify.Domain.FileAgg
{
    public interface IFileService
    {
        public string Upload(IFormFile file, string folder);
        public void Delete(string fileName);
    }
}
