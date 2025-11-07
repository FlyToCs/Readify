

namespace Readify.Domain.Core.Book.Services;

public interface IBookImgService
{
    void Create(string imgUrl, bool isMainImg, int bookId);
    bool DeleteMainImg(string imgUrl, int bookId);
}