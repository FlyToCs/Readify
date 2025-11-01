using Readify.Domain.CategoryAgg.DTOs;

namespace Readify.Domain.CategoryAgg.Contracts.RepositoryContracts;

public interface ICategoryRepository
{
    int Create(string name, string description , int userId);
    List<GetCategoryDto> GetPopularCategories(int count);
    List<GetCategoryDto> GetCategories();
}