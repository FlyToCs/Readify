using Readify.Domain.CategoryAgg.DTOs;

namespace Readify.Domain.CategoryAgg.Contracts.ServiceContracts;

public interface ICategoryService
{
    void Create(string name, string description);
    List<GetCategoryDto> GetPopularCategories(int count);
    List<GetCategoryDto> GetCategories();

}