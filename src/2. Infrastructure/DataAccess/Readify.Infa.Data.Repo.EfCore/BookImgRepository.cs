using Microsoft.EntityFrameworkCore;
using Readify.Domain.Core.Book.Data;
using Readify.Domain.Core.Book.Entities;
using Readify.Infa.Db.SqlServer.EfCore.DbContexts;

namespace Readify.Infa.Data.Repo.EfCore;

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

    public bool DeleteImgs(int bookId)
    {
        var effectiveRows = context.BookImgs.Where(i => i.BookId == bookId)
            .ExecuteDelete();
        return effectiveRows > 0;
    }
}