using Readify.Domain.Core.Book.DTOs;

namespace Readify.Domain.Core.Book.Data;

public interface IBookRepository
{
    int Create(CreateBookDto createBookDto);
    List<GetBookDto> GetRecentlyBooks(int count);
    List<GetBookDto> GetBooks();
    void Delete(int bookId);
    GetBookDto? GetBookById(int id);
    bool Update(int bookId, UpdateBookDto bookInfo);
    GetBookWithImgsDto? GetBookWithImgsById(int id);
    List<BookImgDto> GetBookImgsByBookId(int bookId);
    int BookCount();
}