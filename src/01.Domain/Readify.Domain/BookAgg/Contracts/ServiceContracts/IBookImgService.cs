using Readify.Domain.BookAgg.DTOs;

namespace Readify.Domain.BookAgg.Contracts.ServiceContracts;

public interface IBookImgService
{
    void Create(string imgUrl, bool isMainImg, int bookId);
    bool DeleteMainImg(string imgUrl, int bookId);
}