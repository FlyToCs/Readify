using Readify.Domain.BookAgg.DTOs;

namespace Readify.Domain.BookAgg.Contracts.RepositoryContracts;

public interface ICategoryRepository
{
    void Create(string name, string description);
    List<GetCategoryDto> GetPopularCategories(int count);
}