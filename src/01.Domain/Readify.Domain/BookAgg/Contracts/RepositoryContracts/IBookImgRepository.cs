namespace Readify.Domain.BookAgg.Contracts.RepositoryContracts;

public interface IBookImgRepository
{
    int Create(string imgUrl, bool isMainImg, int bookId);
}