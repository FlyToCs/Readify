
using Readify.Domain.Core._common.Entities;
using Readify.Domain.Core.Book.DTOs;

namespace Readify.Domain.Core.Book.Services;

public interface IBookService
{
    void Create(CreateBookDto createBookDto);
    List<GetBookDto> GetRecentlyBooks(int count);
    List<GetBookDto> GetBooks();
    void Delete(int bookId);
    GetBookDto GetBookById(int id);
    Result<bool> Update(int bookId, UpdateBookDto bookInfo);
    int BookCount();
}