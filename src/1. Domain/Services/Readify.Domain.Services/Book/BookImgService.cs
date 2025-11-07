using Readify.Domain.Core.Book.Data;
using Readify.Domain.Core.Book.Services;
using Readify.Domain.Core.File.Services;

namespace Readify.Domain.Services.Book;

public class BookImgService(IBookImgRepository bookImgRepository, IFileService fileService) : IBookImgService
{
    public void Create(string imgUrl, bool isMainImg, int bookId)
    {
        bookImgRepository.Create(imgUrl, isMainImg, bookId);
    }

    public bool DeleteMainImg(string imgUrl, int bookId)
    {
        if (string.IsNullOrEmpty(imgUrl))
            return false;

        fileService.Delete(imgUrl);
        return bookImgRepository.DeleteMainImg(imgUrl, bookId);
    }



}