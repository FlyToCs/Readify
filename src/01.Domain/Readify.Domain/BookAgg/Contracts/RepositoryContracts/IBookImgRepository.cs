namespace Readify.Domain.BookAgg.Contracts.RepositoryContracts;

public interface IBookImgRepository
{
    void Create(string imgUrl, bool isMainImg, int bookId);
}