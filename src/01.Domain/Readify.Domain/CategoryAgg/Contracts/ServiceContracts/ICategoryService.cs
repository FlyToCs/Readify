using Microsoft.AspNetCore.Http;
using Readify.Domain._common.Entities;
using Readify.Domain.CategoryAgg.DTOs;

namespace Readify.Domain.CategoryAgg.Contracts.ServiceContracts;

public interface ICategoryService
{
    Result<bool> Create(CreateCategoryDto createCategoryDto);
    List<GetCategoryDto> GetPopularCategories(int count);
    List<GetCategoryDto> GetCategories();
    Result<GetCategoryDto> GetById(int categoryId);
    bool Delete(int categoryId);
    Result<bool> Update(int categoryId, CreateCategoryDto newCategory);

}