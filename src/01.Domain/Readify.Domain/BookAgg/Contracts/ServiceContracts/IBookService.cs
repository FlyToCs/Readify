using Readify.Domain.BookAgg.DTOs;

namespace Readify.Domain.BookAgg.Contracts.ServiceContracts;

public interface IBookService
{
    void Create(string name, string description);
    List<GetCategoryDto> GetPopularCategories(int count);
}