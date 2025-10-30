using Readify.Domain.BookAgg.Contracts.RepositoryContracts;
using Readify.Domain.BookAgg.Contracts.ServiceContracts;

namespace Readify.Services;

public class BookImgService(IBookImgRepository bookImgRepository) : IBookImgService
{
    public void Create(string imgUrl, bool isMainImg, int bookId)
    {
        bookImgRepository.Create(imgUrl, isMainImg, bookId);
    }
}