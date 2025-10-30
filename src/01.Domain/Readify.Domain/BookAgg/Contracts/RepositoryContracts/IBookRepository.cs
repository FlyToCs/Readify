using Readify.Domain.BookAgg.DTOs;

namespace Readify.Domain.BookAgg.Contracts.RepositoryContracts;

public interface IBookRepository
{
    int Create(CreateBookDto createBookDto);
    List<GetBookDto> GetRecentlyBooks(int count);
    List<GetBookDto> GetBooks();
    void Delete(int bookId);
    GetBookDto? GetBookById(int id);

}