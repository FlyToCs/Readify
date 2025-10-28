using Readify.Domain.CategoryAgg.DTOs;

namespace Readify.Domain.CategoryAgg.Contracts.RepositoryContracts;

public interface ICategoryRepository
{
    void Create(string name, string description);
    List<GetCategoryDto> GetPopularCategories(int count);
}