using Readify.Domain.CategoryAgg.DTOs;

namespace Readify.Domain.CategoryAgg.Contracts.RepositoryContracts;

public interface ICategoryRepository
{
    bool Create(string name, string description,string imgUrl, int userId);
    List<GetCategoryDto> GetPopularCategories(int count);
    List<GetCategoryDto> GetCategories();
    GetCategoryDto? GetById(int categoryId);
    string? ImgUrl(int categoryId);
    bool Delete(int categoryId);
    bool Update(int categoryId, CreateCategoryDto newCategory);
    int CategoryCount();
}