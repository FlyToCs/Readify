using Microsoft.AspNetCore.Http;
using Readify.Domain._common.Entities;
using Readify.Domain.BookAgg.Contracts.RepositoryContracts;
using Readify.Domain.CategoryAgg.Contracts.RepositoryContracts;
using Readify.Domain.CategoryAgg.Contracts.ServiceContracts;
using Readify.Domain.CategoryAgg.DTOs;
using Readify.Domain.FileAgg;
using Readify.Domain.UserAgg.DTOs;

namespace Readify.Services;

public class CategoryService(ICategoryRepository categoryRepository, IFileService fileService) : ICategoryService
{
    public Result<bool> Create(CreateCategoryDto createCategoryDto)
    {
        if (string.IsNullOrWhiteSpace(createCategoryDto.Name) || string.IsNullOrWhiteSpace(createCategoryDto.Descerption))
            return Result<bool>.Failure("نام دسته بندی و توضیحات ان نمیتواند خالی باشد");
        

        if (createCategoryDto.UserId == 0)
            return Result<bool>.Failure("مقدار ادمین ایدی برای ایجاد این دسته بندی به درستی پر نشده است");
        

        if (createCategoryDto.ImgFile != null)
            createCategoryDto.ImgUrl = fileService.Upload(createCategoryDto.ImgFile, "Categories");
        else
            createCategoryDto.ImgUrl = "/Files/Categories/category.png";
        
        
        var result = categoryRepository
            .Create(createCategoryDto.Name, createCategoryDto.Descerption, createCategoryDto.ImgUrl, createCategoryDto.UserId);
        return Result<bool>.Success("عملیات با موفقیت انجام شد",result);
    }

    public List<GetCategoryDto> GetPopularCategories(int count)
    {
        return categoryRepository.GetPopularCategories(count);
    }
    public List<GetCategoryDto> GetCategories()
    {
        return categoryRepository.GetCategories();
    }

    public bool Delete(int categoryId)
    {
        var img = categoryRepository.ImgUrl(categoryId);
        if (img != null)
        {
            fileService.Delete(img);
        }

        return categoryRepository.Delete(categoryId);
    }

    public Result<bool> Update(int categoryId, CreateCategoryDto newCategory)
    {
        var category = categoryRepository.GetById(categoryId);
        if (category == null)
            return Result<bool>.Failure(message:"دسته بندی یافت نشد");

        if (newCategory.Name == null! || newCategory.Descerption == null!)
            return Result<bool>.Failure(message: "نام دسته بندی و توضیحات نمیتواند خالی باشد");

        if (newCategory.ImgFile == null)
            return Result<bool>.Failure(message: "دسته بندی باید شامل یک تصویر باشد");
        newCategory.ImgUrl = fileService.Upload(newCategory.ImgFile, "Categories");

        categoryRepository.Update(categoryId, newCategory);
        return Result<bool>.Success(message: "عمیات با موفقیت انجام شد");
    }
}