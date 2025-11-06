using Readify.Domain._common.Entities;
using Readify.Domain.BookAgg.Contracts.RepositoryContracts;
using Readify.Domain.BookAgg.Contracts.ServiceContracts;
using Readify.Domain.BookAgg.DTOs;
using Readify.Domain.BookAgg.Entities;
using Readify.Domain.FileAgg;

using System.Reflection;

namespace Readify.Services;

public class BookService(IBookRepository bookRepository,IBookImgService bookImgService, IFileService fileService) : IBookService
{

    public void Create(CreateBookDto createBookDto)
    {
        var bookId = bookRepository.Create(createBookDto);  

        if (createBookDto.ImageFile is not null)
        {
            var fileUrl = fileService.Upload(createBookDto.ImageFile, "Books");
            bookImgService.Create(fileUrl, true, bookId);
        }
    }



    public List<GetBookDto> GetRecentlyBooks(int count)
    {
        return bookRepository.GetRecentlyBooks(count);
    }

    public List<GetBookDto> GetBooks()
    {
        return bookRepository.GetBooks();
    }

    public void Delete(int bookId)
    {
        var bookImgs = bookRepository.GetBookImgsByBookId(bookId);
        foreach (var img in bookImgs)
        {
            fileService.Delete(img.ImgUrl);
        }
        bookRepository.Delete(bookId);
    }


    public GetBookDto GetBookById(int id)
    {
        return bookRepository.GetBookById(id);
    }


    public Result<bool> Update(int bookId, UpdateBookDto bookInfo)
    {
        var existingBook = bookRepository.GetBookById(bookId);
        if (existingBook == null)
            return Result<bool>.Failure("کتاب مورد نظر پیدا نشد.");

        if (bookInfo.ImgFile != null)
        {
            if (!string.IsNullOrEmpty(existingBook.img.ImageUrl))
                bookImgService.DeleteMainImg(existingBook.img.ImageUrl, bookId);

            var fileUrl = fileService.Upload(bookInfo.ImgFile, "Books");
            bookImgService.Create(fileUrl, true, bookId);
            bookInfo.ImgUrl = fileUrl;
        }
        else
        {
            bookInfo.ImgUrl = existingBook.img.ImageUrl;

            if (string.IsNullOrEmpty(bookInfo.ImgUrl))
                return Result<bool>.Failure("کتاب باید حداقل یک عکس داشته باشد.");
        }

        var updateResult = bookRepository.Update(bookId, bookInfo);
        if (!updateResult)
            return Result<bool>.Failure("ویرایش کتاب با خطا مواجه شد.");

        return Result<bool>.Success("کتاب با موفقیت ویرایش شد.", true);
    }

    public int BookCount()
    {
        return bookRepository.BookCount();
    }
}