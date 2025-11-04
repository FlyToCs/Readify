using Readify.Domain._common.Entities;
using Readify.Domain.BookAgg.Entities;
using Readify.Domain.CategoryAgg.Entities;
using Readify.Domain.UserAgg.Enums;

namespace Readify.Domain.UserAgg.Entities;

public class User : BaseEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string HashedPassword { get; set; }
    public RoleEnum Role { get; set; }
    public string? ImgUrl { get; set; }
    public bool IsActive { get; set; }
    public List<Book> Books { get; set; } = [];
    public List<Category> Categories { get; set; } = [];
}