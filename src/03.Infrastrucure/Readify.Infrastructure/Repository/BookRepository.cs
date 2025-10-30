using Microsoft.EntityFrameworkCore;
using Readify.Domain.BookAgg.Contracts.RepositoryContracts;
using Readify.Domain.BookAgg.DTOs;
using Readify.Domain.BookAgg.Entities;
using Readify.Infrastructure.Persistence;

namespace Readify.Infrastructure.Repository;

public class BookRepository(AppDbContext context) : IBookRepository
{
    public int Create(CreateBookDto createBookDto)
    {
        var book = new Book()
        {
            Name = createBookDto.Name,
            AuthorName = createBookDto.AuthorName,
            CategoryId = createBookDto.CategoryId,
            Price = createBookDto.Price,
            PageCount = createBookDto.PageCount
        };
        context.Add(book);
        context.SaveChanges();
        return book.Id;
    }

    public List<GetBookDto> GetRecentlyBooks(int count)
    {
        return context.Books
            .OrderByDescending(b => b.CreatedAt)
            .Take(count)
            .Include(b => b.BookImgs)
            .Select(b => new GetBookDto()
            {
                Id = b.Id,
                AuthorName = b.AuthorName,
                BookName = b.Name,
                img = b.BookImgs.FirstOrDefault(b => b.IsMainImg),
                PageCount = b.PageCount,
                Price = b.Price
            }).ToList();
    }
    public List<GetBookDto> GetBooks()
    {
        return context.Books
            .OrderByDescending(b => b.CreatedAt)
            .Include(b => b.BookImgs)
            .Select(b => new GetBookDto()
            {
                Id = b.Id,
                AuthorName = b.AuthorName,
                BookName = b.Name,
                img = b.BookImgs.FirstOrDefault(b => b.IsMainImg),
                PageCount = b.PageCount,
                Price = b.Price
            }).ToList();
    }
}