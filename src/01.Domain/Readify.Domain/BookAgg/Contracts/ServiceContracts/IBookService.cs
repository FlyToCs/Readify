using Readify.Domain._common.Entities;
using Readify.Domain.BookAgg.DTOs;

namespace Readify.Domain.BookAgg.Contracts.ServiceContracts;

public interface IBookService
{
    void Create(CreateBookDto createBookDto);
    List<GetBookDto> GetRecentlyBooks(int count);
    List<GetBookDto> GetBooks();
    void Delete(int bookId);
    GetBookDto GetBookById(int id);
    Result<bool> Update(int bookId, UpdateBookDto bookInfo);
}