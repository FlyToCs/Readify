namespace Readify.Domain.BookAgg.Contracts.RepositoryContracts;

public interface IBookImgRepository
{
    int Create(string imgUrl, bool isMainImg, int bookId);
    bool DeleteMainImg(string imgUrl, int bookId);
    string? GetImgCover(int bookId);
    bool DeleteImgs(int bookId);
}