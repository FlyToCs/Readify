using System.Reflection;
using Readify.Domain.BookAgg.Contracts.RepositoryContracts;
using Readify.Domain.BookAgg.Entities;
using Readify.Infrastructure.Persistence;

namespace Readify.Infrastructure.Repository;

public class BookImgRepository(AppDbContext context): IBookImgRepository
{
    public void Create(string imgUrl, bool isMainImg, int bookId)
    {
        var img = new BookImg()
        {
            ImageUrl = imgUrl,
            IsMainImg = isMainImg,
            BookId = bookId
        };
        context.Add(img);
        context.SaveChanges();
    }
}