using Readify.Domain.BookAgg.Contracts.RepositoryContracts;
using Readify.Domain.BookAgg.Contracts.ServiceContracts;
using Readify.Domain.FileAgg;
using System.Reflection;
using Readify.Domain.BookAgg.DTOs;

namespace Readify.Services;

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