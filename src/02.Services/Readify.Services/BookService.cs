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
        bookRepository.Delete(bookId);
    }

    public GetBookDto GetBookById(int id)
    {
        return bookRepository.GetBookById(id);
    }
}