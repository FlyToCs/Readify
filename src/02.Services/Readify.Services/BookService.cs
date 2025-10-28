using Readify.Domain.BookAgg.Contracts.RepositoryContracts;
using Readify.Domain.BookAgg.Contracts.ServiceContracts;
using Readify.Domain.BookAgg.DTOs;

namespace Readify.Services;

public class BookService(IBookRepository bookRepository) : IBookService
{

    public void Create(CreateBookDto createBookDto)
    {
        bookRepository.Create(createBookDto);
    }

    public List<GetBookDto> GetRecentlyBooks(int count)
    {
        return bookRepository.GetRecentlyBooks(count);
    }
}