using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Readify.Domain.BookAgg.Contracts.RepositoryContracts;
using Readify.Domain.BookAgg.Entities;
using Readify.Infrastructure.Persistence;

namespace Readify.Infrastructure.Repository;

public class BookImgRepository(AppDbContext context): IBookImgRepository
{
    public int Create(string imgUrl, bool isMainImg, int bookId)
    {
        var img = new BookImg()
        {
            ImageUrl = imgUrl,
            IsMainImg = isMainImg,
            BookId = bookId
        };
        context.Add(img);
        return context.SaveChanges();
    }

    public bool DeleteMainImg(string imgUrl, int bookId)
    {
        var effectiveRows = context.BookImgs
            .Where(i => i.BookId == bookId && i.ImageUrl == imgUrl)
            .ExecuteDelete();

        return effectiveRows > 0;
    }


    public string? GetImgCover(int bookId)
    {
        return context.BookImgs.FirstOrDefault(i => i.BookId == bookId && i.IsMainImg)?.ImageUrl;
    }
}