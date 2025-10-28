using Readify.Domain.BookAgg.Contracts.RepositoryContracts;
using Readify.Domain.BookAgg.Contracts.ServiceContracts;
using Readify.Domain.BookAgg.DTOs;

namespace Readify.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public void Create(string name, string description)
    {
        categoryRepository.Create(name, description);
    }

    public List<GetCategoryDto> GetPopularCategories(int count)
    {
        return categoryRepository.GetPopularCategories(count);
    }
}