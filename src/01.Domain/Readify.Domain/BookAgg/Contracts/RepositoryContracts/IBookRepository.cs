using Readify.Domain.BookAgg.DTOs;

namespace Readify.Domain.BookAgg.Contracts.RepositoryContracts;

public interface IBookRepository
{
    void Create(CreateBookDto createBookDto);
    List<GetBookDto> GetRecentlyBooks(int count);

}