using Readify.Domain.Core._common.Entities;
using Readify.Domain.Core.Category.Data;
using Readify.Domain.Core.Category.DTOs;
using Readify.Domain.Core.Category.Services;
using Readify.Domain.Core.File.Services;

namespace Readify.Domain.Services.Category;

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

    public Result<GetCategoryDto> GetById(int categoryId)
    {
        var category =  categoryRepository.GetById(categoryId);
        if (category == null)
        {
            return Result<GetCategoryDto>.Failure("دسته بندی یافت نشد", null);
        }

        return Result<GetCategoryDto>.Success("",category);
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
            return Result<bool>.Failure(message: "دسته بندی یافت نشد");

        if (string.IsNullOrWhiteSpace(newCategory.Name) || string.IsNullOrWhiteSpace(newCategory.Descerption))
            return Result<bool>.Failure(message: "نام دسته بندی و توضیحات نمیتواند خالی باشد");

        if (newCategory.ImgFile == null && string.IsNullOrWhiteSpace(newCategory.ImgUrl))
            return Result<bool>.Failure(message: "دسته بندی باید شامل یک تصویر باشد");

        if (newCategory.ImgFile != null)
            newCategory.ImgUrl = fileService.Upload(newCategory.ImgFile, "Categories");

        categoryRepository.Update(categoryId, newCategory);

        return Result<bool>.Success(message: "عملیات با موفقیت انجام شد");
    }

    public int CategoryCount()
    {
        return categoryRepository.CategoryCount();
    }
}