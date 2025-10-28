using Readify.Domain.BookAgg.DTOs;

namespace Readify.Domain.BookAgg.Contracts.ServiceContracts;

public interface IBookService
{
    void Create(CreateBookDto createBookDto);
    List<GetBookDto> GetRecentlyBooks(int count);
}