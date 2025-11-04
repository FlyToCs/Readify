
using Microsoft.EntityFrameworkCore;
using Readify.Domain.BookAgg.Contracts.RepositoryContracts;
using Readify.Domain.CategoryAgg.Contracts.RepositoryContracts;
using Readify.Domain.CategoryAgg.DTOs;
using Readify.Domain.CategoryAgg.Entities;
using Readify.Infrastructure.Persistence;

namespace Readify.Infrastructure.Repository;

public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    public bool Create(string name, string description,string imgUrl, int userId)
    {
        var category = new Category()
        {
            Name = name,
            Description = description,
            UserId = userId,
            ImgUrl = imgUrl
        };
        context.Add(category);
        context.SaveChanges();
        return true;
    }

    public List<GetCategoryDto> GetPopularCategories(int count)
    {
        return context.Categories
            .OrderByDescending(c => c.Books.Count)
            .Take(count)
            .Select(c => new GetCategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                ImgUrl = c.ImgUrl,
                Description = c.Description
            })
            .ToList();
    }
    public List<GetCategoryDto> GetCategories()
    {
        return context.Categories
            .OrderByDescending(c => c.Books.Count)
            .Select(c => new GetCategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                ImgUrl = c.ImgUrl,
                Description = c.Description
            })
            .ToList();
    }

    public GetCategoryDto? GetById(int categoryId)
    {
        return context.Categories.Where(c => c.Id == categoryId)
            .Select(c => new GetCategoryDto()
        {
            Id = c.Id,
            Description = c.Description,
            Name = c.Name,
            ImgUrl = c.ImgUrl
        }).FirstOrDefault();
    }

    public string? ImgUrl(int categoryId)
    {
        return context.Categories.Where(c => c.Id == categoryId).Select(c => c.ImgUrl).FirstOrDefault();
    }

    public bool Delete(int categoryId)
    {
        var effectiveRows = context.Categories.Where(c => c.Id == categoryId).ExecuteDelete();
        return effectiveRows > 0;
    }

    public bool Update(int categoryId, CreateCategoryDto newCategory)
    {
        var effectiveRows =  context.Categories.Where(c => c.Id == categoryId)
            .ExecuteUpdate(setter => setter
                .SetProperty(c => c.Name, newCategory.Name)
                .SetProperty(c=>c.Description, newCategory.Descerption)
                .SetProperty(c=>c.ImgUrl,newCategory.ImgUrl)
            );
        return effectiveRows > 0;
    }
}