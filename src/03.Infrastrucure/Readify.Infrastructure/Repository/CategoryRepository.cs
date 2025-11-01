
using Readify.Domain.BookAgg.Contracts.RepositoryContracts;
using Readify.Domain.CategoryAgg.Contracts.RepositoryContracts;
using Readify.Domain.CategoryAgg.DTOs;
using Readify.Domain.CategoryAgg.Entities;
using Readify.Infrastructure.Persistence;

namespace Readify.Infrastructure.Repository;

public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    public int Create(string name, string description, int userId)
    {
        var category = new Category()
        {
            Name = name,
            Description = description,
            UserId = userId
        };
        context.Add(category);
        context.SaveChanges();
        return category.Id;
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


}