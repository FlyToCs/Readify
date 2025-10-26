using Readify.Domain.BookAgg.DTOs;

namespace Readify.Domain.BookAgg.Contracts.ServiceContracts;

public interface ICategoryService
{
    void Create(string name, string description);
    List<GetCategoryDto> GetPopularCategories(int count);
}