using Readify.Domain.Core.Book.Entities;
using Readify.Domain.Core._common.Entities;
using Readify.Domain.Core.User.Enums;

namespace Readify.Domain.Core.User.Entities;

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
    public List<Book.Entities.Book> Books { get; set; } = [];
    public List<Category.Entities.Category> Categories { get; set; } = [];
}