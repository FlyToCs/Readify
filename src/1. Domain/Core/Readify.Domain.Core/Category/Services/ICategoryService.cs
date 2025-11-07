
using Readify.Domain.Core._common.Entities;
using Readify.Domain.Core.Category.DTOs;

namespace Readify.Domain.Core.Category.Services;

public interface ICategoryService
{
    Result<bool> Create(CreateCategoryDto createCategoryDto);
    List<GetCategoryDto> GetPopularCategories(int count);
    List<GetCategoryDto> GetCategories();
    Result<GetCategoryDto> GetById(int categoryId);
    bool Delete(int categoryId);
    Result<bool> Update(int categoryId, CreateCategoryDto newCategory);
    int CategoryCount();
}