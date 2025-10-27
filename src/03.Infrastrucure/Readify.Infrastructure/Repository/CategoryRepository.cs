using Microsoft.EntityFrameworkCore;
using Readify.Domain.BookAgg.Contracts.RepositoryContracts;
using Readify.Domain.BookAgg.DTOs;
using Readify.Domain.BookAgg.Entities;
using Readify.Infrastructure.Persistence;

namespace Readify.Infrastructure.Repository;

public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    public void Create(string name, string description)
    {
        var category = new Category()
        {
            Name = name,
            Description = description
        };
        context.Add(category);
        context.SaveChanges();
    }

    public List<GetCategoryDto> GetPopularCategories(int count)
    {
        return context.Categories
            .OrderByDescending(c => c.Books.Count)
            .Take(count)
            .Select(c => new GetCategoryDto
            {
                Name = c.Name,
                ImgUrl = c.ImgUrl,
               Description = c.Description
            })
            .ToList();
    }

}