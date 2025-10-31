using Readify.Domain.BookAgg.Contracts.RepositoryContracts;
using Readify.Domain.CategoryAgg.Contracts.RepositoryContracts;
using Readify.Domain.CategoryAgg.Contracts.ServiceContracts;
using Readify.Domain.CategoryAgg.DTOs;

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
    public List<GetCategoryDto> GetCategories()
    {
        return categoryRepository.GetCategories();
    }
}